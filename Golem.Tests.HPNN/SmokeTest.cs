﻿using System;
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
using Gallio.Framework;

namespace Golem.Tests.HPNN
{
    [TestFixture,Parallelizable]
    public class SmokeTest : WebDriverTestBase
    {
        string env = Config.GetConfigValue("EnvUrl", "http://staging.hpnn.hp.com");
        string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
        string password = Config.GetConfigValue("AdminPassword", "Sanders76");
        [Test,Parallelizable, Category("Smoke Test")]
        public void Global_Admin_Default_Tiles()
        {
            Type[] types =
            {
                typeof(YourPersonalNews),typeof(InTheNews),typeof(Stock),typeof(SalesEssentialsHeadlines),
                typeof(AccountNews),typeof(AccountCompetitorNews),typeof(MostShared),typeof(MostLiked)
                ,typeof(InnovationShowcase),typeof(Trending),typeof(MegOnLinkedIn),typeof(KeyDates)
            };
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password).VerifyTiles(types);



        }


        [Test,Parallelizable, Category("Smoke Test")]
        public void Sales_User_Default_Tiles()
        {
           Type[] types =
            {
                typeof(YourPersonalNews),typeof(InTheNews),typeof(Stock),typeof(SalesEssentialsHeadlines),
                typeof(AccountNews),typeof(AccountCompetitorNews),typeof(HPSalesNow),typeof(MyComp),typeof(SalesQuickLinks),typeof(CurrentFYPipeline)
            };
           string username = Config.GetConfigValue("SalesEmail", "7@hp.com");
           string password = Config.GetConfigValue("SalesPassword", "asdf");
           KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
               .LoginAs(username, password).VerifyTiles(types);

           
        }

        [Test,Parallelizable, Category("Smoke Test")]
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
