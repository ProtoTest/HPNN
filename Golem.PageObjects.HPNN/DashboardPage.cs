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

        public Header header = new Header();
        TutorialOverview tutorial = new TutorialOverview();
        public Element ClosePreviewLink = new Element("CLosePreviewLink", By.Id("m_pnlPreviewInfo"));
        public Element TileContainer = new Element("TileContainer", By.Id("container"));
        public Element MarqueeTile = new Element("Marquee tile", By.ClassName("slides"));
        // Just some random tile to verify the tile page content is loaded
        public Element PersonalNewsTile = new Element("Personal News Tile", ByE.Text("Your Personal News"));
        public Element RemoveTileDropdown = new Element("RemoveTile Dropdown", By.XPath("//div[@gridster-item='tile']//div[contains(@class, 'dropdown')]"));
        public Element LoadingAnimation = new Element("Loading Animation", By.Id("preloadAnim"));

        public Element TileWithTitle(string title)
        {
            return new Element(By.XPath("//div[@gridster-item='tile' and .//h2[text()='" + title + "']]/div"));
        }

        public Element RemoveButtonForTile(string title)
        {
            Element dropdown = new Element(By.XPath("//div[@gridster-item='tile' and .//h2[text()='" + title + "']]//div[contains(@class, 'dropdown')]/a"));
            dropdown.Click();
            return new Element(By.XPath("//div[@gridster-item='tile' and .//h2[text()='" + title + "']]//li[@id='tile-delete']/a"));
        }

        public IReadOnlyCollection<IWebElement> AllTilesOnPage()
        {
            return driver.FindElements(By.XPath("//div[@gridster-item='tile']"));
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

        public DashboardPage VerifyDefaultTilesDisplayed(string[] TileNames)
        {
            MarqueeTile.Verify().Visible();

            foreach(string tile_title in TileNames)
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
            Element closeButton = new Element(By.LinkText("Close"));
            closeButton.Click();
            driver.Navigate().Refresh();
            LoadingAnimation.WaitUntil().Not(60).Visible();
            if (tutorial.OverviewPanel.Displayed)
                tutorial.CloseTutorial();
            header.WaitForElements();
            PersonalNewsTile.Verify(60).Visible();
            RemoveTileDropdown.Verify(60).Not().Visible();
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
            var orderedList = allElements.OrderBy(element => element.Location.Y).ThenBy(element => element.Location.X);
           
            Assert.AreEqual(title,orderedList.ElementAt(index).Text, "The tile was not in the expected position of " + index);
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

        public static DashboardPage OpenDashboardPageViaKentico()
        {
            return KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(Config.Settings.runTimeSettings.EnvironmentUrl);
        }

        public DashboardPage CloseTutorial()
        {
            TutorialOverview overview = new TutorialOverview();
            overview.CloseTutorial();
            return new DashboardPage();
        }
    }
}
