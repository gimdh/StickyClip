using StickyClip.Properties;
using System;
using System.Windows.Forms;

namespace StickyClip
{
    public class TrayAppContext : ApplicationContext
    {
        NotifyIcon trayIcon;
        ContextMenu contextMenu;

        public TrayAppContext()
        {
            contextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Exit", Exit)
                });

            trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = contextMenu,
                Visible = true
            };
        }


        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
