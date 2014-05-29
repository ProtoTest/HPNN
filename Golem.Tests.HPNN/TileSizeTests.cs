using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
    public class TileSizeTests : WebDriverTestBase
    {

        [Test]
        [Row(1,1)]
        [Row(1,2)]
        [Row(2,1)]
        public void Verify_Weather_Tile(int x, int y)
        {
            string weather_tile_title = "Local Weather";
            string weather_tile_title_short = "Weather";
            string weather_location = "Denver";
            DashboardPage.OpenDashboardPage()
               .EnterSettings()
               .Enter_Tiles()
               .AddWeatherTile(String.Format("{0}x{1}",x,y), weather_location)
               .ClickDone()
               .VerifyTileSize(weather_tile_title_short, x,y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(weather_tile_title_short)
               .ClickDone().VerifyTileNotPresent(weather_tile_title_short);
        }

        [Test]
        [Row(1, 1)]
        [Row(2, 1)]
        [Row(1, 2)]
        public void Verify_StockQuote_Tile(int x, int y)
        {
            DashboardPage.OpenDashboardPage()
               .EnterSettings()
               .Enter_Tiles()
               .AddStockQuoteTile("APPL", String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize("Stock Quote", x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile("Stock Quote")
               .ClickDone().VerifyTileNotPresent("Stock Quote");
        }


        [Test]
        [Row(1, 1)]
        [Row(1, 2)]
        public void Verify_MyComp_Tile(int x, int y)
        {
            DashboardPage.OpenDashboardPage()
               .EnterSettings()
               .Enter_Tiles()
               .AddTileWithType("MyComp",String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize("MyComp", x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile("MyComp")
               .ClickDone().VerifyTileNotPresent("MyComp");
        }

        [Test]
        [Row(2, 1)]
        [Row(1, 2)]
        public void Verify_LinkedIn_Tile(int x, int y)
        {
            DashboardPage.OpenDashboardPage()
               .EnterSettings()
               .Enter_Tiles()
               .AddTileWithType("Meg on LinkedIn", String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize("Meg on LinkedIn", x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile("Meg on LinkedIn")
               .ClickDone().VerifyTileNotPresent("Meg on LinkedIn");
        }

        [Test]
        [Row(2, 1)]
        [Row(1, 2)]
        public void Verify_NextMeeting_Tile(int x, int y)
        {
            DashboardPage.OpenDashboardPage()
               .EnterSettings()
               .Enter_Tiles()
               .AddTileWithType("Next Meeting", String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize("Next Meeting", x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile("Next Meeting")
               .ClickDone().VerifyTileNotPresent("Next Meeting");
        }

        [Test]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_InTheNews_Tile(int x, int y)
        {
            String tile_under_test = "In The News";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPage();

            List<string> tile_list = dashboard_page.GetAllTileTitles();

            // Remove the tile if it is already on the dashboard
            if (tile_list.Contains(tile_under_test))
            {
                dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
                .RemoveTile(tile_under_test)
                .ClickDone().VerifyTileNotPresent(tile_under_test);
            }

            dashboard_page.EnterSettings()
               .Enter_Tiles()
               .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize(tile_under_test, x, y);
        }


    }
}
