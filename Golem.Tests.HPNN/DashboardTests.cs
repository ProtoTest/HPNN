using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
    class DashboardTests : WebDriverTestBase
    {
        [Test]
        public void Verify_No_Remove_Button()
        {
            DashboardPage.OpenDashboardPage();
        }

        [Test]
        public void Remove_Tile()
        {
            DashboardPage.OpenDashboardPage()
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .RemoveTile("Quick links")
                .VerifyTileNotPresent("Quick links");
        }

        [Test]
        public void Rearrange_Tile()
        {
            var dashboard = DashboardPage.OpenDashboardPage()
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .DragTileToFirstPosition("Quick links")
                .rearrangeBanner.ClickDone();
        }

        [Test]
        public void Cancel_Rearrange_Tile()
        {
            var dashboard = DashboardPage.OpenDashboardPage().GetTilePosition("Quick links");
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .DragTileToFirstPosition("Quick links");
            
            var position = dashboard.GetTilePosition("Quick links");
            dashboard.rearrangeBanner.ClickCancel();
            var newPosition = dashboard
                .EnterSettings()
                .sidebar.RearrangeTiles().GetTilePosition("Quick links");

            Assert.AreEqual(position, newPosition,"The tile has moved position, even though cancel was clicked");
        }
       
    }
}
