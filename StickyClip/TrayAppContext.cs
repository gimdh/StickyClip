﻿using StickyClip.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

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
