using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CELA_Tags_Service_Models;

namespace CELA_Email_Tags_Outlook_Plugin
{
    public partial class TagManagementControl : UserControl
    {
        private Dictionary<string, Tag> TagDictionary = new Dictionary<string, Tag>();
        private List<Tag> TagList = new List<Tag>();
        private string tagsUsedBaseLabelText;

        public TagManagementControl()
        {
            InitializeComponent();
            var done = populateTags();
            populateTagsAvailableTreeView();
            tagsUsedBaseLabelText = global::CELA_Email_Tags_Outlook_Plugin.CELA_Custom_Ribbon.tagsInEmailLabel;
            if (ThisAddIn.currentMailItem != null)
            {
                updateTagsCount();

            }
            //TODO: Create a task that periodically updates the current tags in email label so it is accurate
        }

        private bool populateTags()
        {
            TagTestDataGenerator tagGenerator = new TagTestDataGenerator();

            var tagPersons = tagGenerator.GenerateIndviduals();
            var tags = tagGenerator.GenerateTags(tagPersons, tagPersons);

            foreach (var tag in tags)
            {
                TagDictionary.Add(tag.Value, tag);
            }

            TagList = TagDictionary.Values.ToList<Tag>();
            return true;
        }

        private bool updateTagsCount()
        {
            List<Tag> tagsUsed = Globals.ThisAddIn.ProcessingUtility.EmailContainsTags(ThisAddIn.currentMailItem, TagList);
            tagsInEmailLabel.Text = tagsUsedBaseLabelText + " " + tagsUsed.Count;
            populateTagsUsedListView(tagsUsed);
            return true;
        }

        private void removeAllTagsButton_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.ProcessingUtility.RemoveTagsFromEmail(ThisAddIn.currentMailItem, TagList);
            updateTagsCount();
        }

        private void tagsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                Console.WriteLine(e.Node.Text);
            }
            else
            {
                Console.WriteLine("No node selected.");
            }
        }

        private void populateTagsAvailableTreeView()
        {
            tagsLibraryTreeView.BeginUpdate();
            foreach (var tag in TagDictionary.Values)
            {
                tagsLibraryTreeView.Nodes.Add(tag.Value, tag.Value);
            }
            tagsLibraryTreeView.EndUpdate();
        }

        private void populateTagsUsedListView(List<Tag> tags)
        {
            //Clear and then add distinct tag names to tags used list view via range
            tagsUsedListView.BeginUpdate();
            tagsUsedListView.Items.Clear();
            tagsUsedListView.Items.AddRange(tags.GroupBy(test => test.Name).Select(grp => grp.First()).Select(t => new ListViewItem(t.Name)).ToArray()) ;
            tagsUsedListView.EndUpdate();
        }

        private void addTagsButton_Click(object sender, EventArgs e)
        {
            addTags(sender);
        }

        private void tagsInEmailLabel_Click(object sender, EventArgs e)
        {

        }

        private void tagsUsedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tagsUsedListView.SelectedItems != null && tagsUsedListView.SelectedItems.Count > 0)
            {
                //TODO: Figure out how to highlight the selected tag
            }
        }

        private void addTags(object sender)
        {
            var selectedTag = tagsLibraryTreeView.SelectedNode.Text;
            var tagList = new List<Tag>();
            tagList.Add(TagDictionary[selectedTag]);
            Globals.ThisAddIn.ProcessingUtility.AddTagsToEmail(ThisAddIn.currentMailItem, tagList);
            updateTagsCount();
        }

        private void TagsLibraryTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addTags(sender);
        }
    }
}
