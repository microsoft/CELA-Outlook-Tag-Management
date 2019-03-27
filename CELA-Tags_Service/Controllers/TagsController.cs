using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CELA_Tags_Service.Controllers
{
    public class TagsController : ApiController
    {
        // GET: api/Tags
        public List<CELA_Tags_Service_Models.Tag> Get()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/TestData/testtags.json");
            string text = System.IO.File.ReadAllText(filePath);
            List<CELA_Tags_Service_Models.Tag> tags = JsonConvert.DeserializeObject<List<CELA_Tags_Service_Models.Tag>>(text);
            return tags;
        }

        // GET: api/Tags/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tags
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tags/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tags/5
        public void Delete(int id)
        {
        }
    }
}
