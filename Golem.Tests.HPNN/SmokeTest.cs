using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.HPNN;
using Golem.PageObjects.HPNN.Tiles;
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
  
        [Test, Category("Smoke Test")]
        public void Sales_User_Default_Tiles()
        {
           Type[] types =
            {
                typeof(YourPersonalNews),typeof(InTheNews),typeof(Stock),typeof(SFDCPipeline),typeof(SalesEssentialsHeadlines),
                typeof(AccountNews),typeof(AccountCompetitorNews),typeof(HPSalesNow),typeof(MyComp),typeof(SalesQuickLinks),typeof(CurrentFYPipeline)
            };
           string username = Config.GetConfigValue("SalesEmail", "7@hp.com");
           string password = Config.GetConfigValue("SalesPassword", "asdf");
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
               .VerifyTiles(types);
        }

        [Test, Category("Smoke Test")]
        public void General_User_Default_Tiles()
        {
            Type[] types =
            {
               typeof(Trending), typeof(YourPersonalNews),typeof(MostShared),typeof(MostLiked),typeof(InTheNews),typeof(InnovationShowcase)
                ,typeof(MegOnLinkedIn),typeof(KeyDates),typeof(DicussedOnOneHP),typeof(Weather),typeof(Stock)
            };

            string username = Config.GetConfigValue("GeneralEmail", "bob.gonzales@hp.com");
            string password = Config.GetConfigValue("GeneralPassword", "asdf");
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .VerifyTiles(types);
        }

    }
}
