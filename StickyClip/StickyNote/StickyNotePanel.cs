using System;
using System.Drawing;
using System.Windows.Forms;

namespace StickyClip.StickyNote
{
    class StickyNotePanel : Panel
    {
        public readonly Control leftButton;
        public readonly Control rightButton;
        public readonly Control mainControl;

        public StickyNotePanel(Size superSize, Control leftButton, Control rightButton, Control mainControl)
        {
            Size = superSize;
            this.leftButton = leftButton;
            this.rightButton = rightButton;
            this.mainControl = mainControl;

            InitializeComponent();
            AddControls();
        }

        public void UpdateSize(Size size)
        {
            Size = size;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            InitializeRightButton();
            InitializeLeftButton();
            InitializeMainControl();
        }

        private void AddControls()
        {
            Controls.Add(mainControl);
            Controls.Add(leftButton);
            Controls.Add(rightButton);
        }

        private void InitializeMainControl()
        {
            int offset = Math.Max(leftButton.Size.Height, rightButton.Size.Height);
            mainControl.Size = new Size(Size.Width, Size.Height - offset);
            mainControl.Location = new Point(0, offset);
        }

        private void InitializeLeftButton()
        {
            leftButton.Anchor = ((AnchorStyles.Top) | (AnchorStyles.Left));
            leftButton.Size = new Size(20, 20);
            leftButton.Location = new Point(Size.Width - rightButton.Size.Width - leftButton.Size.Width, 0);
            leftButton.Name = "leftButton";
            leftButton.TabIndex = 0;
        }

        private void InitializeRightButton()
        {
            rightButton.Anchor = ((AnchorStyles.Top) | (AnchorStyles.Right));
            rightButton.Size = new Size(20, 20);
            rightButton.Location = new Point(Size.Width - rightButton.Size.Width, 0);
            rightButton.Name = "rightButton";
            rightButton.TabIndex = 1;
        }
    }
}
