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
    public class SalesUserTileTests : WebDriverTestBase
    {
        string username = Config.GetConfigValue("SalesEmail", "asdf@hp.com");
        string password = Config.GetConfigValue("SalesPassword", "1234");

        [Test, Parallelizable]
        [Row(2, 1)]
        public void Verify_MyComp_Tile(int x, int y)
        {
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .RemoveTileIfPresent("MyComp")
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType("MyComp", String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize("MyComp", x, y)
                .VerifyTile(typeof(MyComp));
        }

        [Test, Parallelizable]
        [Row(1, 1)]
        [Row(1, 2)]
        public void Verify_QuickLinksForSales_Tile(int x, int y)
        {
            String tile_under_test = "Sales Quick Links";
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .RemoveTileIfPresent(tile_under_test)
                .EnterSettings()
                .Enter_Tiles()
                .AddQuickLinksTile(tile_under_test, String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize(tile_under_test, x, y)
                .VerifyTile(typeof (SalesQuickLinks));
        }

        [Test, Parallelizable]
          [Row(2,2)]
          public void Verify_Current_FY_Pipeline_Tile(int x, int y)
          {
              String tile_under_test = "Current FY Pipeline";
              KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .RemoveTileIfPresent(tile_under_test)
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize(tile_under_test, x, y)
                .VerifyTile(typeof(CurrentFYPipeline));
          }

    
        [Test, Parallelizable]
        [Row(2,2)]
        public void Verify_SFDC_PipelineForecastByQtr_Tile(int x, int y)
        {
            String tile_under_test = "SFDC Pipeline Forecast by Quarter";
            KenticoLoginPage.OpenKenticoLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .RemoveTileIfPresent(tile_under_test)
                .EnterSettings()
                .Enter_Tiles()
                .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
                .ClickDone()
                .VerifyTileSize(tile_under_test, x, y)
                .VerifyTile(typeof(SFDCPipeline));
        }

      //  [Test, Parallelizable]
      //  [Row(1, 1)]
      //  public void Verify_SFDC_Activities_Tile(int x, int y)
      //  {
      //      String tile_under_test = "SFDC Activites";
      //      DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username, password);

      //      List<string> tile_list = dashboard_page.GetAllTileTitles();

      //       Remove the tile if it is already on the dashboard
      //      if (tile_list.Contains(tile_under_test))
      //      {
      //          dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
      //          .RemoveTile(tile_under_test)
      //          .ClickDone().VerifyTileNotPresent(tile_under_test);
      //      }

      //      dashboard_page.EnterSettings()
      //         .Enter_Tiles()
      //         .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
      //         .ClickDone()
      //         .VerifyTileSize(tile_under_test, x, y)
      //         .EnterSettings().sidebar.RearrangeTiles()
      //         .RemoveTile(tile_under_test)
      //         .ClickDone().VerifyTileNotPresent(tile_under_test);
      //  }

      //  [Test, Parallelizable]
      //  [Row(2, 2)]
      //  public void Verify_SFDC_OpenAndWon_Tile(int x, int y)
      //  {
      //      String tile_under_test = "SFDC Open and Won";
      //      DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username, password);

      //      List<string> tile_list = dashboard_page.GetAllTileTitles();

      //       Remove the tile if it is already on the dashboard
      //      if (tile_list.Contains(tile_under_test))
      //      {
      //          dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
      //          .RemoveTile(tile_under_test)
      //          .ClickDone().VerifyTileNotPresent(tile_under_test);
      //      }

      //      dashboard_page.EnterSettings()
      //         .Enter_Tiles()
      //         .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
      //         .ClickDone()
      //         .VerifyTileSize(tile_under_test, x, y)
      //         .EnterSettings().sidebar.RearrangeTiles()
      //         .RemoveTile(tile_under_test)
      //         .ClickDone().VerifyTileNotPresent(tile_under_test);
      //  }

      //  [Test, Parallelizable]
      //  [Row(1, 1)]
      //  public void Verify_MySalesGuide_Tile(int x, int y)
      //  {
      //      String tile_under_test = "My Sales Guide";
      //      DashboardPage dashboard_page = SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl).LoginAs(username, password);

      //      List<string> tile_list = dashboard_page.GetAllTileTitles();

      //       Remove the tile if it is already on the dashboard
      //      if (tile_list.Contains(tile_under_test))
      //      {
      //          dashboard_page = dashboard_page.EnterSettings().sidebar.RearrangeTiles()
      //          .RemoveTile(tile_under_test)
      //          .ClickDone().VerifyTileNotPresent(tile_under_test);
      //      }

      //      dashboard_page.EnterSettings()
      //         .Enter_Tiles()
      //         .AddTileWithType(tile_under_test, String.Format("{0}x{1}", x, y))
      //         .ClickDone()
      //         .VerifyTileSize(tile_under_test, x, y)
      //         .EnterSettings().sidebar.RearrangeTiles()
      //         .RemoveTile(tile_under_test)
      //         .ClickDone().VerifyTileNotPresent(tile_under_test);
      //  }

    }
}
