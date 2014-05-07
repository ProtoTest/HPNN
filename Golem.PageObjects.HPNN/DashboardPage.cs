using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{
    public class DashboardPage : BasePageObject
    {
        Header header = new Header();
        Element PersonalNewsTile = new Element("Personal News Tile", ByE.Text("Your Personal News"));

        public static DashboardPage OpenDashboardPage()
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://katie-dev.lab.hpnewsnow.com/"));
            return new DashboardPage();
        }

        public SettingsModal EnterSettings()
        {
            return header.EnterSettings();
        }
        public override void WaitForElements()
        {
            header.WaitForElements();
            PersonalNewsTile.Verify().Visible();
        }
    }
}
