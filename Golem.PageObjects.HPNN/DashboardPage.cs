﻿using System;
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
        public Element TitleSlideImage = new Element("Title slide image", By.ClassName("tile-slide-image"));
        // Just some random tile to verify the tile page content is loaded
        public Element PersonalNewsTile = new Element("Personal News Tile", ByE.Text("Your Personal News"));
        public Element RemoveTileButton = new Element("RemoveTileButton", By.XPath("//div[@gridster-item='tile']//a[@class='remove-btn']"));

        public Element TileWithTitle(string title)
        {
            return new Element(By.XPath("//div[@gridster-item='tile' and .//h2[text()='" + title + "']]"));
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

        public Point GetTilePosition(string title)
        {
            return TileWithTitle(title).Location;
        }

    }
}
