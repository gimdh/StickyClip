namespace StickyClip.StickyNote
{
    partial class StickyNoteForm
    {
        StickyNotePanel viewPanel;
        StickyNotePanel editPanel;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.ClientSize = Settings.Default.DefaultSize;
            this.viewPanel = StickyNotePanelFactory.CreateViewer(this.ClientSize);
            this.editPanel = StickyNotePanelFactory.CreateEditor(this.ClientSize);

            this.Resize += StickyNoteForm_Resize;

            this.SuspendLayout();

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;

            this.editPanel.Visible = false;
            this.Controls.Add(viewPanel);
            this.Controls.Add(editPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void StickyNoteForm_Resize(object sender, System.EventArgs e)
        {
            viewPanel.UpdateSize(ClientSize);
            editPanel.UpdateSize(ClientSize);
        }
    }
}