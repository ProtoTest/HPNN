
using System.Threading;
using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class SSOLoginPage : BasePageObject
    {

        public Element ContinueButton = new Element(By.ClassName("btn-primary"));
        public Element Username = new Element("Username", By.Id("username"));
        public Element Password = new Element("Password", By.Id("password"));
        public Element LogOnButton = new Element("LogOnButton", By.ClassName("btn-primary"));


        public DashboardPage LoginAs(string username, string password)
        {
            ContinueButton.Click();
            Username.SetText(username);
            Password.SetText(password);
            LogOnButton.Click();
            return new DashboardPage();
        }

        public static SSOLoginPage OpenSSOLoginPage(string env)
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(env);
            return new SSOLoginPage();
        }

        public override void WaitForElements()
        {
            ContinueButton.Verify().Visible();
        }
    }
}

