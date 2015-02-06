using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class BaseTile : BasePageObject
    {
        public string TileTitle;
        public Element RootElement;
        public By Title = By.ClassName("tile-title");
        public By Body = By.ClassName("tile-body");
        protected int x = 1;
        protected int y = 1;

        public BaseTile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override void WaitForElements()
        {
            RootElement.Verify().Visible();
            RootElement.FindElement(Title).Verify().Text(TileTitle);
            RootElement.FindElement(Body).Verify().Visible();
        }
    }
}
