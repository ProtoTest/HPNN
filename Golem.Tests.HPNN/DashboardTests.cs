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
    class DashboardTests : WebDriverTestBase
    {
        string env = Config.GetConfigValue("EnvUrl", "http://staging.hpnn.hp.com");

        [Test]
        public void Verify_DefaultTiles()
        {
            string[] tileList =
        {
            "Your Personal News", "SFDC Pipeline Forecast by Quarter",
            "Current FYI Pipeline by GBU", "Account News", "HP Sales Now", "In The News", "MyComp", "Stock",
            "Sales Quick Links", "Account Competitor News"
        };

            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env)
                .VerifyDefaultTilesDisplayed(tileList);
        }

        [Test]
        public void Remove_Tile()
        {
            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env).VerifyTilePosition("Quick links", 7)
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .RemoveTile("Quick links")
                .VerifyTileNotPresent("Quick links");
        }

        [Test]
        public void Rearrange_Tile()
        {
            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env)
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .DragTileToFirstPosition("Quick links")
                .ClickDone()
                .VerifyTilePosition("Quick links", 0);

        }

        /// <summary>
        /// This test is currently failing due to a site issue
        /// </summary>
        [Test]
        public void Cancel_Rearrange_Tile()
        {
            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env).VerifyTilePosition("Quick links", 7)
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .DragTileToFirstPosition("Quick links")
                .ClickCancel()
                .VerifyTilePosition("Quick links",7);


        }

        [Test]
        public void Add_Tiles()
        {
            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env)
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Tasks", "1x2")
                .ClickDone()
                .VerifyTileSize("Tasks",1,2);
        }

        [Test]
        public void Cancel_Add_Tiles()
        {
            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env)
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Trending", "2x2")
                .ClickCancel()
                .VerifyTileNotPresent("Trending");
        }
       
    }
}
