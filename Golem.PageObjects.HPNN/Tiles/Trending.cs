using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class Trending : BasePageObject
    {
        public Element Container = new Element(By.Id("trending"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Image = new Element(By.ClassName("image"));
        public Element Link = new Element(By.ClassName("link-tile"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Trending Today");
            Container.FindElement(Image).Verify().Visible();
            Container.FindElement(Link).Verify().Visible();
        }

      
    }
}
