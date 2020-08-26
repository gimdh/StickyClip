using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyClip.StickyNote
{
    class StickyNotePanel : Panel
    {
        public StickyNotePanel(Size superSize, Control leftButton, Control rightButton, Control mainControl)
        {
            ClientSize = superSize;

            //rightButton
            rightButton.Anchor = ((AnchorStyles.Top) | (AnchorStyles.Right));
            rightButton.Size = new Size(20, 20);
            rightButton.Location = new Point(ClientSize.Width - rightButton.Size.Width, 0);
            rightButton.Name = "rightButton";
            rightButton.TabIndex = 1;

            //leftButton
            leftButton.Anchor = ((AnchorStyles.Top) | (AnchorStyles.Left));
            leftButton.Size = new Size(20, 20);
            leftButton.Location = new Point(ClientSize.Width - rightButton.Size.Width - leftButton.Size.Width, 0);
            leftButton.Name = "leftButton";
            leftButton.TabIndex = 0;

            //mainControl
            int offset = Math.Max(leftButton.Size.Height, rightButton.Size.Height);
            mainControl.Size = new Size(ClientSize.Width, ClientSize.Height - offset);
            mainControl.Location = new Point(0, offset);

            //Add controls
            Controls.Add(mainControl);
            Controls.Add(leftButton);
            Controls.Add(rightButton);
        }
    }
}
