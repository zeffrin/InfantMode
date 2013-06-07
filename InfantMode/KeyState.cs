using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfantMode
{
    public enum KeyState : int
    {
        /// <summary>
        /// WM_SYSKEYDOWN occurs when a key combined with Alt has been pressed
        /// </summary>
        WM_SYSKEYDOWN = 0x0104,

        /// <summary>
        /// WM_SYSKEYUP occurs when a key combined with Alt has been released
        /// </summary>
        WM_SYSKEYUP = 0x0105,

        /// <summary>
        /// WM_KEYDOWN occurs when a key has been pressed without Alt
        /// </summary>
        WM_KEYDOWN = 0x0100,

        /// <summary>
        /// WM_KEYDOWN occurs when a key has been released without Alt
        /// </summary>
        WM_KEYUP = 0x0101
    }
}
