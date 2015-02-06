using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class AccountNews : BasePageObject
    {
        public Element Container = new Element(By.Id("account-news"));
        public Element Title = new Element(By.ClassName("tile-title"));
        public Element Text = new Element(By.ClassName("tile-text"));
        public Element Link = new Element(By.ClassName("tile-link"));


        public override void WaitForElements()
        {
            Container.FindElement(Title).Verify().Text("Account News");
            Container.FindElement(Text).Verify().Present();
        }

        public AccountNews VerifyAccountSource(string text)
        {
            
            Assert.IsTrue(driver.FindElements(By.ClassName("tile-link")).Any(x => x.Text.Contains(text)));
            return this;
        }

    }
}
