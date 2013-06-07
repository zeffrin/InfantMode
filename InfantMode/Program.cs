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
            
            NotifyIcon AppIcon;
            AppIcon = new NotifyIcon();
            AppIcon.Icon = Resources.AppIcon;
            AppIcon.Text = "InfantMode";

            AppIcon.Visible = true;

            keyboardHook = new KeyboardHook();
            //keyboardHook.KeyboardHookEvent += new KeyboardHookEventHandler(InterceptAllKeys);
            
            Application.Run();

            keyboardHook.Dispose();
            AppIcon.Dispose();
        }

    }
}
