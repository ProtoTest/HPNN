using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators;
using Golem.PageObjects.HPNN;
using Golem.PageObjects.HPNN.Tiles;
using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
    public class TileSizeTests : WebDriverTestBase
    {
        string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
        string password = Config.GetConfigValue("AdminPassword", "Sanders76");
        [Test,Parallelizable]
        [Row(1, 1)]
        [Row(1, 2)]
        [Row(2, 1)]
        public void Verify_Weather_Tile(int x, int y)
        {
            string weather_tile_title = "Local Weather";
            string weather_tile_title_short = "Weather";
            string weather_location = "Denver";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username,password)
                .RemoveTileIfPresent("Weather")
                .EnterSettings()
                .Enter_Tiles()
                .AddWeatherTile(String.Format("{0}x{1}", x, y), weather_location)
                .ClickDone()
                .VerifyTileSize(weather_tile_title_short, x, y)
                .VerifyTile(typeof(Weather));
        }

        [Test,Parallelizable]
        [Row(1, 1)]
        [Row(2, 1)]
        public void Verify_StockQuote_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Stock")
                .EnterSettings()
                .Enter_Tiles()
                .AddStockQuoteTile("AAPL - Apple Inc.", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Stock", x, y)
                .VerifyTile(typeof(Stock));
        }

        //[Test,Parallelizable]
        //[Row(2, 1)]
        //public void Verify_MyComp_Tile(int x, int y)
        //{
        //    SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
        //        .RemoveTileIfPresent("MyComp")
        //        .EnterSettings()
        //        .Enter_Tiles()
        //        .AddTileWithType("MyComp", String.Format("{0}x{1}", x, y))
        //        .ClickDone()
        //        .VerifyTileSize("MyComp", x, y)
        //        .VerifyTile(typeof (MyComp));
        //}

        [Test,Parallelizable]
        [Row(2, 1)]
        [Row(1, 2)]
        public void Verify_LinkedIn_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Meg on LinkedIn")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Meg on LinkedIn", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Meg on LinkedIn", x, y)
                .VerifyTile(typeof(MegOnLinkedIn));
        }


        [Test,Parallelizable]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_InTheNews_Tile(int x, int y)
        {
            String tile_under_test = "In The News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent(tile_under_test)
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize(tile_under_test, x, y)
                .VerifyTile(typeof (InTheNews));
        }

        [Test,Parallelizable]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostRead_Tile(int x, int y)
        {
            String tile_under_test = "Most Read";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Most Read")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize(tile_under_test, x, y)
                .VerifyTile(typeof (MostRead));
        }


        [Test,Parallelizable]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostShared_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Most Shared")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Most Shared", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Most Shared", x, y)
                .VerifyTile(typeof (MostShared));
        }

        [Test,Parallelizable]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostDiscussed_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Most Discussed")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Most Discussed", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Most Discussed", x, y)
                .VerifyTile(typeof (MostDiscussed));
        }


        [Test,Parallelizable]
        [Row(1, 3)]
        [Row(2, 3)]
        public void Verify_MostLiked_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Most Liked")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Most Liked", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Most Liked", x, y)
                .VerifyTile(typeof (MostLiked));
        }

        [Test,Parallelizable]
        [Row(2, 2)]
        public void Verify_Trending_Tile(int x, int y)
        {
            Config.Settings.runTimeSettings.HighlightFoundElements = true;
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Trending Today")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Trending", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Trending Today", x, y)
                .VerifyTile(typeof(Trending));
        }


        [Test,Parallelizable]
        [Row(1, 1)]
        [Row(2, 1)]
        public void Verify_InnovationShowcase_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password)
                .RemoveTileIfPresent("Showcase")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Showcase", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Innovation Showcase", x, y)
                .VerifyTile(typeof(InnovationShowcase));
        }

        //[Test,Parallelizable]
        //[Row(1, 2)]
        //[Row(2, 1)]
        //public void Verify_UpComingEvents_Tile(int x, int y)
        //{
        //    String tile_under_test = "Upcoming Events";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 2)]
        //[Row(2, 1)]
        //public void Verify_UpComingEventsSales_Tile(int x, int y)
        //{
        //    String tile_under_test = "Upcoming Events for Sales";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType("Upcoming Sales Events", String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        [Test,Parallelizable]
        [Row(2, 1)]
        public void Verify_DiscussedOnOneHP_Tile(int x, int y)
        {
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username,password)
                .RemoveTileIfPresent("Discussed on OneHP")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("Discussed on OneHP", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("Discussed on OneHP", x, y)
                .VerifyTile(typeof(DicussedOnOneHP));
        }

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //[Row(2, 1)]
        //[Row(1, 2)]
        //public void Verify_Inbox_Tile(int x, int y)
        //{
        //    String tile_under_test = "Inbox";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //[Row(2, 1)]
        //public void Verify_NextMeeting_Tile(int x, int y)
        //{
        //    String tile_under_test = "Next Meeting";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 2)]
        //[Row(2, 2)]
        //public void Verify_Tasks_Tile(int x, int y)
        //{
        //    String tile_under_test = "Tasks";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(2, 1)]
        //[Row(2, 2)]
        //public void Verify_SalesEssentialsHeadlines_Tile(int x, int y)
        //{
        //    String tile_under_test = "Sales Essentials Headlines";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //[Row(2, 2)]
        //public void Verify_Traffic_Tile(int x, int y)
        //{
        //    String tile_under_test = "Traffic";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        [Test, Parallelizable]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_AccountNews_Tile(int x, int y)
        {
            String tile_under_test = "Account News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                 .RemoveTileIfPresent(tile_under_test)
                 .EnterSettings()
                 .Enter_Tiles()
                 .AddAccountNews(String.Format("{0}x{1}", x, y))
                 .RemoveNameIfPresent("JOHNSON")
                 .EnterName("JOHNSON CONTROLS INC")
                 .Done()
                 .VerifyTileSize(tile_under_test, x, y)
                 .VerifyTile(typeof(AccountNews));
        }

        [Test, Parallelizable]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_AccountCompetitorNews_Tile(int x, int y)
        {
            String tile_under_test = "Account Competitor News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                 .RemoveTileIfPresent(tile_under_test)
                 .EnterSettings()
                 .Enter_Tiles()
                 .AddAccountCompetitorTile(String.Format("{0}x{1}", x, y))
                 .RemoveNameIfPresent("JOHNSON")
                 .EnterName("JOHNSON CONTROLS INC")
                 .Done()
                 .VerifyTileSize(tile_under_test, x, y)
                 .VerifyTile(typeof(AccountCompetitorNews));
        }

        [Test, Parallelizable]
        [Row(2, 2)]
        public void Verify_HPSalesNow_Tile(int x, int y)
        {
            String tile_under_test = "HP Sales Now";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                 .RemoveTileIfPresent(tile_under_test)
                 .EnterSettings()
                 .Enter_Tiles()
                 .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
                 .ClickDone()
                 .VerifyTileSize(tile_under_test, x, y)
                 .VerifyTile(typeof(HPSalesNow));
        }

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //[Row(2, 1)]
        //public void Verify_QuickLinks_Tile(int x, int y)
        //{
        //    String tile_under_test = "Quick Links";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //[Row(2, 1)]
        //public void Verify_QuickLinksForSales_Tile(int x, int y)
        //{
        //    String tile_under_test = "Quick Links for Sales";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //public void Verify_SFDC_PastDue_Tile(int x, int y)
        //{
        //    String tile_under_test = "SFDC Past Due";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //// SOW says 2x2, but it looked stretched and fuzzy on all browsers, per HTD-17
        //[Test,Parallelizable]
        //[Row(2, 1)]
        //public void Verify_SFDC_PipelineForecastByQtr_Tile(int x, int y)
        //{
        //    String tile_under_test = "SFDC Pipeline Forecast by Quarter";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //public void Verify_SFDC_Activities_Tile(int x, int y)
        //{
        //    String tile_under_test = "SFDC Activites";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(2, 2)]
        //public void Verify_SFDC_OpenAndWon_Tile(int x, int y)
        //{
        //    String tile_under_test = "SFDC Open and Won";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        //[Test,Parallelizable]
        //[Row(1, 1)]
        //public void Verify_MySalesGuide_Tile(int x, int y)
        //{
        //    String tile_under_test = "My Sales Guide";
        //    DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username,password);

        //    List<string> tile_list = dashboard_page.GetAllTileTitles();

        //    // Remove the tile if it is already on the dashboard
        //    if (tile_list.Contains(tile_under_test))
        //    {
        //        dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
        //        .RemoveTile(tile_under_test)
        //        .ClickDone().VerifyTileNotPresent(tile_under_test);
        //    }

        //    dashboard_page.EnterSettings()
        //       .Enter_Tiles()
        //       .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
        //       .ClickDone()
        //       .VerifyTileSize(tile_under_test, x, y)
        //       .EnterSettings().sidebar.RearrangeTiles()
        //       .RemoveTile(tile_under_test)
        //       .ClickDone().VerifyTileNotPresent(tile_under_test);
        //}

        [Test, Parallelizable]
        [Row(2, 1)]
        [Row(2, 2)]
        public void Verify_HP_University_Tile(int x, int y)
        {
            String tile_under_test = "HP University";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                     .LoginAs(username, password)
                      .RemoveTileIfPresent(tile_under_test)
                      .EnterSettings()
                      .Enter_Tiles()
                      .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
                      .ClickDone()
                      .VerifyTileSize(tile_under_test, x, y)
                      .VerifyTile(typeof(HPUniversity));
        }
    }
}
