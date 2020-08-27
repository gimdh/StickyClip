using System.Drawing;
using System.Windows.Forms;

namespace StickyClip.StickyNote
{
    class StickyNotePanelFactory
    {
        public static StickyNotePanel CreateViewer(Size superSize)
        {
            Label editButton = new Label { Text = "🖉" };
            Label exitButton = new Label { Text = "✕" };
            WebBrowser mainViewer = new WebBrowser { ScrollBarsEnabled = false, Margin = new Padding(5, 0, 5, 5) };

            return new StickyNotePanel(superSize, editButton, exitButton, mainViewer);
        }

        public static StickyNotePanel CreateEditor(Size superSize)
        {
            Label nullButton = new Label { Visible = false };
            Label applyButton = new Label { Text = "✓" };
            TextBox mainEditor = new TextBox { Multiline = true, Margin = new Padding(5) };
            mainEditor.Font = new Font(FontFamily.GenericSansSerif, Settings.Default.EditorFontSize);

            return new StickyNotePanel(superSize, nullButton, applyButton, mainEditor);
        }
    }
}
