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
        [Parallelizable]
        [Test, Category("My Feeds")]
        [Timeout(300)]
        public void SelectFeed()
        {
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .EnterSettings()
                .Enter_NewsFeeds()
                .ClearAllFeeds()
                .SelectFeed("CNN")
                .VerifyFeedSelected("CNN")
                .ClickDone()
                .personalNews
                .VerifyFeedItemPresent("CNN");
        }
        [Parallelizable]
        [Test, Category("My Feeds")]
        [Timeout(300)]
        [DependsOn("SelectFeed")]
        public void DeselectFeed()
        {
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .EnterSettings()
                .Enter_NewsFeeds()
                .UnSelectFeed("CNN")
                .ClickDone()
                .personalNews
                .VerifyFeedItemNotPresent("CNN");
        }

        [Test, Category("My Feeds")]
        [Row("http://invalidFeed.rss")]
        [Row("http://thegrio.com/")]
        [Row("http://www.cnn.com/services/rss")]
        [Row("feeds.nbcnews.com/feeds/weird")]
        [Row("http://feeds.nbcnews.com/feeds/datelinenbc")]
        [Row("blargh")]
        [Timeout(300)]
        public void AddInvalidRssFeed(string name)
        {
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .EnterSettings()
                .Enter_NewsFeeds()
                .AddFeed(name)
                .VerifyErrorMessageIsPresent("Cannot read RSS feed. Url is not a valid source or you have already added this RSS");
        }
    }
}
