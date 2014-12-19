using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN.SettingsModal;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.UIElements;
using ProtoTest.Golem.WebDriver.UIElements.Types;

namespace Golem.PageObjects.HPNN
{

    public class BasePersonalizeTile : BasePageObject
    {
        public Sidebar sidebar = new Sidebar();
        public Element page_title = new Element("Personalize Tile Title", ByE.Text("Personalize Your Tile"));
        public Button back_btn = new Button("Back Button", By.LinkText("Back"));
        public Button done_add_tile_btn = new Button("DoneButton", By.PartialLinkText("Done"));
        public Element AddButton = new Element("AddButton",By.LinkText("Add"));


        public EditDashboardPage ClickAddMyTile()
        {
            done_add_tile_btn.Click();
            return new EditDashboardPage();
        }

        public MyTiles ClickBack()
        {
            back_btn.Click();
            return new MyTiles();
        }

        public override void WaitForElements()
        {
            page_title.Verify().Visible();
            back_btn.Verify().Visible();
            done_add_tile_btn.Verify().Visible();
        }
    }
}
