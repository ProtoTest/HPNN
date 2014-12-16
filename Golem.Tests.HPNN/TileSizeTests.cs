﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
    public class TileSizeTests : WebDriverTestBase
    {
        string env = Config.GetConfigValue("EnvUrl", "http://staging.hpnn.hp.com");

        [Test]
        [Row(1,1)]
        [Row(1,2)]
        [Row(2,1)]
        public void Verify_Weather_Tile(int x, int y)
        {
            string weather_tile_title = "Local Weather";
            string weather_tile_title_short = "Weather";
            string weather_location = "Denver";
            KenticoLoginPage.OpenKenticoLoginPage(env)
                .LoginAs("cbower", "sanders")
                .OpenDashoard(env)
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
            DashboardPage.OpenDashboardPageViaKentico()
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
            DashboardPage.OpenDashboardPageViaKentico()
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
            DashboardPage.OpenDashboardPageViaKentico()
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
        [Row(2, 2)]
        public void Verify_InTheNews_Tile(int x, int y)
        {
            String tile_under_test = "In The News";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostRead_Tile(int x, int y)
        {
            String tile_under_test = "Most Read";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }


        [Test]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostShared_Tile(int x, int y)
        {
            String tile_under_test = "Most Shared";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostDiscussed_Tile(int x, int y)
        {
            String tile_under_test = "Most Discussed";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostLiked_Tile(int x, int y)
        {
            String tile_under_test = "Most Liked";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }


        [Test]
        [Row(2, 2)]
        public void Verify_Trending_Tile(int x, int y)
        {
            String tile_under_test = "Trending";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1, "Product Show..")]
        [Row(2, 1, "Product Showcase")]
        public void Verify_ProductShowcase_Tile(int x, int y, string tile_under_test)
        {
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

            List<string> tile_list = dashboard_page.GetAllTileTitles();

            // Remove the tile if it is already on the dashboard
            foreach (string s in tile_list)
            {
                if (s.Contains("Product Show"))
                {
                    dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
                    .RemoveTile("Product Show..")
                    .ClickDone().VerifyTileNotPresent(tile_under_test);
                    break;
                }
            }

            dashboard_page.EnterSettings()
               .Enter_Tiles()
               .AddTileWithType("Product Showcase", String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 2)]
        [Row(2, 1)]
        public void Verify_UpComingEvents_Tile(int x, int y)
        {
            String tile_under_test = "Upcoming Events";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 2)]
        [Row(2, 1)]
        public void Verify_UpComingEventsSales_Tile(int x, int y)
        {
            String tile_under_test = "Upcoming Events for Sales";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .AddTileWithType("Upcoming Sales Events", String.Format("{0}x{1}", x, y))
               .ClickDone()
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 1)]
        public void Verify_DiscussedOnOneHP_Tile(int x, int y)
        {
            String tile_under_test = "Discussed on OneHP";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        [Row(2, 1)]
        [Row(1, 2)]
        public void Verify_Inbox_Tile(int x, int y)
        {
            String tile_under_test = "Inbox";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        [Row(2, 1)]
        public void Verify_NextMeeting_Tile(int x, int y)
        {
            String tile_under_test = "Next Meeting";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 2)]
        [Row(2, 2)]
        public void Verify_Tasks_Tile(int x, int y)
        {
            String tile_under_test = "Tasks";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_SalesEssentialsHeadlines_Tile(int x, int y)
        {
            String tile_under_test = "Sales Essentials Headlines";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 1)]
        [Row(1, 2)]
        public void Verify_InnovationAtHP_Tile(int x, int y)
        {
            String tile_under_test = "Innovation @HP";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        [Row(2, 2)]
        public void Verify_Traffic_Tile(int x, int y)
        {
            String tile_under_test = "Traffic";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_AccountNews_Tile(int x, int y)
        {
            String tile_under_test = "Account News";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_AccountCompetitorNews_Tile(int x, int y)
        {
            String tile_under_test = "Account Competitor News";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 2)]
        public void Verify_HPSalesNow_Tile(int x, int y)
        {
            String tile_under_test = "HP Sales Now";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        [Row(2, 1)]
        public void Verify_QuickLinks_Tile(int x, int y)
        {
            String tile_under_test = "Quick Links";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        [Row(2, 1)]
        public void Verify_QuickLinksForSales_Tile(int x, int y)
        {
            String tile_under_test = "Quick Links for Sales";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        public void Verify_SFDC_PastDue_Tile(int x, int y)
        {
            String tile_under_test = "SFDC Past Due";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        // SOW says 2x2, but it looked stretched and fuzzy on all browsers, per HTD-17
        [Test]
        [Row(2, 1)]
        public void Verify_SFDC_PipelineForecastByQtr_Tile(int x, int y)
        {
            String tile_under_test = "SFDC Pipeline Forecast by Quarter";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        public void Verify_SFDC_Activities_Tile(int x, int y)
        {
            String tile_under_test = "SFDC Activites";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(2, 2)]
        public void Verify_SFDC_OpenAndWon_Tile(int x, int y)
        {
            String tile_under_test = "SFDC Open and Won";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        public void Verify_MySalesGuide_Tile(int x, int y)
        {
            String tile_under_test = "My Sales Guide";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }

        [Test]
        [Row(1, 1)]
        [Row(1, 2)]
        public void Verify_HP_University_LandD_Tile(int x, int y)
        {
            String tile_under_test = "L&D";
            DashboardPage dashboard_page = DashboardPage.OpenDashboardPageViaKentico();

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
               .VerifyTileSize(tile_under_test, x, y)
               .EnterSettings().sidebar.RearrangeTiles()
               .RemoveTile(tile_under_test)
               .ClickDone().VerifyTileNotPresent(tile_under_test);
        }
    }
}
