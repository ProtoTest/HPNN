using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN;
using Golem.PageObjects.HPNN.Tiles;
using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.Tests.HPNN
{
    class AccountNewsTileTests : WebDriverTestBase
    {

        string username = Config.GetConfigValue("AdminEmail", "chris.bower@hp.com");
        string password = Config.GetConfigValue("AdminPassword", "Sanders76");
        [Test]
        public void Test2x1()
        {
            String tile_under_test = "Account News";
            SSOLoginPage.OpenSSOLoginPage(Config.Settings.runTimeSettings.EnvironmentUrl)
                .LoginAs(username, password)
                .RemoveTileIfPresent(tile_under_test)
                .EnterSettings()
                .Enter_Tiles()
                .AddAccountNews(String.Format("{0}x{1}", 2, 1))
                .RemoveNameIfPresent("JOHNSON")
                .EnterName("JOHNSON CONTROLS INC")
                .VerifyNameIsPresent("JOHNSON CONTROLS INC")
                .Done()
                .ClickDone()
                .VerifyTileSize(tile_under_test, 2, 1)
                .Tile<AccountNews>()
                .VerifyAccountSource("JOHNSON CONTROLS INC");
        }

        //add new name
        //remove name
        //changing configuration
        //delete tile
        
    }
}
