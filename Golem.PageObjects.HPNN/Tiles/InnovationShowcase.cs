using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class InnovationShowcase : BasePageObject
    {
        public Element Container = new Element(By.Id("innovation-showcase"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));

        public Element Link = new Element(By.ClassName("tile-link"));
        public Element Image = new Element(By.ClassName("news-image"));
        public Element Text = new Element(By.ClassName("tile-text"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Innovation Showcase");
            Container.FindElement(Image).Verify().Present();
           // if(this.x > 1 || y > 1)
                Container.FindElement(Text).Verify().Present();
        }

     
    }
}
