using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class DicussedOnOneHP : BasePageObject
    {
        public Element Container = new Element(By.Id("onehphashtags"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element LockButton = new Element(By.ClassName("vpn-lock"));
        public Element Text = new Element(By.ClassName("ng-binding"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Discussed on OneHP");
            Container.FindElement(LockButton).Verify().Visible();
            Container.FindElement(Text).Verify().Visible();
        }
    }
}
