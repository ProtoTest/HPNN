using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using MbUnit.Framework;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.HPNN;
using ProtoTest.Golem.Core;
using Gallio.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.Rest;
using RestSharp;

namespace Golem.Tests.HPNN
{
    [Parallelizable]
    class BrowserPageTest : WebDriverTestBase
    {
        string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");

        [FixtureInitializer]
        public void Init()
        {
            Config.Settings.runTimeSettings.LaunchBrowser = false;
            Config.Settings.sauceLabsSettings.SauceLabsUsername = "bkitchener";
            Config.Settings.sauceLabsSettings.SauceLabsAPIKey = "998969ff-ad37-4b2e-9ad7-edacd982bc59";
            Config.Settings.sauceLabsSettings.UseSauceLabs = true;
            Config.Settings.runTimeSettings.RunOnRemoteHost = true;
            Config.Settings.runTimeSettings.HighlightFoundElements = false;
            Config.Settings.runTimeSettings.DegreeOfParallelism = 1;
        }

        [Parallelizable]
        [Test, Category("Smoke Test")]
        [Timeout(300)]
        [Row(WebDriverBrowser.Browser.IE,"8","Windows 7")]
        [Row(WebDriverBrowser.Browser.IE, "9", "Windows 7")]
        public void VerifyBrowserNotSupportedRedirect(WebDriverBrowser.Browser browser,string version, string platform)
        {
            Config.Settings.runTimeSettings.Platform = platform;
            Config.Settings.runTimeSettings.Version = version;
            driver = new WebDriverBrowser().LaunchRemoteBrowser(browser,Config.Settings.sauceLabsSettings.SauceLabsUrl);
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .RedirectToBrowserNotSupportedPage();
        }

        [Parallelizable]
        [Test, Category("Smoke Test")]
        [Timeout(300)]
        [Row(WebDriverBrowser.Browser.Firefox, "", "Windows 7")]
        [Row(WebDriverBrowser.Browser.Chrome, "", "Windows 8")]
        [Row(WebDriverBrowser.Browser.IE, "10", "Windows 7")]
        [Row(WebDriverBrowser.Browser.IE, "11", "Windows 8.1")]
        public void VerifyBrowserIsSupported(WebDriverBrowser.Browser browser, string version, string platform)
        {
            Config.Settings.runTimeSettings.Platform = platform;
            Config.Settings.runTimeSettings.Version = version;
            driver = new WebDriverBrowser().LaunchRemoteBrowser(browser, Config.Settings.sauceLabsSettings.SauceLabsUrl);
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish();
        }

        [TearDown]
        public override void TearDownTestBase()
        {
            driver.Quit();
            base.TearDownTestBase();
        }
    }
}
