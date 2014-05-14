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

//- Verifying list of default tiles when not logged in
// - Verify 'Re-arrange tiles functionality': Verify initially no x's to remove tiles, enter Tile Settings screen. 
//Rearrange Tiles. Remove them, move them, verify banner is displayed 'Drag and Drop to Rearrange Tiles' with Done button. 
//Click done, verify X's are gone.
            DashboardPage.OpenDashboardPage();
            DashboardPage dashboard = new DashboardPage();
            List<String> defaultTiles = dashboard.ObtainTilesNamesOnPage();
            dashboard.VerifyTilePresent(defaultTiles[2]);
            dashboard.EnterSettings().RearrangeTiles();
            dashboard.VerifyTilePresent(defaultTiles[2],true);
            dashboard.RemoveTile(defaultTiles[2]);
            dashboard.VerifyReArrangeTilesBanner();
        }
        [Test, Category("Add tiles with specific grid size")]
        public void Add_tiles()
        {
            DashboardPage.OpenDashboardPage();
            DashboardPage dashboard = new DashboardPage();
            //dashboard.EnterSettings().Enter_Tiles().InactiveTiles();
            //- Verifying tile grid sizes (1x1, 2x2) when adding, per the HPNN+ Scope of work
            //- Verifying expected available grid sizes

        }

        [Test, Category("Remove tiles with specific grid size")]
        public void Remove_tiles()
        {
            //removing tiles with specific grid size
        }
        [Test, Category("Verify Marquee Content")]
        public void Verify_Marquee()
        {
            //- Verify content exists in the 'Marque' carousel, verify arrows scroll.
            DashboardPage.OpenDashboardPage();
            DashboardPage dashboard = new DashboardPage();
            dashboard.VerifyMarquee();
        }
    }
}
