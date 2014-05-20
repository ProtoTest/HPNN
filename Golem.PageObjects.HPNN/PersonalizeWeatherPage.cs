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

    public class PersonalizeWeatherPage : BasePersonalizeTile
    {
        public SettingsModal_Sidebar sidebar = new SettingsModal_Sidebar();
        public Element location_field = new Element("Weather Location Field", ByE.PartialAttribute("input", "ng-show", "location"));
        public Radio temp_type_radio = new Radio("Weather temp type radio", By.XPath("//input[@type='radio']"));
        
        public PersonalizeWeatherPage EnterLocation(string location)
        {
            location_field.Text = location;
            Common.Delay(2000);
            location_field.SendKeys(Keys.ArrowDown);
            Common.Delay(500);
            location_field.SendKeys(Keys.Enter);
            Common.Delay(500);
            temp_type_radio.Click();
            
            return this;
        }

        public EditDashboardPage ClickAddMyTile()
        {
            done_add_tile_btn.Click();
            return new EditDashboardPage();
        }

        public SettingsModal_Tiles ClickBack()
        {
            back_btn.Click();
            return new SettingsModal_Tiles();
        }

        public override void WaitForElements()
        {
            base.WaitForElements();
            location_field.Verify().Visible();
            temp_type_radio.Verify().Visible();
        }
    }
}
