using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gallio.Common.Collections;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class TutorialOverview : BasePageObject
    {
        public Element OverviewPanel = new Element("Overview Panel", By.ClassName("introjs-tooltiptext"));
        public Element NextButton = new Element("NextButton", By.ClassName("introjs-nextbutton"));
        public Element StepCountLabel = new Element("StepCountLabel",By.ClassName("intro-js-step-count"));
        public Element ExitButton = new Element("ExitButton",By.LinkText("Exit"));
        public Element TutorialVideosButton = new Element("TutorialVideosButton",By.Id("videoLink"));
        public Element DoneButton = new Element("DoneButton",By.LinkText("Done"));
        public Element StepOne = new Element(By.Id("overlayContentStep1"));
        public Element StepTwo = new Element(By.Id("overlayContentStep2"));
        public Element StepThree = new Element(By.Id("overlayContentStep3"));
        
        public TutorialOverview VerifyStepCount(string num)
        {
            StepCountLabel.Verify().Text(num);
            return new TutorialOverview();
        }

        public TutorialOverview ClickNext()
        {
            NextButton.Click();
            return new TutorialOverview();
        }

        public DashboardPage Exit()
        {
            ExitButton.Click();
            return new DashboardPage();
        }

        //TODO THIS DOESNT WORK BROKEN FUNCTIONALITY ONT HE WEBSTIE
        //public DashboardPage Done()
        //{
        //    DoneButton.Click();
        //    return new DashboardPage();
        //}


        public override void WaitForElements()
        {
            //OverviewPanel.Verify().Visible();
        }

        public DashboardPage CloseTutorial()
        {
            StepOne.WaitUntil(30).Visible().Click();
            StepTwo.WaitUntil(30).Visible().Click();
            StepThree.WaitUntil(30).Visible().Click();
            return new DashboardPage();
        }

        public TutorialOverview ClickStepOne()
        {
            StepOne.Click();
            return this;
        }

        public TutorialOverview ClickStepTwo()
        {
            StepTwo.Click();
            return this;
        }

        public AboutHPNNPage ClickVideoLink()
        {
            TutorialVideosButton.Click();
            return new AboutHPNNPage();
        }

        public DashboardPage VerifyTutorialNotVisible()
        {
            OverviewPanel.Verify().Not().Visible();
            return new DashboardPage();
        }
    }
}
