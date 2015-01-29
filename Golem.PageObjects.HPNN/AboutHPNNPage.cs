using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class AboutHPNNPage : BasePageObject
    {

        public Element MainVideo = new Element(By.ClassName("slide-image"));
        public Element RelatedSToriesContainer = new Element(By.ClassName("side-module"));

        public Element StoryLink = new Element(By.ClassName("tile-item-container"));

        public override void WaitForElements()
        {
            MainVideo.Verify().Visible();
            RelatedSToriesContainer.Verify().Visible();
            StoryLink.Verify().Visible();
        }

        public AboutHPNNPage VerifyPageUrl()
        {
            Assert.Contains(driver.Url,"about-hpnn.aspx");
            return this;
        }
    }
}
