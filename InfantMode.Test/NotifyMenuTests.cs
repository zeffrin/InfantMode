using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace InfantMode.Test
{

    [TestClass]
    public class NotifyMenuTests
    {

        private class testMenuItem : MenuItem
        {
            public testMenuItem(string text) : base(text) { }
            public testMenuItem(string text, MenuItem[] menuItems) : base(text, menuItems) { }

            protected override void Dispose(bool disposing)
            {
                MenuItemDisposeTestResult.MenuItemDisposeCalled += 1;
                base.Dispose(disposing);
            }
        }

        private static class MenuItemDisposeTestResult
        {
            public static int MenuItemDisposeCalled;
        }
        
        [TestMethod]
        public void ContextMenuDisposeDisposesOfMenuItemsAndTheirChildrenAndGrandChildren()
        {
            MenuItemDisposeTestResult.MenuItemDisposeCalled = 0;

            var cm = new ContextMenu();
            cm.MenuItems.Add(new testMenuItem("outer", new MenuItem[] { new testMenuItem("blah", new MenuItem[] { new testMenuItem("grandchild") }) }));
            cm.Dispose();
            Assert.AreEqual(3, MenuItemDisposeTestResult.MenuItemDisposeCalled);
        }
    }
}
