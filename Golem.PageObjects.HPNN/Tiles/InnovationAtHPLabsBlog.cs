using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class InnovationAtHPLabsBlog : BasePageObject
    {
        public static Element Container = new Element(By.Id("hp-innovation-blog"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element DateLabel = new Element(By.ClassName("issuelink"));
        public Element Image = new Element(By.ClassName("news-image"));
        public Element Link = new Element(By.ClassName("tile-link"));
        public Element PaginationControlContainer = new Element(By.ClassName("standard-carousel-pager-controls"));
        public Element PageOneLink = new Element(By.LinkText("1"));
        public Element PageTwoLink = new Element(By.LinkText("2"));
        public Element PageThreeLink = new Element(By.LinkText("3"));
        public Element PageFourLink = new Element(By.LinkText("4"));

        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Sales Essentials Headlines");
            Container.FindElement(DateLabel).Verify().Visible();
            Container.FindElement(Image).Verify().Present();
            Container.FindElement(Link).Verify().Present();
        }
    }
}
