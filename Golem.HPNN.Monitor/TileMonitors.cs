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
using System.Threading;
using Gallio.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Golem.HPNN.Monitor
{
    [Parallelizable]
    public class TileMonitors : MonitorBaseTest
    {
        string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");
        string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
        string password = Config.GetConfigValue("AdminPassword", "Sanders76");


        [Parallelizable]
        [Test, Category("Monitor")]
        public void Marquee_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(Marquee));

        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void PersonalNews_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(YourPersonalNews));
        }


        [Parallelizable]
        [Test, Category("Monitor")]
        public void InTheNews_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(InTheNews));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void Stock_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(Stock));
        }
        [Parallelizable]
        [Test, Category("Monitor")]
        public void SalesEssentialsHeadlines_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(SalesEssentialsHeadlines));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void AccountNews_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(AccountNews));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void AccountCompetitorNews_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(AccountCompetitorNews));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void MostShared_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(MostShared));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void MostLiked_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(MostLiked));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void InnovationShowcase_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(InnovationShowcase));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void Trending_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(Trending));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void MegOnLinkedIn_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(MegOnLinkedIn));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void KeyDates_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(KeyDates));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void HPUniversity_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(HPUniversity));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void MostRead_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(MostRead));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void MostDiscussed_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(MostDiscussed));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void HPSalesNow_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(HPSalesNow));
        }

        [Parallelizable]
        [Test, Category("Monitor")]
        public void JobsAtHp_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(JobsAtHp));
        }


        [Parallelizable]
        [Test, Category("Monitor")]
        public void Weather_Monitor()
        {
            SSOLoginPage.OpenSSOLoginPage(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTile(typeof(Weather));
        }
    }
}
