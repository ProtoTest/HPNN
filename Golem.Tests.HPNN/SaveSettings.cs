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
    [TestFixture, Parallelizable]
    public class SaveSettings : WebDriverTestBase
    {
        string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
        string password = Config.GetConfigValue("AdminPassword", "Sanders76");

        [Test]
        public void SaveData()
        {
            String tile_under_test = "In The News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .RemoveTileIfPresent(tile_under_test)
                .EnterSettings()
                .Enter_NewsFeeds()
                .ClearAllFeeds()
                .AddFeed("CNN")
                .ClickDone();
        }

        [Test, DependsOn("SaveData")]
        public void VerifyDataSaved()
        {
            String tile_under_test = "In The News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .VerifyTileNotPresent(tile_under_test)
                .personalNews.VerifyFeedItemPresent("CNN");
        }
    }
}
