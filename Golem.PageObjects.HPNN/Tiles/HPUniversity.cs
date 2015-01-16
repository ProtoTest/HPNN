using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class HPUniversity : BasePageObject
    {
        public Element Container = new Element("Container", By.Id("hp-university"));

        public Element Title = new Element("Title", By.ClassName("tile-title"));

        public Element VPNIcon = new Element("VPNICon", By.ClassName("vpn-lock"));

        public Element Date = new Element("Date", By.XPath("//span[@class='ng-binding']"));

        public Element LinkText = new Element("LinkText", By.XPath("//a[@target='_blank']"));

        public Element Pagination = new Element("Pagination", By.ClassName("standard-carousel-pager-controls"));



        public override void WaitForElements()
        {
            Container.FindElement(Title).Verify().Visible();
            Container.FindElement(VPNIcon).Verify().Visible();
            Container.FindElement(Date).Verify().Present();
            Container.FindElement(LinkText).Verify().Present();
            Container.FindElement(Pagination).Verify().Present();
        }
    }
}
