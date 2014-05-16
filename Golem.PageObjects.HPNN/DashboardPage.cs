using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium.Interactions;
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
        protected string[] default_tile_title_list = { "Quick links", "In The News", "Your Personal News" };

        public Header header = new Header();

        public Element TileContainer = new Element("TileContainer", By.Id("container"));
        public Element MarqueeTile = new Element("Marquee tile", By.Id("marquee"));
        // Just some random tile to verify the tile page content is loaded
        public Element PersonalNewsTile = new Element("Personal News Tile", ByE.Text("Your Personal News"));
        public Element RemoveTileButton = new Element("RemoveTileButton", By.XPath("//div[@gridster-item='tile']//a[@class='remove-btn']"));

        public Element TileWithTitle(string title)
        {
            return new Element(By.XPath("//div[@gridster-item='tile' and .//h2[text()='" + title + "']]/div"));
        }

        public Element RemoveButtonForTile(string title)
        {
            return new Element(By.XPath("//div[@gridster-item='tile' and .//h2[text()='" + title + "']]//a[@class='remove-btn']"));
        }

        public IReadOnlyCollection<IWebElement> AllTilesOnPage()
        {
            return driver.FindElements(By.XPath("//div[@gridster-item='tile']"));
        }

        public static DashboardPage OpenDashboardPage()
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://katie-dev.lab.hpnewsnow.com/"));
            return new DashboardPage();
        }

        public SettingsModal EnterSettings()
        {
            return header.EnterSettings();
        }

        private DashboardPage VerifyTilewithTitleDisplayed(string tile_title)
        {
            TileWithTitle(tile_title).Verify().Visible();
            return this;
        }

        public DashboardPage VerifyDefaultTilesDisplayed()
        {
            MarqueeTile.Verify().Visible();

            foreach(string tile_title in default_tile_title_list)
            {
                VerifyTilewithTitleDisplayed(tile_title);
            }
            return this;
        }

        public DashboardPage VerifyTileNotPresent(string title)
        {
            TileWithTitle(title).Verify().Not().Visible();
            return this;
        }


        public override void WaitForElements()
        {
            header.WaitForElements();
            PersonalNewsTile.Verify().Visible();
            RemoveTileButton.Verify().Not().Visible();
        }

        public List<String> GetAllTileTitles()
         {
             List<String> allTileTitles = new List<String>();
             var tilesInContainer = TileContainer.FindElements(By.XPath("//div[@gridster-item='tile']//h2[@class='tile-title']"));
             foreach (var tile in tilesInContainer) {
                 allTileTitles.Add(tile.Text);
             }
             return allTileTitles;
         }

        public DashboardPage VerifyTilePosition(string title, int index)
        {

            var allTiles = TileContainer.FindElements(By.XPath("//div[@gridster-item='tile']//h2[@class='tile-title']"));
            var allElements = new List<Element>();
            foreach (var tile in allTiles)
            {
                allElements.Add(new Element(tile));
            }
           var orderedList = allElements.OrderBy(p => p.Location.Y).ThenBy(p => p.Location.X);
           
            Assert.AreEqual(title,orderedList.ElementAt(index).Text, "The tile title did not match");
            return this;
        }

        public Point GetTilePosition(string title)
        {
            return TileWithTitle(title).Location;
        }

        public DashboardPage VerifyTileSize(string title, int width, int height)
        {
            Assert.Contains(TileWithTitle(title).GetAttribute("class"),string.Format("is-w{0} is-h{1}", width, height));
            return this;
        }
    }
}
