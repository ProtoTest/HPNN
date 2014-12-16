using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using OpenQA.Selenium;

namespace Golem.Tests.HPNN
{
    [TestFixture]
    public class SmokeTest : WebDriverTestBase
    {
        string env = Config.GetConfigValue("EnvUrl", "http://staging.hpnn.hp.com");

        //[Test, Category("Smoke Test")]
        //public void Some_Test()
        //{
            
        //    KenticoLoginPage.OpenKenticoLoginPage(env)
        //        .LoginAs("cbower", "sanders")
        //        .OpenDashoard(env).EnterSettings().Enter_Tiles();
        //}
       // [Repeat(10)]
        [Test, Category("Smoke Test")]
        public void Another_Test()
        {
           string[] tileList =
            {
                "Your Personal News", "SFDC Pipeline Forecast by Quarter",
                "Current FY Pipeline by GBU", "Account News", "HP Sales Now", "In The News", "MyComp", "Stock",
                "Sales Quick Links", "Account Competitor News"
            };

           KenticoLoginPage.OpenKenticoLoginPage(env)
                   .LoginAs("cbower", "sanders")
                   .OpenDashoard(env).VerifyDefaultTilesDisplayed(tileList);
        }
    }
}
