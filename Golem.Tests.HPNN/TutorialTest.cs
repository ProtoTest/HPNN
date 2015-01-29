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
        string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
        string password = Config.GetConfigValue("AdminPassword", "Sanders76");
        [Test,Parallelizable]
     //   [Parallelizable]
        public void TestTUtorialSteps()
        {
            string username = "cbower";
            string password = "sanders";
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


        [Test,Parallelizable]
        //   [Parallelizable]
        public void TestReplayTutorial()
        {
          //  Config.Settings.runTimeSettings.HighlightFoundElements = false;

           SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .VerifyTutorialNotVisible()
                .EnterSettings()
                .ReplayTutorial()
                .CloseTutorial()
                .VerifyTutorialNotVisible();
        }

        [Test, Parallelizable]
        //   [Parallelizable]
        public void TestTutorialVideoLink()
        {
            //  Config.Settings.runTimeSettings.HighlightFoundElements = false;

            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username, password)
                .VerifyTutorialNotVisible()
                .EnterSettings()
                .ReplayTutorial()
                .ClickStepOne()
                .ClickStepTwo()
                .ClickVideoLink()
                .VerifyPageUrl();
        }
    }
}
