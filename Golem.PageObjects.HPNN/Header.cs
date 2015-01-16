using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{
    public class Header : BasePageObject
    {
        Element Container = new Element(By.ClassName("header"));
        Element SiteTitle_Label = new Element("Site Title", ByE.Text("HP News Now"));
        Field Search_Field = new Field("Search box", By.Id("p_lt_ctl01_SearchBox_txtWord"));
        Link User_Dropdown = new Link("Settings Link", By.Id("settings-link"));
        Element HP_Logo_Link = new Element("HP Logo/Link", By.ClassName("logo"));

        public SettingsModal.SettingsModal EnterSettings()
        {
            new Element(Container.FindElement(User_Dropdown)).WaitUntil().Visible().Click();
            return new SettingsModal.SettingsModal();
        }

        public override void WaitForElements()
        {
            //Container.FindElement(SiteTitle_Label).Verify().Present();
            //Container.FindElement(Search_Field).Verify().Present();
            //Container.FindElement(User_Dropdown).Verify().Present();
            //Container.FindElement(HP_Logo_Link).Verify().Present();
        }

        public void VerifyAllHeaderElementsPresent()
        {

            
        }
    }
}
