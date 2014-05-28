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



    }
}
