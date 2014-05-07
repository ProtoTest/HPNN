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
    public class SettingsModal_YourInformation : BasePageObject
    {
        Element FullName_Label = new Element("Full name Label", By.XPath("//div[@id='settings-your-information']/div/div/div/h1"));
        Element EmployeeTitle_Label = new Element("Employee Title Label", By.XPath("//div[@id='settings-your-information']/div/div/div/h2"));
        Dropdown YourLocation_Dropdown = new Dropdown("Your Location Dropdown", By.XPath("//div[@class='field']/select"));
        Element UploadPhoto_Button = new Element("Upload Photo Button", By.LinkText("Upload Your Photo"));

        public override void WaitForElements()
        {
            FullName_Label.Verify().Visible();
            EmployeeTitle_Label.Verify().Visible();
            YourLocation_Dropdown.Verify().Visible();
            UploadPhoto_Button.Verify().Visible();
        }
    }
}
