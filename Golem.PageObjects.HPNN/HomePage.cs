using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements;

namespace Golem.PageObjects.HPNN
{
    public class HomePage : BasePageObject
    {
        public static HomePage OpenHomePage()
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://katie-dev.lab.hpnewsnow.com/"));
            return new HomePage();
        }

        public override void WaitForElements()
        {
            // Implement me
        }
    }
}
