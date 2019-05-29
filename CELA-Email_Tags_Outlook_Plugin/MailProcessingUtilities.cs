using CELA_Tags_Service_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace CELA_Email_Tags_Outlook_Plugin
{
    public class MailProcessingUtilities
    {
        HttpClient client = new HttpClient();

        public MailProcessingUtilities()
        {
            //TODO: Get the base URI from a settings object
            client.BaseAddress = new Uri("http://celatagservice.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Tag> GetTags()
        {
            //TODO: This will be broken until we start serializing Tag rather than TopicTag
            List<Tag> tags = null;
            var tagsJSON = GetTagsFromService().Result;
            tags = JsonConvert.DeserializeObject<List<Tag>>(tagsJSON);
            return tags;
        }

        async Task<string> GetTagsFromService()
        {
            HttpResponseMessage response = await client.GetAsync("api/tags");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return "";
        }

        public bool AddTagsToEmail(MailItem mail, List<Tag> tags)
        {
            if (mail != null && tags.Count > 0)
            {
                if(mail.BodyFormat == OlBodyFormat.olFormatHTML)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < tags.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append("<br/>");
                        }
                        sb.Append(tags.ElementAt(i).Value);
                    }

                    var HTMLBody = mail.HTMLBody.ToString();
                    var splitIndex = HTMLBody.LastIndexOf("</body>");

                    if (splitIndex > 0)
                    {
                        sb.Append("<br/>");
                        var newHTMLBody = HTMLBody.Substring(0, splitIndex) + "<div><span style=\"background: #A9E8FA;\">" + sb.ToString() + "</span></div>" + HTMLBody.Substring(splitIndex, HTMLBody.Length - splitIndex);
                        mail.HTMLBody = newHTMLBody;
                    }
                }
                
                return true;

            }
            return false;
        }

        /// <summary>
        /// Tags found in the HTMLBody element of the supplied MailItem
        /// </summary>
        /// <param name="mail">The mail to be searched.</param>
        /// <param name="tags">The tags to search for in the mail.</param>
        /// <returns>A list of Tags found in the MailItem.</returns>
        public List<Tag> EmailContainsTags(MailItem mail, List<Tag> tags)
        {
            var tagsFoundInEmail = new List<Tag>();
            var emailText = mail.HTMLBody.ToString();
            foreach (var tag in tags)
            {
                if (emailText.IndexOf(tag.Value) > -1)
                {
                    tagsFoundInEmail.Add(tag);
                }
            }
            return tagsFoundInEmail;
        }

        /// <summary>
        /// Removes the tags from email.
        /// </summary>
        /// <param name="mail">The mail to be processed.</param>
        /// <param name="tags">The tags to be removed from the mail.</param>
        /// <returns>MailItem that has been processed to remove all supplied tags from the HTMLBody attribute.</returns>
        public MailItem RemoveTagsFromEmail(MailItem mail, List<Tag> tags)
        {
            //TODO: Update this method to clean tags from HTML, plain text, and rich text as applicable. Make sure you update the method documentation.
            var HTMLBody = mail.HTMLBody.ToString();
            StringBuilder sb = new StringBuilder(HTMLBody);
            foreach (var tag in tags)
            {
                sb.Replace(tag.Value, string.Empty);
            }
            mail.HTMLBody = sb.ToString();
            return mail;
        }
    }
}
