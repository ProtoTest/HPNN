using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class CurrentFYPipeline : BasePageObject
    {
        public Element Container = new Element(By.Id("sfdc-pipeline-forecast-by-gbu"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Image = new Element(By.XPath(".//a"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Current FY Pipeline by GBU");
            Container.FindElement(Image).Verify().Present();
        }
    }
}
