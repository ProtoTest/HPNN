using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN.SettingsModal
{

    public class Sidebar : BasePageObject
    {
        public Element UserText = new Element(By.XPath("//div[@class='personal-info']/h3"));
        public Element AvatarImage = new Element(By.ClassName("headshot"));
        public Element UseMyHPPhotoButton = new Element(By.Id("update-profile-pic"));
        public Element MyTilesButton = new Element(By.Id("my-tiles"));
        public Element MyFeedsButton = new Element(By.LinkText("My Feeds"));
        public Element ReplayTutorialButton = new Element(By.LinkText("Replay Tutorial"));
        public Element AboutHPNNButton = new Element(By.LinkText("About HP News Now"));

        public MyTiles MyTiles()
        {
            MyTilesButton.Click();
            return new MyTiles();
        }

        public MyFeeds MyFeeds()
        {
            MyFeedsButton.Click();
            return new MyFeeds();
        }

        public EditDashboardPage RearrangeTiles()
        {
            return MyTiles().Personalize();
        }

        public override void WaitForElements()
        {
            UserText.Verify().Visible();
            UseMyHPPhotoButton.Verify().Visible();
            MyTilesButton.Verify().Visible();
            MyFeedsButton.Verify().Visible();
            ReplayTutorialButton.Verify().Visible();
            AboutHPNNButton.Verify().Visible();
        }
    }


}
