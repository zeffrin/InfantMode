using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfantMode;
using System.Windows.Forms;

namespace InfantMode
{

    public delegate void KeyboardHookEventHandler(KeyState keyState, KeyEvent keyEvent);
    
    class KeyboardHook : IDisposable
    {
    
        private const int WH_KEYBOARD = 2;
        private const int WH_KEYBOARD_LL = 13;

        // Delegate declaration and public call back so can be set elsewhere in program
        public event KeyboardHookEventHandler KeyboardHookEvent;

        private int idHook;


        public KeyboardHook()
        {
            idHook = User32Dll.SetWindowsHookEx(WH_KEYBOARD_LL, InternalHookProc, IntPtr.Zero, 0);
        }

        private int InternalHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {

            var vkcode = System.Runtime.InteropServices.Marshal.ReadByte(lParam, 0);

            // pass control to our hook procedure, if enabled we wont pass message to windows
            // http://msdn.microsoft.com/en-us/library/windows/desktop/ms644985(v=vs.85).aspx specifies we must pass message on without processing if nCode < 0
            // let scroll lock through so can toggle Enabled
            if (nCode >= 0 && vkcode != 0x91 && Program.Enabled)
            {
                var keyState = (KeyState)wParam;
                var keyEvent = new KeyEvent()
                {
                    vkCode = vkcode,
                    scanCode = System.Runtime.InteropServices.Marshal.ReadByte(lParam, 1),
                    flags = System.Runtime.InteropServices.Marshal.ReadByte(lParam, 2),
                    time = System.Runtime.InteropServices.Marshal.ReadByte(lParam, 3),
                    dwExtraInfo = System.Runtime.InteropServices.Marshal.ReadIntPtr(lParam, 4)
                };

                if (KeyboardHookEvent != null)
                {
                    KeyboardHookEvent(keyState, keyEvent);

                    /* Leaving here incase I care about return values again later                     * 
                    foreach (KeyboardHookEventHandler hookProc in KeyboardHookEvent.GetInvocationList())
                        hookProc(keyState, keyEvent);
                    */
                }
                return 1;
            }
            
            return User32Dll.CallNextHookEx(idHook, nCode, wParam, lParam);
        }


        public void Dispose()
        {
            if (!User32Dll.UnhookWindowsHookEx(idHook))
                throw new Exception("Windows didnt let us unhook?!");
        }
    }
}
