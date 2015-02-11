using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class PaginationControls : BasePageObject
    {
        public Element PaginationContainer = new Element(By.ClassName("standard-carousel-pager-controls"));
        public Element PageLink = new Element(By.LinkText("{0}"));
        public Element PageOneLink = new Element(By.LinkText("1"));
        public Element PageTwoLink = new Element(By.LinkText("2"));
        public Element PageThreeLink = new Element(By.LinkText("3"));
        public Element PageFourLink = new Element(By.LinkText("4"));


        private Element Container;
        private int numOfPages;

        public PaginationControls(By container, int numOfPages)
        {
            this.Container = new Element(container);
            this.numOfPages = numOfPages;
        }


        public override void WaitForElements()
        {
            Container.FindElement(PaginationContainer).Verify().Visible();
            Container.FindElement(PageLink.WithParam("1")).Verify().Visible();
            Container.FindElement(PageLink.WithParam(numOfPages.ToString())).Verify().Visible();

        }

    }
}
