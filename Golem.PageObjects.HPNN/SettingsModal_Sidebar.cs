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

    public class SettingsModal_Sidebar : BasePageObject
    {
        public Link YourInformation_Link = new Link("Your Information Link", By.PartialLinkText("Your Information"));
        public Link NewsFeeds_Link = new Link("News Feeds Links", By.PartialLinkText("News Feeds"));
        public Link Tiles_Link = new Link("Tiles Links", By.LinkText("Tiles"));

        public Button RearrangeTiles_Button = new Button("Re-arrange tiles Button", By.Id("reorder"));
        public Button Cancel_Button = new Button("Cancel Button", ByE.Text("Cancel"));

        public override void WaitForElements()
        {
            YourInformation_Link.Verify().Visible();
            NewsFeeds_Link.Verify().Visible();
            Tiles_Link.Verify().Visible();
            RearrangeTiles_Button.Verify().Visible();
            Cancel_Button.Verify().Visible();
        }
    }
}
