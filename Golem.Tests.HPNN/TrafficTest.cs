using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
    class TrafficTest : WebDriverTestBase
    {
        //[FixtureInitializer]
        //public void init()
        //{
        //    Config.Settings.httpProxy.startProxy = true;
        //    Config.Settings.httpProxy.useProxy = true;
        //    Config.Settings.httpProxy.validateTraffic = true;
        //}

        [Test]
        [Repeat(20)]
        public void TestLoginFailures()
        {
            driver.Sleep(1000);
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            String tile_under_test = "In The News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password);
        }
    }
}
