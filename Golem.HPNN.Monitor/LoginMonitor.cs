using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.HPNN;
using Golem.PageObjects.HPNN.Tiles;
using MbUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Gallio.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Golem.HPNN.Monitor
{
    [Parallelizable]
    public class LoginMonitor : MonitorBaseTest
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
                .WaitForLoadingAnimationToVanish();
        }

    }
}
