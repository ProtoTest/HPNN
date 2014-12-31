using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;

namespace Golem.PageObjects.HPNN
{
    public class Footer : BasePageObject
    {
        public Element FooterContainer = new Element(By.ClassName("footer"));
        public Element DisclaimerText = new Element(By.ClassName("ft-text"));
        public Element PersonalizeLink = new Element(By.LinkText("Personalize"));
        public Element AboutHPNNLink = new Element(By.LinkText("About HPNN"));
        public Element ArchiveLink = new Element(By.LinkText("Archive"));
        public Element EditorialCorrectionLink = new Element(By.LinkText("Editorial correction"));
        public Element ContactUsLink = new Element(By.LinkText("Contact us"));
        public Element MeetTheTeamLink = new Element(By.LinkText("Meet the team"));
        public Element RSSLink = new Element(By.ClassName("FeedLink"));
        public Element HPCopyRight = new Element(ByE.Text("© 2014 Hewlett-Packard Development Company, LP."));


        public override void WaitForElements()
        {
            FooterContainer.Verify().Present();
            
               
        }

        public void VerifyAllFooterPresent()
        {
            FooterContainer.FindElement(DisclaimerText).Verify().Visible();
            // FooterContainer.FindElement(PersonalizeLink).Verify().Visible();
            FooterContainer.FindElement(AboutHPNNLink).Verify().Visible();
            FooterContainer.FindElement(ArchiveLink).Verify().Visible();
            FooterContainer.FindElement(EditorialCorrectionLink).Verify().Visible();
            FooterContainer.FindElement(ContactUsLink).Verify().Visible();
            FooterContainer.FindElement(MeetTheTeamLink).Verify().Visible();
            FooterContainer.FindElement(RSSLink).Verify().Visible();
            FooterContainer.FindElement(HPCopyRight).Verify().Visible();
        }
        
    }
}
