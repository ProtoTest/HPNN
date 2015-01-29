using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class MegOnLinkedIn : BasePageObject
    {
        public Element Container = new Element(By.Id("meg-on-linkedin"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Image = new Element(By.XPath("//*[contains(@class,'image')]"));
        public Element Link = new Element(By.ClassName("tile-link"));
        public Element Text = new Element(By.ClassName("tile-text"));
        public Element PaginationControls = new Element(By.ClassName("standard-carousel-pager-controls"));
        public Element PageOneLink = new Element(By.LinkText("1"));
        public Element PageTwoLink = new Element(By.LinkText("2"));
        public Element PageThreeLink = new Element(By.LinkText("3"));
        public Element PageFourLink = new Element(By.LinkText("4"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Meg on LinkedIn");
            Container.FindElement(Image).Verify().Present();
            Container.FindElement(Link).Verify().Present();
            Container.FindElement(Text).Verify().Present();

        }
    }
}
