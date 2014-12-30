using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class MostLiked : BasePageObject
    {
        public Element Container = new Element(By.Id("Story-most-liked"));
        public Element TileTitle = new Element(By.ClassName("tile-title"));
        public Element Link = new Element(By.ClassName("tile-link"));
 
        public override void WaitForElements()
        {
            Container.FindElement(TileTitle).Verify().Text("Most Liked");
            //Container.FindElement(Link).Verify().Visible();
        }
    }
}
