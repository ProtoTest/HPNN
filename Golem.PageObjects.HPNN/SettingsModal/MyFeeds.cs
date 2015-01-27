using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN.SettingsModal;
using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class MyFeeds : BasePageObject
    {
        Sidebar sidebar = new Sidebar();

        Element PageHeading_Label = new Element("My Feeds label", ByE.Text("My Feeds"));
        private Element LinkedInButton = new Element("LinkedInButton", By.ClassName("linkedin"));
        private Element FacebookButton = new Element("FacebookButton", By.ClassName("facebook"));
        private Element TwitterButton = new Element("TwitterButton", By.ClassName("twitter"));
        private Element ChatterButton = new Element("TwitterButton", By.ClassName("chatter"));

        private Element ShowOnlyActiveFeedsCheckbox = new Element("ShowActiveFeedsCheckbox", By.Id("check-showOnlySubscribed"));
        private Element AddRSSField = new Element("AddRssField", By.XPath("//input[@ng-model='RSSCustomFeedUrl']"));
        private Element AddFeedbutton = new Element("AddFeedbUtton", By.XPath("//button[text()='Add Feed']"));
        private Element DoneButton = new Element("DoneButton", By.LinkText("Done"));
        private Element CloseButton = new Element("CloseButton",By.ClassName("done"));
        private Element FeedButton = new Element("FeedButton", By.XPath("//label[text()='{0}']"));
        private Element ErrorMessage = new Element("ErrorMessage", By.XPath("//span[@ng-show='serverMessage']"));

        public override void WaitForElements()
        {

            PageHeading_Label.Verify().Present();
            LinkedInButton.Verify().Present();
            FacebookButton.Verify().Present();
            ShowOnlyActiveFeedsCheckbox.Verify().Present();
            AddRSSField.Verify().Present();
            AddFeedbutton.Verify().Present();
            DoneButton.Verify().Present();
            CloseButton.Verify().Present();
            ErrorMessage.Verify().Not().Visible();
        }

        public MyFeeds AddFeed(string url)
        {
            AddRSSField.SetText(url);
            AddFeedbutton.Click();
            return new MyFeeds();
        }

        public DashboardPage ClickDone()
        {
            DoneButton.Click();
            return new DashboardPage();
        }

        public MyFeeds VerifyErrorMessageVisible()
        {
            ErrorMessage.Verify().Visible();
            return this;
        }




    }
}
