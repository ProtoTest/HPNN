using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class KeyDates : BasePageObject
    {
        public Element Container = new Element(By.Id("upcoming-events"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Key Dates");
        }
    }
}
