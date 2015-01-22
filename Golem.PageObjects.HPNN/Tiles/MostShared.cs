using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class MostShared : BasePageObject
    {
        public Element Container = new Element(By.Id("Story-most-shared"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Image = new Element(By.ClassName("tile-image"));
        public Element Number = new Element(By.ClassName("tile-number"));
        public Element Text = new Element(By.ClassName("tile-text"));


        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Most Shared");
            Container.FindElement(Image).Verify().Present();
            Container.FindElement(Number).Verify().Present();
            Container.FindElement(Text).Verify().Present();
        }
    }
}
