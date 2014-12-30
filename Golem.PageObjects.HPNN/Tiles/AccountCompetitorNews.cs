using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class AccountCompetitorNews : BasePageObject
    {
        public Element Container = new Element(By.Id("competitornews"));
        public Element Link = new Element(By.ClassName("tile-link"));
        public Element paginationLinks = new Element(By.ClassName("standard-carousel-pager-controls"));

        public override void WaitForElements()
        {
            Container.FindElement(Link).Verify().Present();
            Container.FindElement(paginationLinks).Verify().Present();
        }

    }
}
