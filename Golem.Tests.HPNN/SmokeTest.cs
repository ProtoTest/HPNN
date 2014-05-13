using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.HPNN;
using MbUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Golem.Tests.HPNN
{
    [TestFixture]
    public class SmokeTest : WebDriverTestBase
    {
        [Test, Category("Smoke Test")]
        public void Some_Test()
        {
            DashboardPage.OpenDashboardPage().EnterSettings().Enter_Tiles();
        }

        [Test, Category("Smoke Test")]
        public void Another_Test()
        {
            DashboardPage.OpenDashboardPage().VerifyDefaultTilesDisplayed();
        }
        [Test, Category("Re-arrange tiles functionality")]
        public void Re_arrange_tiles()
        {

// - Verify 'Re-arrange tiles functionality': Verify initially no x's to remove tiles, enter Tile Settings screen. 
//Rearrange Tiles. Remove them, move them, verify banner is displayed 'Drag and Drop to Rearrange Tiles' with Done button. 
//Click done, verify X's are gone.
//- Adding/removing tiles with specific grid size, verify displayed as expected
//- Verifying tile grid sizes (1x1, 2x2) when adding, per the HPNN+ Scope of work
//- Verifying expected available grid sizes
//- Verifying list of default tiles when not logged in
//- Verify content exists in the 'Marque' carousel, verify arrows scroll.


            DashboardPage.OpenDashboardPage();
            DashboardPage dashboard = new DashboardPage();
            List<String> defaultTiles = dashboard.ObtainDefaultTiles();
            foreach (String defaultTile in defaultTiles) {
                dashboard.verifyDefaultTilesWithoutRemoveOption(defaultTile);
            }
            
            dashboard.EnterSettings().RearrangeTiles();
            foreach (String tileTitle in defaultTiles)
            {
                dashboard.verifyTileWithRemoveOption(tileTitle);
            }
            dashboard.verifyBannerAndDoneButton(true);
            foreach (String defaultTile in defaultTiles)
            {
                dashboard.verifyDefaultTilesWithoutRemoveOption(defaultTile);
            }
        }

    }
}
