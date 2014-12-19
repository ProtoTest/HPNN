using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class EditDashboardPage : DashboardPage
    {
        public ReArrangeTilesBanner rearrangeBanner = new ReArrangeTilesBanner();
        public EditDashboardPage DragTileToFirstPosition(string title)
        {
            var tilePosition = TileWithTitle(title).Location;
            (new Actions(driver)).DragAndDrop(TileWithTitle(title), MarqueeTile).Perform();
            Assert.AreNotEqual(tilePosition, TileWithTitle(title).Location, "The tile's position has not changed");
            return this;
        }

        public DashboardPage ClickDone()
        {
            rearrangeBanner.ClickDone();
            return new DashboardPage();
        }

        public DashboardPage ClickCancel()
        {
            return rearrangeBanner.ClickCancel();
        }

        public EditDashboardPage RemoveTile(string title)
        {
            RemoveButtonForTile(title).Click();
            return new EditDashboardPage();
        }

        public override void WaitForElements()
        {
           // Header.WaitForElements();
            PersonalNewsTile.Verify().Visible();
            RemoveTileDropdown.Verify().Visible();
        }


    }
}
