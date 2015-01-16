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
using Gallio.Framework;

namespace Golem.HPNN.Monitor
{
    public class ProductionMonitor : WebDriverTestBase
    {

        string env = Config.GetConfigValue("EnvUrl", "http://hpnn.hp.com");

        public void LogVideo()
        {
            TestLog.EmbedVideo("Video_" + Common.GetShortTestName(90), testData.recorder.Video);
        }


        public void PrintCondensedActionTimings(ActionList actionList)
        {
            var actions = actionList.actions;
            TestLog.BeginSection("Test Action Timings:");
            DateTime start;
            DateTime end;
            TimeSpan difference;
            for (int i = 1; i < actions.Count-1; i++)
            {
                var startIndex = i - 1;
                var endIndex = i;
                string endActionName = actions[endIndex].name;
                for (var j = endIndex + 1; j < actions.Count - 1; j++)
                {
                    string thisActionName = actions[j].name;
                    if (thisActionName != endActionName){
                        break;
                    }
                    else
                    {
                        endIndex = j;
                        i = j;
                    }

                }
                
                start = actions[startIndex]._time;
                end = actions[endIndex]._time;
                difference = end.Subtract(start);
                Common.Log(actions[endIndex].name + " : " + difference);
            }
            start = actions[0]._time;
            end = actions[actions.Count - 1]._time;
            difference = end.Subtract(start);
            Common.Log("All Actions : " + difference);
            TestLog.End();
        }

        [TearDown]
        public void teardown()
        {
            PrintCondensedActionTimings(testData.actions);
            LogVideo();
        }



        [Test, Category("Smoke Test")]
        public void Global_Admin_Default_Tiles()
        {
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
                .VerifyTiles(types);


        }

    }
}
