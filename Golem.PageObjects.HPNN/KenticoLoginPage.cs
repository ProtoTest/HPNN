
using System.Threading;
using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class KenticoLoginPage : BasePageObject
    {

        //content publisher flow 
        public Element ClickHereButton = new Element(By.ClassName("LoginLink"));
        public Element ContinueButton = new Element(By.ClassName("btn-primary"));
        public Element Username= new Element("Username", By.Id("username"));
        public Element Password = new Element("Password", By.Id("password"));
        public Element LogOnButton = new Element("LogOnButton", By.ClassName("btn-primary"));

        //technical admin flow
        public Element ClickHereLink = new Element(By.ClassName("show-btn"));
        public Element LoginField = new Element("LoginField", By.Id("Login1_UserName"));
        public Element PasswordField = new Element("PasswordField", By.Id("Login1_Password"));
        public Element SignInButton = new Element("LogInButton", By.Id("Login1_LoginButton"));

        public DashboardPage LoginAs(string username, string password)
        {
                ClickHereLink.WaitUntil().Visible().Click();
                LoginField.SendKeys(username);
                PasswordField.SendKeys(password);
                SignInButton.Click();
                return new DashboardPage();
        }

        public CmsDeskPage LoginAsProducer(string username, string password)
        {
            ClickHereButton.Click();
            ContinueButton.Click();
            Username.SetText(username);
            Password.SetText(password);
            LogOnButton.Click();
            if (ContinueButton.Displayed)
                ContinueButton.Click();
            return new CmsDeskPage();
        }

        public static KenticoLoginPage OpenKenticoLoginPage(string env)
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(env + "/CMSPages/logon.aspx?ReturnUrl=%2f");
            return new KenticoLoginPage();
        }

        public override void WaitForElements()
        {
            ClickHereLink.Verify().Visible();
            ClickHereButton.Verify().Visible();
        }
    }
}
