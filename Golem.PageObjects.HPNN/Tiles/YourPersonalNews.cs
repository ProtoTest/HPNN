using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class YourPersonalNews : BasePageObject
    {
        public Element Container = new Element(By.Id("personal-news"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element RefreshButton = new Element(By.Id("refreshImage"));
        public Element MyFeedsButton = new Element(ByE.Text("My Feeds"));

        public Element ContentItemForFeed = new Element(By.XPath("//li[@class='tile-slide']//p[text()='{0}']"));

        public YourPersonalNews VerifyFeedItemPresent(string name)
        {
            ContentItemForFeed.WithParam(name).Verify().Present();
            return this;
        }

        public YourPersonalNews VerifyFeedItemNotPresent(string name)
        {
            ContentItemForFeed.WithParam(name).Verify().Not().Present();
            return this;
        }

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Your Personal News");
            Container.FindElement(MyFeedsButton).Verify().Visible();
            Container.FindElement(RefreshButton).Verify().Visible();
        }
    }
}
