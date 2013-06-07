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
        /// The main entry point for the application.
        /// </summary>

        static KeyboardHook keyboardHook;

        public static bool Enabled
        {
            get
            {
                return Control.IsKeyLocked(Keys.Scroll);
            }
        }
       
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            NotifyIcon notifyIcon;
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Resources.AppIcon;
            notifyIcon.Text = "InfantMode";

            var notifyMenu = new NotifyMenu();
            notifyIcon.ContextMenu = notifyMenu.ContextMenu;

            notifyIcon.Visible = true;

            keyboardHook = new KeyboardHook();
            //keyboardHook.KeyboardHookEvent += new KeyboardHookEventHandler(InterceptAllKeys);
            
            Application.Run();

            keyboardHook.Dispose();
            notifyMenu.Dispose(); // NotifyIcon doesn't dispose it's child ContextMenu - InfantMode.Test.NotifyIconTests.NotifyIconDoesNotDisposesOfItsChildContextMenu
            notifyIcon.Dispose();
        }

    }
}
