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
            DashboardPage.OpenDashboardPage()
                         .EnterSettings()
                         .sidebar.RearrangeTiles()
                         .DragTileToFirstPosition("Quick links").
                        rearrangeBanner.ClickDone().
                        VerifyTilePosition("Quick links", 1);
        }

        [Test]
        public void Cancel_Rearrange_Tile()
        {
            DashboardPage.OpenDashboardPage()
                         .EnterSettings()
                         .sidebar.RearrangeTiles()
                         .DragTileToFirstPosition("Quick links").
rearrangeBanner.ClickCancel();
            
           
        }
       
    }
}
