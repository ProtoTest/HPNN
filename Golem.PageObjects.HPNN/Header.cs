using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.UIElements;
using ProtoTest.Golem.WebDriver.UIElements.Types;

namespace Golem.PageObjects.HPNN
{
    public class Header : BasePageObject
    {
        Element SiteTitle_Label = new Element("Site Title", ByE.Text("HP News Now"));
        Field Search_Field = new Field("Search box", By.Id("p_lt_ctl01_SearchBox_txtWord"));
        Link Settings_Link = new Link("Settings Link", By.Id("settings-link"));
        Element HP_Logo_Link = new Element("HP Logo/Link", By.ClassName("logo"));

        public SettingsModal.SettingsModal EnterSettings()
        {
            Settings_Link.Click();
            return new SettingsModal.SettingsModal();
        }

        public override void WaitForElements()
        {
            SiteTitle_Label.Verify().Present();
            Search_Field.Verify().Present();
            Settings_Link.Verify().Present();
            HP_Logo_Link.Verify().Present();
        }
    }
}
