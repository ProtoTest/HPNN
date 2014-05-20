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
    public class TileTests : WebDriverTestBase
    {
        [Test]
        public void Verify_DefaultTiles()
        {
            DashboardPage.OpenDashboardPage()
                .VerifyDefaultTilesDisplayed();
        }

        [Test]
        // Weather Tile: 1x1, 2x1, 1x2
        public void Verify_Weather_Tile_Sizes()
        {
            DashboardPage.OpenDashboardPage()
                .EnterSettings().Enter_Tiles().AddWeatherTile("1x1", "Denver").VerifyTileSize("Weather", 1, 1);
               
                /*.EnterSettings()
                .sidebar.RearrangeTiles()
                .RemoveTile("Marqee")
                .Enter_Tiles()
                .AddTileWithType("Tasks", "1x2")
                .ClickDone()
                .VerifyTileSize("Tasks", 1, 2);*/
        }




        [Test]
        public void Remove_Tile()
        {
            DashboardPage.OpenDashboardPage().VerifyTilePosition("Quick links", 7)
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
            DashboardPage.OpenDashboardPage().VerifyTilePosition("Quick links", 7)
                .EnterSettings()
                .sidebar.RearrangeTiles()
                .DragTileToFirstPosition("Quick links")
                .ClickCancel()
                .VerifyTilePosition("Quick links", 7);


        }

        [Test]
        public void Add_Tiles()
        {
            DashboardPage.OpenDashboardPage()
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Tasks", "1x2")
                .ClickDone()
                .VerifyTileSize("Tasks", 1, 2);
        }

        [Test]
        public void Cancel_Add_Tiles()
        {
            DashboardPage.OpenDashboardPage()
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Trending", "2x2")
                .ClickCancel()
                .VerifyTileNotPresent("Trending");
        }

    }
}
