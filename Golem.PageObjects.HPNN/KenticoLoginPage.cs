﻿
using System.Threading;
using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class KenticoLoginPage : BasePageObject
    {
        public Element ClickHereLink = new Element(By.ClassName("show-btn"));
        public Element LoginField = new Element("LoginField", By.Id("Login1_UserName"));
        public Element PasswordField = new Element("PasswordField", By.Id("Login1_Password"));
        public Element SignInButton = new Element("LogInButton", By.Id("Login1_LoginButton"));

        public DashboardPage LoginAs(string username, string password)
        {
            ClickHereLink.Click();
            LoginField.SendKeys(username);
            PasswordField.SendKeys(password);
            SignInButton.Click();
            return new DashboardPage();
        }

        public static KenticoLoginPage OpenKenticoLoginPage(string env)
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(env + "/CMSPages/logon.aspx?ReturnUrl=%2f");
            return new KenticoLoginPage();
        }

        public override void WaitForElements()
        {
            
        }
    }
}