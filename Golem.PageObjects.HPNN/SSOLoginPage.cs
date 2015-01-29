
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
        public Element SsoDropdown = new Element(By.Name("pfidpadapterid"));

        public DashboardPage LoginAs(string username, string password)
        {
            SsoDropdown.WaitUntil().Visible().SelectOption("Email and Computer password");
            ContinueButton.WaitUntil().Visible().Click();
            //driver.Sleep(1000);
            Username.WaitUntil().Visible().SetText(username);
            //driver.Sleep(1000);
            Password.WaitUntil().Visible().SetText(password);
            //driver.Sleep(1000);
            LogOnButton.WaitUntil().Visible().Click();
            return new DashboardPage();
        }



        public static SSOLoginPage OpenSSOLoginPage(string env)
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(env);
            if(WebDriverTestBase.testData.browserInfo.browser == WebDriverBrowser.Browser.IE)
                WebDriverTestBase.driver.Navigate().GoToUrl(env);
            return new SSOLoginPage();
        }

        public override void WaitForElements()
        {
            ContinueButton.Verify().Visible();
        }
    }
}

