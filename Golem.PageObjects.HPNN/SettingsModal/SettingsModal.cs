using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.SettingsModal
{
    
    public class SettingsModal : BasePageObject
    {
        public Sidebar sidebar = new Sidebar();
        public Element ReplayTutorialButotn = new Element(By.LinkText("Replay Tutorial"));

        public TutorialOverview ReplayTutorial()
        {
            ReplayTutorialButotn.Click();
            return new TutorialOverview();
        }
       
        public MyFeeds Enter_NewsFeeds()
        {
            sidebar.MyFeedsButton.Click();
            return new MyFeeds();
        }

        public MyTiles Enter_Tiles()
        {
            sidebar.MyTilesButton.Click();
            return new MyTiles();
        }

        public override void WaitForElements()
        {
            
        }
    }
}
