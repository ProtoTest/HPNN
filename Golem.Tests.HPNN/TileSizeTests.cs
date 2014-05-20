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
    public class TileSizeTests : WebDriverTestBase
    {
        // Weather Tiles: 1x1, 2x1, 1x2
        string weather_tile_title = "Local Weather";
        string weather_tile_title_short = "Weather";
        string weather_location = "Denver";

        [Test]
        public void Verify_Weather_Tile_1x1()
        {
            DashboardPage.OpenDashboardPage()
                .EnterSettings()
                .Enter_Tiles()
                .AddWeatherTile("1x1", weather_location)
                .ClickDone()
                .VerifyTileSize(weather_tile_title, 1, 1)
                .EnterSettings().sidebar.RearrangeTiles()
                .RemoveTile(weather_tile_title)
                .ClickDone().VerifyTileNotPresent(weather_tile_title);
        }

        [Test]
        public void Verify_Weather_Tile_2x1()
        {
            DashboardPage.OpenDashboardPage()
               .EnterSettings()
               .Enter_Tiles()
               .AddWeatherTile("2x1", weather_location)
               .ClickDone()
               .VerifyTileSize(weather_tile_title_short, 2, 1)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(weather_tile_title_short)
               .ClickDone().VerifyTileNotPresent(weather_tile_title_short);
        }

        [Test]
        public void Verify_Weather_Tile_1x2()
        {
            DashboardPage.OpenDashboardPage()
                .EnterSettings()
                .Enter_Tiles()
                .AddWeatherTile("1x2", weather_location)
                .ClickDone()
                .VerifyTileSize(weather_tile_title_short, 1, 2)
                .EnterSettings().sidebar.RearrangeTiles()
                .RemoveTile(weather_tile_title_short)
                .ClickDone().VerifyTileNotPresent(weather_tile_title_short);
        }
    }
}
