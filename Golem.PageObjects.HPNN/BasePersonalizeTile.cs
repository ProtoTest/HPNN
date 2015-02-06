using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN.SettingsModal;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{

    public class BasePersonalizeTile : BasePageObject
    {
        public Sidebar sidebar = new Sidebar();
        public Element PageTitle = new Element("Personalize Tile Title", ByE.Text("Personalize Your Tile"));
        public Button BackButton = new Button("Back Button", By.LinkText("Back"));
        public Button DoneButton = new Button("DoneButton", By.PartialLinkText("Done"));
        public Element AddButton = new Element("AddButton",By.LinkText("Add"));
        public Element RemoveButton = new Element(By.LinkText("Remove"));

        public EditDashboardPage ClickAddMyTile()
        {
            DoneButton.Click();
            return new EditDashboardPage();
        }

        public MyTiles ClickBack()
        {
            BackButton.Click();
            return new MyTiles();
        }

        public override void WaitForElements()
        {
            PageTitle.Verify().Visible();
            BackButton.Verify().Visible();
            DoneButton.Verify().Visible();
        }
    }
}
