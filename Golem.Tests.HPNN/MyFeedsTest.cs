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
        string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");

        [Parallelizable]
        [Test, Category("Smoke Test")]
        [Timeout(300)]
        public void LoginMonitorTest()
        {
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish().EnterSettings().Enter_NewsFeeds()
        }



    }
}
