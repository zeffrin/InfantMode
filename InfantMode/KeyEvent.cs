using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfantMode
{
    /// <summary>
    /// Holds data from KBDDLHOOKSTRUCT
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms644967(v=vs.85).aspx
    /// </summary>
    public struct KeyEvent
    {
        /// <summary>
        /// Virtual Keycode
        /// </summary>
        public Int32 vkCode;
        
        /// <summary>
        /// Hardware scancode for key (OEM dependant)
        /// </summary>
        public Int32 scanCode;
        
        
        /// <summary>
        /// Bitwise flags - The extended-key flag, event-injected flag, context code, and transition-state flag.
        /// </summary>
        public Int32 flags;
        
        /// <summary>
        /// Timestamp for the message
        /// </summary>
        public Int32 time;

        /// <summary>
        /// Pointer to more info about this message
        /// </summary>
        public IntPtr dwExtraInfo;
    }
}
