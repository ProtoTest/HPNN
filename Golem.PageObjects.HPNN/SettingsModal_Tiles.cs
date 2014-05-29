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
    public class SettingsModal_Tiles : BasePageObject
    {
        SettingsModal_Sidebar sidebar = new SettingsModal_Sidebar();

        Element PageHeading_Label = new Element("News Feeds Heading Label", By.LinkText("Activate Tiles"));

        public Element ButtonForTileType(string name)
        {
            return new Element(By.XPath("//div[contains(@id,'"+name+"')]"));
        }

        public Element ButtonForSize(string size)
        {
            return new Element(By.XPath("//li[contains(@class,'"+size+"')]"));
        }

        public EditDashboardPage AddTileWithType(string type, string size)
        {
            // Specific id for 'In The News' tile needs to be customized
            if(type.Equals("In The News"))
            {
                type = "News";
            }
            else if(type.Equals("HP Sales Now"))
            {
                type = "hp-sales-now";
            }
            else if(type.Equals("Jobs @HP"))
            {
                type = "jobs-at-hp";
            }
            else if (type.Equals("Most Read"))
            {
                type = "most-read";
            }
            else if (type.Equals("Most Shared"))
            {
                type = "most-shared";
            }
            else if (type.Equals("Most Discussed"))
            {
                type = "most-discussed";
            }
            else if (type.Equals("Most Liked"))
            {
                type = "most-liked";
            }
            else if (type.Contains("Product Show"))
            {
                type = "product-showcase";
            }
            else if (type.Equals("Upcoming Events"))
            {
                type = "Upcoming-events";
            }
            else if (type.Equals("Upcoming Sales Events"))
            {
                type = "Upcoming Events for Sales";
            }
            else if (type.Equals("Innovation @HP"))
            {
                type = "hp-innovation-blog";
            }
            
            

            ButtonForTileType(type).WaitUntil().Visible().Click();
            ButtonForSize(size).WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }

        public EditDashboardPage AddWeatherTile(string size, string location)
        {
            ButtonForTileType("Weather").WaitUntil().Visible().Click();
            ButtonForSize(size).WaitUntil().Visible().Click();
            PersonalizeWeatherPage personalize_weather = new PersonalizeWeatherPage();
            personalize_weather.EnterLocation(location).ClickAddMyTile();

            return new EditDashboardPage();
        }

        public EditDashboardPage AddStockQuoteTile(string size, string symbol)
        {
            ButtonForTileType("Stock Quote").WaitUntil().Visible().Click();
            ButtonForSize(size).WaitUntil().Visible().Click();
            Element symbolField = new Element(By.XPath("//input[contains(@title,'Stock Quote')]"));
            Element doneButton = new Element(By.LinkText("I'm Done. Add My Tile"));
            symbolField.SendKeys(symbol);
            doneButton.Click();
            return new EditDashboardPage();
        }

        public override void WaitForElements()
        {
            PageHeading_Label.Verify().Visible();
        }

    }
}
