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
    public class DashboardPage : BasePageObject
    {
       // When default tiles are established, add 'em here
        string[] default_tile_title_list = { "Quick links", "In The News", "Your Personal News" };

        Header header = new Header();

        // Just some random tile to verify the tile page content is loaded
        Element PersonalNewsTile = new Element("Personal News Tile", ByE.Text("Your Personal News"));

        public static DashboardPage OpenDashboardPage()
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://katie-dev.lab.hpnewsnow.com/"));
            return new DashboardPage();
        }

        public SettingsModal EnterSettings()
        {
            return header.EnterSettings();
        }

        private void VerifyTilewithTitleDisplayed(string tile_title)
        {
            string xpath = String.Format("//div[contains(@class,'tile-presentation-controller')]/div/h2[text()='{0}']", tile_title);

            Element tile = new Element("Tile Title", By.XPath(xpath));
            tile.Verify().Visible();
        }

        public DashboardPage VerifyDefaultTilesDisplayed()
        {
            // marquee tile does not have a title, manually verify
            new Element("Marquee tile", By.Id("marquee")).Verify().Visible();

            foreach(string tile_title in default_tile_title_list)
            {
                VerifyTilewithTitleDisplayed(tile_title);
            }
            return this;
        }

        public override void WaitForElements()
        {
            header.WaitForElements();
            PersonalNewsTile.Verify().Visible();
        }
    }
}
