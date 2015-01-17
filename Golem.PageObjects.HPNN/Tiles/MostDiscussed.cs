using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class MostDiscussed : BasePageObject
    {
        public Element Container = new Element(By.Id("Story-most-discussed"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Link = new Element(By.ClassName("tile-text"));
        public Element Image = new Element(By.ClassName("tile-image"));
        public Element Number = new Element(By.ClassName("tile-number"));

        // public PaginationControls PaginationControls;

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Visible();
            Container.FindElement(Image).Verify().Present();
            //Container.FindElement(Link).Verify().Present();
            //Container.FindElement(Number).Verify().Present();
            //PaginationControls = new PaginationControls(Container, 4);

        }
    }
}
