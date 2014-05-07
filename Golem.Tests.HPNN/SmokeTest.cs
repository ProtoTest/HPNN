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
        [Test, Category("Smoke Test")]
        public void Some_Test()
        {
            DashboardPage.OpenDashboardPage().EnterSettings().Enter_Tiles();
        }

        [Test, Category("Smoke Test")]
        public void Another_Test()
        {

        }
    }
}
