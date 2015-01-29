using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class Stock : BasePageObject
    {
        public Element Container = new Element(By.Id("stock"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element StockName = new Element(By.ClassName("tile-large-text"));
        public Element UpdatedTime = new Element(By.ClassName("tile-subtext"));


        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Stock");
            Container.FindElement(StockName).Verify().Present();
            Container.FindElement(UpdatedTime).Verify().Present();
        }
    }
}
