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
    public class SettingsModal_Tiles : BasePageObject
    {
        SettingsModal_Sidebar sidebar = new SettingsModal_Sidebar();

        Element PageHeading_Label = new Element("News Feeds Heading Label", By.LinkText("Activate Tiles"));

        public override void WaitForElements()
        {
            PageHeading_Label.Verify().Visible();
        }
    }
}
