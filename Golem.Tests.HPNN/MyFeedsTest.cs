using System;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.HPNN;
using Golem.PageObjects.HPNN.Tiles;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Golem.Tests.HPNN
{
    [TestFixture]
    public class MyFeedsTest : WebDriverTestBase
    {
        string env = Config.GetConfigValue("EnvUrl", "http://staging.hpnn.hp.com");

  
        [Test, Category("Smoke Test")]
        public void AddFeed()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            Element test = new Element(By.XPath("//div[text()='{0}']"));
            test.WithParam("linktext").Click();
            

            //string username = Config.GetConfigValue("SalesEmail", "7@hp.com");
            //string password = Config.GetConfigValue("SalesPassword", "asdf");
            // KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
            //     .LoginAs(username, password)
            //    .VerifyTiles(types);
        }


    }
}
