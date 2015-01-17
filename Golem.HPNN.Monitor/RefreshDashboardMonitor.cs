using System;
using System.Collections.Generic;
using System.IO;
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
    public class RefreshDashboardMonitor : WebDriverTestBase
    {
        
        string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");

        public void LogVideo()
        {
            if(testData.recorder.Video!=null)
                TestLog.EmbedVideo("FLV _" + Common.GetShortTestName(90), testData.recorder.Video);
        }


        public void PrintCondensedActionTimings(ActionList actionList)
        {
            actionList.RemoveDuplicateEntries();
            var actions = actionList.actions;
            TestLog.BeginSection("Test Action Timings:");
            DateTime start;
            DateTime end;
            TimeSpan difference;
            string rowText = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            for (int i = 1; i < actions.Count; i++)
            {
                var startIndex = i - 1;
                var endIndex = i;
                start = actions[startIndex]._time;
                end = actions[endIndex]._time;
                difference = end.Subtract(start);
                Common.Log(actions[endIndex].name + " : " + difference);
                rowText += "," + actions[endIndex].name + ":" + difference;
            }
            start = actions[0]._time;
            end = actions[actions.Count - 1]._time;
            difference = end.Subtract(start);
            
            Common.Log("All Actions : " + difference);
            rowText += "All:" + difference + Environment.NewLine;
            WriteToCSV(rowText);
            TestLog.End();
        }

        public void WriteToCSV(string rowDetails)
        {
            string newFileName = Config.GetConfigValue("CSVPath", Directory.GetCurrentDirectory().ToString() + "\\" +  TestContext.CurrentContext.Test.Name + ".csv");

            //if (!File.Exists(newFileName))
            //{
            //    string clientHeader = "Client Name(ie. Billto_desc)" + "," + "Mid_id,billing number(ie billto_id)" + "," + "business unit id" + Environment.NewLine;

            //    File.WriteAllText(newFileName, clientHeader);
            //}

            File.AppendAllText(newFileName, rowDetails);
            Common.Log("Appended results to file : " + newFileName);
        }

        [FixtureInitializer]
        public void initialize()
        {
            Config.Settings.runTimeSettings.LaunchBrowser = false;
        }

        [SetUp]
        public void setup()
        {
            try
            {
                System.Uri uri = new System.Uri("http://localhost:7055/hub");
                driver = new EventedWebDriver(new ScreenshotRemoteWebDriver(uri, DesiredCapabilities.Firefox())).driver;
                Common.Log("Connecting to an existing Browser");
            }
            catch (Exception e)
            {
                driver = new WebDriverBrowser().LaunchBrowser(WebDriverBrowser.Browser.Firefox);
                Common.Log("Browser was closed, launching a new browser and logging in ");
                string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
                string password = Config.GetConfigValue("AdminPassword", "Sanders76");
                OpenPage<SSOLoginPage>(env)
                    .LoginAs(username, password)
                    .WaitForLoadingAnimationToVanish();
            }
        }

        [TearDown]
        public void teardown()
        {
            PrintCondensedActionTimings(testData.actions);
            LogVideo();
        }


        [Parallelizable]
        [Test, Category("Smoke Test")]
        [Timeout(0)]
        public void Reconnect_To_Browser_And_Reload_Dashboard()
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
            DashboardPage dashboard = new DashboardPage();
                dashboard.RefreshDashboardPage()
                .WaitForLoadingAnimationToVanish()
                .VerifyTiles(types);
        }

    }
}
