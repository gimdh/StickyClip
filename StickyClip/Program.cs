using System;
using System.Windows.Forms;

namespace StickyClip
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var stickyNoteManager = new StickyNoteManager())
            {
                Application.Run(new TrayAppContext());
            }
        }
    }
}
