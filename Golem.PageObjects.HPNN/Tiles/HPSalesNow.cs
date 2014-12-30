using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class HPSalesNow : BasePageObject
    {
        public Element Container = new Element(By.Id("hp-sales-now"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element InfoButton = new Element(By.ClassName("headerIcon"));
        public Element HotTopicsDropdown = new Element(By.ClassName("dropdown-toggle"));
        public Element ItemImage = new Element(By.ClassName("item-image"));
        public Element ItemTitle = new Element(By.ClassName("item-title"));
        public Element ItemNumber = new Element(By.ClassName("item-number"));

        
        
        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("HP Sales Now");
            Container.FindElement(InfoButton).Verify().Visible();
            Container.FindElement(HotTopicsDropdown).Verify().Visible();
            Container.FindElement(ItemImage).Verify().Present();
            Container.FindElement(ItemTitle).Verify().Present();
            Container.FindElement(ItemNumber).Verify().Present();
        }
    }
}
