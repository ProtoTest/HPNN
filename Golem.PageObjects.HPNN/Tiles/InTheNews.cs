using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class InTheNews : BasePageObject
    {
        public Element Container = new Element(By.Id("in-the-news"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Image = new Element(By.ClassName("tile-image"));
        public Element Link = new Element(By.ClassName("tile-link"));
        public Element Text = new Element(By.ClassName("tile-text"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("In The News");
            Container.FindElement(Image).Verify().Visible();
            Container.FindElement(Link).Verify().Visible();
            Container.FindElement(Text).Verify().Visible();
        }
    }
}
