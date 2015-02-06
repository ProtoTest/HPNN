using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN.SettingsModal;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{

    public class PersonalizeWeatherPage : BasePersonalizeTile
    {
        public Sidebar sidebar = new Sidebar();
        public Element location_field = new Element("Weather Location Field", By.Id("select-location"));
        public Radio temp_type_radio = new Radio("Weather temp type radio", By.XPath("//input[@type='radio']"));
        public Element RemoveButton = new Element(By.LinkText("Remove"));
        public Element RemoveButtonForLocation = new Element(By.XPath("//li[contains(@title,'{0}')]//a"));
        public Element FarhenheitRadio = new Element(By.XPath("//input[@value='imperial']"));
        public Element CelciusRadio = new Element(By.XPath("//input[@value='metric']"));
        public Element AutocompletePanel = new Element(By.ClassName("pac-container"));

        public PersonalizeWeatherPage EnterLocation(string location)
        {
            if (RemoveButtonForLocation.WithParam(location).Displayed)
                RemoveButton.WaitUntil().Visible().Click();
            if(!location_field.Displayed)
                RemoveButton.Click();
            location_field.WaitUntil().Visible().SendKeys(location);
            AutocompletePanel.WaitUntil().Visible();
            location_field.WaitUntil().Visible().SendKeys(Keys.Down + Keys.Enter);
            AddButton.WaitUntil().Visible().Click();
            return this;
        }

        public EditDashboardPage Done()
        {
            DoneButton.WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }

        public PersonalizeWeatherPage RemoveLocation()
        {
            RemoveButton.WaitUntil().Visible().Click();
            return this;
        }

        public EditDashboardPage ClickAddMyTile()
        {
            DoneButton.WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }

        public MyTiles ClickBack()
        {
            BackButton.Click();
            return new MyTiles();
        }

        public override void WaitForElements()
        {
            base.WaitForElements();
           // location_field.Verify().Present();
            temp_type_radio.Verify().Present();
        }
    }
}
