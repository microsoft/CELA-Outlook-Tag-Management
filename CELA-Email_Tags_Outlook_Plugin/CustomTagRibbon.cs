using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using CELA_Tags_Service_Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Office.Tools;

namespace CELA_Email_Tags_Outlook_Plugin
{
    public partial class CustomTagRibbon
    {
        MailProcessingUtilities utility;

        private void CustomTagRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            utility = Globals.ThisAddIn.ProcessingUtility;
            this.manageTagsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.manageTagsButton_Click);
            this.archiveButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.archiveButton_Click);
            this.settingsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.settingsButton_Click);

            String baseLabelText = global::CELA_Email_Tags_Outlook_Plugin.CELA_Custom_Ribbon.manageTagsButtonLabelText;
            this.manageTagsButton.Label = baseLabelText;

        }

        private void manageTagsButton_Click(object sender, RibbonControlEventArgs e)
        {
            var tags = utility.GetTags();
            utility.AddTagsToEmail(ThisAddIn.currentMailItem, tags);
        }

        private void archiveButton_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void showTagManagementTaskPaneToggleButton_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Inspector inspector = (Outlook.Inspector)e.Control.Context;
            InspectorWrapper inspectorWrapper = Globals.ThisAddIn.InspectorWrappers[inspector];
            CustomTaskPane taskPane = inspectorWrapper.CustomTaskPane;
            if (taskPane != null)
            {
                taskPane.Visible = ((RibbonToggleButton)sender).Checked;
            }
        }
    }
}
