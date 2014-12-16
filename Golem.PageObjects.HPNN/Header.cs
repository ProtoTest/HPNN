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
    public class Header : BasePageObject
    {
        Element SiteTitle_Label = new Element("Site Title", ByE.Text("HP News Now"));
        Field Search_Field = new Field("Search box", By.Id("p_lt_ctl01_SearchBox_txtWord"));
        Link Settings_Link = new Link("Settings Link", By.Id("settings-link"));
        Element HP_Logo_Link = new Element("HP Logo/Link", By.ClassName("logo"));

        public SettingsModal EnterSettings()
        {
            Settings_Link.Highlight();
            Settings_Link.Click();
            return new SettingsModal();
        }

        public override void WaitForElements()
        {
            SiteTitle_Label.Verify().Visible();
            Search_Field.Verify().Visible();
            Settings_Link.Verify().Visible();
            HP_Logo_Link.Verify().Visible();
        }
    }
}
