using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class Marquee : BasePageObject
    {
        public Element Container = new Element(By.Id("marquee"));
        public Element MainImage = new Element(By.ClassName("tile-slide-image"));
        public Element MainTitle = new Element(By.ClassName("tile-slide-title"));
        public Element BackButton = new Element(By.ClassName("flex-prev"));
        public Element NextButton = new Element(By.ClassName("flex-next"));
        public Element ThumbnailImage = new Element(By.ClassName("flex-control-thumbs"));
        public Element MoreStoriesButton = new Element(By.ClassName("tile-archive-link"));

        public override void WaitForElements()
        {
            Container.WaitUntil().Present();
            Container.FindElement(MainImage).Verify().Present();
            Container.FindElement(MainTitle).Verify().Present();
            Container.FindElement(BackButton).Verify().Present();
            Container.FindElement(NextButton).Verify().Present();
            Container.FindElement(ThumbnailImage).Verify().Present();
            Container.FindElement(MoreStoriesButton).Verify().Present();

        }
    }
}
