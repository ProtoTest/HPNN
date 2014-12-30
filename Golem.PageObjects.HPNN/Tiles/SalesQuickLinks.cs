using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class SalesQuickLinks : BasePageObject
    {

        public Element Container = new Element(By.Id("quick-link-for-sales"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Link = new Element(By.ClassName("tile-link"));


        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Sales Quick Links");
            Container.FindElement(Link).Verify().Present();
        }
    }
}
