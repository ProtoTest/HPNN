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
    
    public class SettingsModal : BasePageObject
    {
        SettingsModal_Sidebar sidebar = new SettingsModal_Sidebar();

        public SettingsModal_YourInformation Enter_YourInformation()
        {
            sidebar.YourInformation_Link.Click();
            return new SettingsModal_YourInformation();
        }
        public SettingsModal_NewsFeeds Enter_NewsFeeds()
        {
            sidebar.NewsFeeds_Link.Click();
            return new SettingsModal_NewsFeeds();
        }

        public SettingsModal_Tiles Enter_Tiles()
        {
            sidebar.Tiles_Link.Click();
            return new SettingsModal_Tiles();
        }
        public DashboardPage RearrangeTiles()
        {
            sidebar.RearrangeTiles_Button.Click();
            return new DashboardPage();
        }

        public override void WaitForElements()
        {
            
        }
    }
}
