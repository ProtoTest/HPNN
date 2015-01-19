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
    public class SaveUserProfile : MonitorBaseTest
    {

        private string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");
        private string username = Config.GetConfigValue("SaveUserEmail", "donavan.marais@hp.com");
        private string password = Config.GetConfigValue("SaveUserPassword", "fit.sun-25");

        [Test]
        public void SaveProfileChanges()
        {
            OpenPage<SSOLoginPage>(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish();


        }
    }
}
