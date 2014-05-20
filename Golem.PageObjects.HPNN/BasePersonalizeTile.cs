using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{

    public class BasePersonalizeTile : BasePageObject
    {
        public SettingsModal_Sidebar sidebar = new SettingsModal_Sidebar();
        public Element page_title = new Element("Personalize Tile Title", ByE.Text("Personalize Your Tile"));
        public Button back_btn = new Button("Back Button", By.ClassName("personalize-back-button"));
        public Button done_add_tile_btn = new Button("I'm Done. Add my Tile Button", By.PartialLinkText("Add My Tile"));

        public EditDashboardPage ClickAddMyTile()
        {
            done_add_tile_btn.Click();
            return new EditDashboardPage();
        }

        public SettingsModal_Tiles ClickBack()
        {
            back_btn.Click();
            return new SettingsModal_Tiles();
        }

        public override void WaitForElements()
        {
            page_title.Verify().Visible();
            back_btn.Verify().Visible();
            done_add_tile_btn.Verify().Visible();
        }
    }
}
