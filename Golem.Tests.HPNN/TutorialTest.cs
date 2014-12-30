using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
 //   [Parallelizable]
    class TutorialTest : WebDriverTestBase
    {
        [Test]
     //   [Parallelizable]
        public void TestTUtorialSteps()
        {
            string username = Config.GetConfigValue("SalesEmail", "7@hp.com");
           string password = Config.GetConfigValue("SalesPassword", "asdf");
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .tutorial.VerifyStepCount("1")
                .ClickNext()
                .VerifyStepCount("2")
                .ClickNext()
                .VerifyStepCount("3")
                .Exit()
                .VerifyTutorialNotVisible();
        }


        [Test]
        //   [Parallelizable]
        public void TestReplayTutorial()
        {
          //  Config.Settings.runTimeSettings.HighlightFoundElements = false;

            string username = Config.GetConfigValue("SalesEmail", "7@hp.com");
            string password = Config.GetConfigValue("SalesPassword", "asdf");
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .CloseTutorial()
                .VerifyTutorialNotVisible()
                .EnterSettings()
                .ReplayTutorial()
                .CloseTutorial()
                .VerifyTutorialNotVisible();
        }

    }
}
