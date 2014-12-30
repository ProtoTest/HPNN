using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class SFDCPipeline : BasePageObject
    {
        public Element Container = new Element(By.Id("sfdc-pipeline-forecast-by-quarter"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Image = new Element(By.Id("#chart2"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("SFDC Pipeline Forecast by Quarter");
            Container.FindElement(Image).Verify().Visible();
        }
    }
}
