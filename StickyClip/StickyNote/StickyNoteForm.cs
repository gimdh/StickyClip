using System;
using System.Drawing;
using System.Windows.Forms;

namespace StickyClip.StickyNote
{
    public partial class StickyNoteForm : Form
    {
        bool mouseDown;
        Point lastLocation;

        public string MarkdownString { get; private set; }

        public StickyNoteForm(string markdown)
        {
            MarkdownString = markdown;

            InitializeComponent();
            AttachEventHandlers();
            UpdateViewer();
        }

        private void AttachEventHandlers()
        {
            viewPanel.leftButton.Click += ViewPanelLeftButton_Click;
            viewPanel.rightButton.Click += ViewPanelRightButton_Click;
            editPanel.rightButton.Click += EditPanelRightButton_Click;

            viewPanel.MouseDown += StickyNoteFormPanel_MouseDown;
            viewPanel.MouseUp += StickyNoteFormPanel_MouseUp;
            viewPanel.MouseMove += StickyNoteFormPanel_MouseMove;

            editPanel.MouseDown += StickyNoteFormPanel_MouseDown;
            editPanel.MouseUp += StickyNoteFormPanel_MouseUp;
            editPanel.MouseMove += StickyNoteFormPanel_MouseMove;
        }

        private void StickyNoteFormPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location =
                    new Point(Location.X - lastLocation.X + e.X,
                        Location.Y - lastLocation.Y + e.Y);

                Update();
            }
        }

        private void StickyNoteFormPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void StickyNoteFormPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void UpdateViewer()
        {
            ((WebBrowser)viewPanel.mainControl).DocumentText = 
                $"<style>*{{margin-top: 0px; background-color: {ColorTranslator.ToHtml(SystemColors.Control)};"
                + "font-family: sans-serif}}</style>"
                + Markdig.Markdown.ToHtml(MarkdownString);
        }

        private void EditPanelRightButton_Click(object sender, EventArgs e)
        {
            MarkdownString = editPanel.mainControl.Text;
            UpdateViewer();

            viewPanel.Visible = true;
            editPanel.Visible = false;
        }

        private void ViewPanelRightButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewPanelLeftButton_Click(object sender, EventArgs e)
        {
            editPanel.mainControl.Text = MarkdownString;
            
            editPanel.Visible = true;
            viewPanel.Visible = false;
        }
    }
}
