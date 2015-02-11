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
        public Element Date = new Element(By.ClassName("tile-event-date-day"));
        public Element EventName = new Element(By.ClassName("tile-event-name"));
        public Element PaginationContainer = new Element(By.ClassName("standard-carousel-pager-controls"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Key Dates");
            Container.FindElement(EventName).Verify().Present();
            Container.FindElement(PaginationContainer).Verify().Present();
        }
    }
}
