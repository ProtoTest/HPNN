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
    public class LoginToDashboardMonitor : MonitorBaseTest
    {
        
        string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");

        [Parallelizable]
        [Test, Category("Smoke Test")]
        [Timeout(0)]
        public void LoginToDashboard()
        {
            Config.Settings.runTimeSettings.HighlightFoundElements = false;
            Config.Settings.reportSettings.commandLogging = true;
            Type[] types =
            {

                typeof(Marquee),typeof(YourPersonalNews),typeof(InTheNews),typeof(Stock),typeof(SalesEssentialsHeadlines),
                typeof(AccountNews),typeof(AccountCompetitorNews),typeof(MostShared),typeof(MostLiked)
                ,typeof(InnovationShowcase),typeof(Trending),typeof(MegOnLinkedIn),typeof(KeyDates),
                typeof(HPUniversity),typeof(MostRead),typeof(MostDiscussed),typeof(HPSalesNow),typeof(JobsAtHp),
                typeof(Stock),typeof(Weather)
            };
            string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
            string password = Config.GetConfigValue("AdminPassword", "Sanders76");
            OpenPage<SSOLoginPage>(env)
                .LoginAs(username, password)
                .WaitForLoadingAnimationToVanish()
                .VerifyTiles(types);
        }

    }
}
