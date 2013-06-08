using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfantMode
{

        
    class NotifyMenu : IDisposable
    {
        public ContextMenu ContextMenu { get; set; }

        public event EventHandler Exit_Click;
        public event EventHandler About_Click;

        public NotifyMenu()
        {
            var menuItems = new MenuItem[] {
                new MenuItem("About", About_OnClick),
                new MenuItem("Exit", Exit_OnClick)
            };
            var m = new MenuItem();
            ContextMenu = new ContextMenu(menuItems);
        }

        private void About_OnClick(object sender, EventArgs e)
        {
            About_Click(sender, e);
        }

        private void Exit_OnClick(object sender, EventArgs e)
        {
            Exit_Click(sender, e);
        }

        public void Dispose()
        {
            // ContextMenu handles disposing all of it's child menu items
            // InfantMode.Test.NotifyMenuTests.ContextMenuDisposeDisposesOfMenuItemsAndTheirChildrenAndGrandChildren
            ContextMenu.Dispose();
        }
    }
}
