using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace InfantMode.Test
{
    [TestClass]
    public class NotifyIconTests
    {

        private class testContextMenu : ContextMenu
        {
            protected override void Dispose(bool disposing)
            {
                NotifyIconDisposeTestResult.MenuItemDisposeCalled += 1;
                base.Dispose(disposing);
            }
        }

        
        private static class NotifyIconDisposeTestResult
        {
            public static int MenuItemDisposeCalled;
        }
        
        [TestMethod]
        public void NotifyIconDoesNotDisposesOfItsChildContextMenu()
        {
            NotifyIconDisposeTestResult.MenuItemDisposeCalled = 0;

            var ni = new NotifyIcon();
            ni.ContextMenu = new testContextMenu();
            ni.Dispose();
            Assert.AreEqual(0, NotifyIconDisposeTestResult.MenuItemDisposeCalled);
        }
    }
}
