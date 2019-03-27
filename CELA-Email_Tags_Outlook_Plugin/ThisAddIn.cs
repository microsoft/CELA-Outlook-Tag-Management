using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools;

namespace CELA_Email_Tags_Outlook_Plugin
{
    public partial class ThisAddIn
    {
        private Dictionary<Outlook.Inspector, InspectorWrapper> inspectorWrappersValue = new Dictionary<Outlook.Inspector, InspectorWrapper>();
        public Outlook.Inspectors inspectors;
        public static Outlook.MailItem currentMailItem;

        public CustomTaskPane tagManagementTaskPane;
        public TagManagementControl tagManagementControl;
        private MailProcessingUtilities processingUtility;

        public Dictionary<Outlook.Inspector, InspectorWrapper> InspectorWrappers
        {
            get
            {
                return inspectorWrappersValue;
            }
        }

        public MailProcessingUtilities ProcessingUtility
        {
            get
            {
                return processingUtility;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            processingUtility = new MailProcessingUtilities();
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector +=
            new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

            foreach (Outlook.Inspector inspector in inspectors)
            {
                Inspectors_NewInspector(inspector);
            }

            tagManagementControl = new TagManagementControl();
            tagManagementTaskPane = this.CustomTaskPanes.Add(tagManagementControl, global::CELA_Email_Tags_Outlook_Plugin.CELA_Custom_Ribbon.tagManagmentDisplayPanelTitleText);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            inspectors.NewInspector -=
                new Outlook.InspectorsEvents_NewInspectorEventHandler(
                Inspectors_NewInspector);
            inspectors = null;
            inspectorWrappersValue = null;
        }


        void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        { 
            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                currentMailItem = null;
                Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
                if (mailItem != null)
                {
                    currentMailItem = mailItem;
                    inspectorWrappersValue.Add(Inspector, new InspectorWrapper(Inspector));
                }
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }

    //REFERENCE: https://msdn.microsoft.com/en-us/library/bb296010.aspx
    public class InspectorWrapper
    {
        private Outlook.Inspector inspector;
        private CustomTaskPane taskPane;

        public InspectorWrapper(Outlook.Inspector Inspector)
        {
            inspector = Inspector;
            ((Outlook.InspectorEvents_Event)inspector).Close +=
                new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);

            taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(
                new TagManagementControl(), "Email Tags", inspector);
            taskPane.VisibleChanged += new EventHandler(TaskPane_VisibleChanged);
        }

        void TaskPane_VisibleChanged(object sender, EventArgs e)
        {
            //TODO: Implement a toggling view for the TaskPane
            //Globals.Ribbons[inspector].CustomTagRibbon.toggleButton1.Checked = taskPane.Visible;
        }

        void InspectorWrapper_Close()
        {
            if (taskPane != null)
            {
                Globals.ThisAddIn.CustomTaskPanes.Remove(taskPane);
            }

            taskPane = null;
            Globals.ThisAddIn.InspectorWrappers.Remove(inspector);
            ((Outlook.InspectorEvents_Event)inspector).Close -=
                new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
            inspector = null; 
        }
        public CustomTaskPane CustomTaskPane
        {
            get
            {
                return taskPane;
            }
        }
    }
}
