using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StickyClip
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, GetGUID()))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (var stickyNoteManager = new StickyNoteManager())
                {
                    Application.Run(new TrayAppContext());
                }
            }

        }

        private static string GetGUID()
        {
            return ((GuidAttribute)typeof(Program).Assembly
                .GetCustomAttributes(typeof(GuidAttribute), true).GetValue(0)).Value;
        }
    }
}
