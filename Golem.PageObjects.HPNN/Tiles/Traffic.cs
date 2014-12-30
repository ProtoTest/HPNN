using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class Traffic : BasePageObject
    {
        public Element Container = new Element(By.Id("traffic"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element ToggleDirectionButton = new Element(By.Id("toggle-direction"));
        public Element RefreshTraffic = new Element(By.Id("refresh-traffic"));
        public Element TrafficLink = new Element(By.ClassName("traffic"));
        public Element RouteLink = new Element(By.ClassName("route"));
        public Element UpdatedTime = new Element(By.ClassName("updatedTime"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Traffic");
            Container.FindElement(ToggleDirectionButton).Verify().Visible();
            Container.FindElement(RefreshTraffic).Verify().Visible();
            Container.FindElement(TrafficLink).Verify().Visible();
            Container.FindElement(RouteLink).Verify().Visible();
            Container.FindElement(UpdatedTime).Verify().Visible();
        }
    }
}
