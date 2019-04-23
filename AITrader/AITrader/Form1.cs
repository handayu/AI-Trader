using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI.Docking;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Themes;

namespace AITrader
{
    public partial class Form1 : RadForm
    {
        private static readonly string RtfFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Docking\VisualStudioIDE\Files");
        private static readonly string Form1RftFile = Path.Combine(RtfFolder, "Form1.rtf");
        private static readonly string Form1DesignerRftFile = Path.Combine(RtfFolder, "Form1.Designer.rtf");
        private static readonly string AssemblyInfoRftFile = Path.Combine(RtfFolder, "AssemblyInfo.rtf");
        private static readonly string ProgramRtfFile = Path.Combine(RtfFolder, "Program.rtf");
        private static readonly string OutputFile = Path.Combine(RtfFolder, "Output.txt");
        
        const int ErrorGridRow = 1;
        const int ErrorGridLine = 20;
        const int ErrorGridColumn = 33;
        const string ErrorGridFile = "Program.cs";
        const string ErrorGridProject = "ProjectTracker";
        const string ErrorGridDescription = @"The type or namespace name 'Form12' could not be found (are you missing a using directive or an assembly reference?)	C:\ProjectTracker\Program.cs";
        
        const string TaskGridDescription = @"TO DO: Refactor the whole data access layer to use Open Access";
        const string TaskGridFile = @"DBPool.cs";
        const int TaskGridLine = 501;


        public Form1()
        {
            InitializeComponent();
            new VisualStudio2012DarkTheme();
            ThemeResolutionService.ApplyThemeToControlTree(this, "VisualStudio2012Light");
            this.richTextBoxOutput.TextBoxElement.BackColor = Color.FromArgb(230, 231, 232);
            this.radGridViewErrors.TableElement.BackColor = Color.FromArgb(230, 231, 232);
            this.radGridViewTasks.TableElement.BackColor = Color.FromArgb(230, 231, 232);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetupAllGrids();
            this.SetupToolWindowImages();
            this.SetupTreeNodes();
            this.richTextBoxOutput.Font = new Font("Consolas", 9, FontStyle.Regular);
            this.richTextBoxOutput.Text = File.ReadAllText(OutputFile);
        }

        private void SetupTreeNodes()
        {
            this.radTreeView1.Find("Form1.cs").Tag = Form1RftFile;
            this.radTreeView1.Find("Program.cs").Tag = ProgramRtfFile;
            this.radTreeView1.Find("AssemblyInfo.cs").Tag = AssemblyInfoRftFile;
            this.radTreeView1.Find("Form1.Designer.cs").Tag = Form1DesignerRftFile;
            OpenFile(Form1RftFile, "Form1.cs");
        }

        private DocumentWindow OpenFile(string fileName, string displayName)
        {
            DocumentWindow dw = new DocumentWindow();
            RichTextBox rtb = new RichTextBox();
            rtb.Rtf = File.ReadAllText(fileName);
            rtb.Dock = DockStyle.Fill;
            rtb.BorderStyle = BorderStyle.None;
            rtb.AcceptsTab = true;
            rtb.TextChanged += editor_TextChanged;

            dw.Controls.Add(rtb);
            dw.Text = displayName;
            dw.Name = displayName;
            this.radDock1.AddDocument(dw);

            return dw;
        }

        private void SetupToolWindowImages()
        {
            toolWindow5.Image = ImageList1.Images[1];
            toolWindow3.Image = ImageList1.Images[5];
            toolWindow4.Image = ImageList1.Images[14];
        }

        private void SetupAllGrids()
        {
            this.radGridViewErrors.Columns["columnImage"].HeaderText = String.Empty;
            this.radGridViewErrors.Columns["columnNumber"].HeaderText = String.Empty;

            this.radGridViewErrors.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            Image image = ImageList1.Images[11];
            
            this.radGridViewErrors.Rows.Add(image, ErrorGridRow, ErrorGridDescription, ErrorGridFile, ErrorGridLine, ErrorGridColumn, ErrorGridProject);
            this.radGridViewErrors.MasterTemplate.ShowRowHeaderColumn = false;

            this.radGridViewTasks.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridViewTasks.Rows.Add(String.Empty, TaskGridDescription, TaskGridFile, TaskGridLine);
            this.radGridViewTasks.MasterTemplate.ShowRowHeaderColumn = false;
        }

        void editor_TextChanged(object sender, EventArgs e)
        {
            RichTextBox senderRtb = sender as RichTextBox;
            DocumentWindow document = senderRtb.Parent as DocumentWindow;

            if (document != null)
            {
                if (!document.Text.EndsWith("*"))
                {
                    document.Text += "*";
                }

                if (document.TabStrip != null && document.TabStrip.TabStripElement.PreviewItem == document.TabStripItem)
                {
                    document.TabStrip.TabStripElement.PreviewItem = null;
                }
            }
        }

        private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            RadTreeNode node = this.radTreeView1.SelectedNode;
            if (node != null && node.Tag != null)
            {
                DocumentWindow document = this.radDock1.GetWindow<DocumentWindow>(e.Node.Text);
                if (document == null)
                {
                    document = OpenFile(e.Node.Tag.ToString(), e.Node.Text);
                }
                else
                {
                    return;
                }

                if (document.TabStrip.TabStripElement.PreviewItem == document.TabStripItem)
                {
                    return;
                }

                foreach (DocumentWindow dw in this.radDock1.GetWindows<DocumentWindow>())
                {
                    RadPageViewStripElement tabStrip = dw.TabStrip.TabStripElement;
                    if (tabStrip.PreviewItem != null)
                    {
                        this.radDock1.CloseWindow((DockWindow)((TabStripItem)tabStrip.PreviewItem).TabPanel);
                        tabStrip.PreviewItem = null;
                    }
                }

                document.TabStrip.TabStripElement.PreviewItem = document.TabStripItem;
                this.radDock1.ActiveWindow = document;
            }
        }

        private void radTreeView1_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                DocumentWindow document = this.radDock1.GetWindow<DocumentWindow>(e.Node.Text);
                if (document == null)
                {
                    document = OpenFile(e.Node.Tag.ToString(), e.Node.Text);
                }
                else if (document.TabStrip.TabStripElement.PreviewItem == document.TabStripItem)
                {
                    document.TabStrip.TabStripElement.PreviewItem = null;
                }

                this.radDock1.ActiveWindow = document;
            }
            else if (e.Node.Nodes.Count > 0)
            {
                e.Node.Expanded = !e.Node.Expanded;
            }
        }

        private void radTreeView1_NodeExpandedChanged(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Text == "Forms")
            {
                e.Node.ImageIndex = e.Node.Expanded ? 4 : 2;
                e.Node.Image = null;
            }
        }

        private void Form_load(object sender, EventArgs e)
        {
            this.AllowTheming = true;
            //this.ThemeClassName = "VisualStudio2012Dark";

            Control.ControlCollection c = this.Controls;
            foreach(Control ctrl in c)
            {
            }
        }
    }
}
