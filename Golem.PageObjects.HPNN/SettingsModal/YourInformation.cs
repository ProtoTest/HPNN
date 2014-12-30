using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;
using ProtoTest.Golem.WebDriver.UIElements.Types;

namespace Golem.PageObjects.HPNN.SettingsModal
{
    public class YourInformation : BasePageObject
    {
        Element FullName_Label = new Element("Full name Label", By.XPath("//div[@id='settings-your-information']/div/div/div/h1"));
        Element EmployeeTitle_Label = new Element("Employee Title Label", By.XPath("//div[@id='settings-your-information']/div/div/div/h2"));
        Dropdown YourLocation_Dropdown = new Dropdown("Your Location Dropdown", By.XPath("//div[@class='field']/select"));
        Element UploadPhoto_Button = new Element("Upload Photo Button", By.LinkText("Upload Your Photo"));

        public override void WaitForElements()
        {
            FullName_Label.Verify().Present();
            EmployeeTitle_Label.Verify().Present();
            YourLocation_Dropdown.Verify().Present();
            UploadPhoto_Button.Verify().Present();
        }
    }
}
