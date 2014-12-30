using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.UIElements;
using ProtoTest.Golem.WebDriver.UIElements.Types;

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
            DisclaimerText.Verify().Visible();
            PersonalizeLink.Verify().Visible();
            AboutHPNNLink.Verify().Visible();
            ArchiveLink.Verify().Visible();
            EditorialCorrectionLink.Verify().Visible();
            ContactUsLink.Verify().Visible();
            MeetTheTeamLink.Verify().Visible();
            RSSLink.Verify().Visible();
            HPCopyRight.Verify().Visible();
               
        }
    }
}
