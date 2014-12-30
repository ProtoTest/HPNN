using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class MyComp : BasePageObject
    {
        public Element Container = new Element(By.Id("my-comp"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element LockButton = new Element(By.ClassName("vpn-lock"));
        public Element PrivacyCurtain = new Element(By.ClassName("privacycurtain"));
        public Element MyCompText = new Element(By.ClassName("privacycurtain-content"));


        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("MyComp");
            Container.FindElement(LockButton).Verify().Present();
            Container.FindElement(PrivacyCurtain).Verify().Visible();
            Container.FindElement(MyCompText).Verify().Present();
        }
    }
}
