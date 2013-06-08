using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfantMode
{
    static class Program
    {
        /// <summary>
        /// TODO track enabled state internally and make scroll lock toggle an option, click/double click sys tray toggle option too
        /// </summary>
        public static bool Enabled
        {
            get
            {
                return Control.IsKeyLocked(Keys.Scroll);
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            NotifyIcon notifyIcon;
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Resources.AppIcon;
            notifyIcon.Text = "InfantMode";
            notifyIcon.DoubleClick += new EventHandler(NotifyIcon_DoubleClick);

            var notifyMenu = new NotifyMenu();
            notifyMenu.About_Click += new EventHandler(NotifyMenu_About);
            notifyMenu.Exit_Click += new EventHandler(NotifyMenu_Exit);


            notifyIcon.ContextMenu = notifyMenu.ContextMenu;

            notifyIcon.Visible = true;

            var keyboardHook = new KeyboardHook();
            //keyboardHook.KeyboardHookEvent += new KeyboardHookEventHandler(InterceptAllKeys);
            
            Application.Run();

            keyboardHook.Dispose();
            notifyMenu.Dispose(); // NotifyIcon doesn't dispose it's child ContextMenu - InfantMode.Test.NotifyIconTests.NotifyIconDoesNotDisposesOfItsChildContextMenu
            notifyIcon.Dispose();
        }

        private static void NotifyMenu_About(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // TODO need to start tracking enabled internally
            // and then make scroll lock mode an option
            // Enabled = !Enabled;
        }

        private static void NotifyMenu_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
