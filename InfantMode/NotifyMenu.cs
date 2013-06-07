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

        public NotifyMenu()
        {
            var menuItems = new MenuItem[] { new MenuItem("Exit", Exit_OnClick) };
            var m = new MenuItem();
            ContextMenu = new ContextMenu(menuItems);
        }

        private void Exit_OnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Dispose()
        {
            // ContextMenu handles disposing all of it's child menu items
            // InfantMode.Test.NotifyMenuTests.ContextMenuDisposeDisposesOfMenuItemsAndTheirChildrenAndGrandChildren
            ContextMenu.Dispose();
        }
    }
}
