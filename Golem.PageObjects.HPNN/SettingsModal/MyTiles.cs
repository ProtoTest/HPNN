using System.Threading;
using Golem.PageObjects.HPNN.Tiles;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.SettingsModal
{
    public class MyTiles : BasePageObject
    {
        Sidebar sidebar = new Sidebar();
        Element symbolField = new Element(By.Id("select-company"));
        Element addButton = new Element(By.LinkText("Add Stock"));
        Element doneButton = new Element(By.LinkText("Done"));
        Element PageHeading_Label = new Element("My Tiles Heading", ByE.Text("My Tiles"));
        public Element PersonalizeButton = new Element("PersonalizeButton", By.Id("config-btn"));

        public Element ButtonForTileType= new Element(By.XPath("//div[contains(@id,'{0}')]"));
    
        public Element ButtonForSize  = new Element(By.XPath("//li[contains(@class,'{0}')]"));
        

        public EditDashboardPage Personalize()
        {
            PersonalizeButton.WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }

        public EditDashboardPage AddTileWithType(string type, string size)
        {
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
            else if (type.Equals("Innovation @HP Labs Blog"))
            {
                type = "hp-innovation-blog";
            }
            else if (type.Equals("Quick Links"))
            {
                type = "quick-links";
            }
            else if (type.Equals("Sales Quick Links"))
            {
                type = "quick-link-for-sales";
            }
            else if (type.Equals("MyComp"))
            {
                type = "icon-My Comp";
            }
            else if (type.Contains("Showcase"))
            {
                type = "icon-innovation-showcase";
            }
            else if (type.Contains("Current FY Pipeline"))
            {
                type = "icon-sfdc-pipeline-forecast-by-gbu";
            }
            else if (type.Contains("Key Dates"))
            {
                type = "icon-Upcoming-events";
            }
            else if (type.Contains("Sales Essentials Headlines"))
            {
                type = "icon-Sales Essentials Headlines";
            }
            ButtonForTileType.WithParam(type).WaitUntil().Visible().Click();
            ButtonForSize.WithParam(size).WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }

        public EditDashboardPage AddWeatherTile(string size, string location)
        {
            ButtonForTileType.WithParam("Weather").WaitUntil().Visible().Click();
            ButtonForSize.WithParam(size).WaitUntil().Visible().Click();
            PersonalizeWeatherPage personalize_weather = new PersonalizeWeatherPage();
            personalize_weather.EnterLocation(location).ClickAddMyTile();

            return new EditDashboardPage();
        }

        public EditDashboardPage AddStockQuoteTile(string symbol, string size)
        {
            ButtonForTileType.WithParam("Stock").WaitUntil().Visible().Click();
            ButtonForSize.WithParam(size).WaitUntil().Visible().Click();

            symbolField.WaitUntil().Visible().SendKeys(symbol);
            Thread.Sleep(2000);
            symbolField.SendKeys(Keys.Down + Keys.Enter);
            addButton.Click();
            doneButton.Click();
            return new EditDashboardPage();
        }

        public PersonalizeAccountNews AddAccountCompetitorTile(string size)
        {
            ButtonForTileType.WithParam("Account Competitor News").WaitUntil().Visible().Click();
            ButtonForSize.WithParam(size).WaitUntil().Visible().Click();
 
            return new PersonalizeAccountNews();
        }

        public PersonalizeAccountNews AddAccountNews(string size)
        {
            ButtonForTileType.WithParam("Account News").WaitUntil().Visible().Click();
            ButtonForSize.WithParam(size).WaitUntil().Visible().Click();

            return new PersonalizeAccountNews();
        }


        public override void WaitForElements()
        {
            PageHeading_Label.Verify().Visible();
        }

        public EditDashboardPage AddQuickLinksTile(string tileUnderTest, string format)
        {

            ButtonForTileType.WithParam("quick-link-for-sales").WaitUntil().Visible().Click();
            ButtonForSize.WithParam(format).WaitUntil().Visible().Click();
            doneButton.WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }
    }
}
