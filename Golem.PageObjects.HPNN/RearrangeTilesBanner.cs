using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golem.PageObjects.HPNN
{
    public class ReArrangeTilesBanner : BasePageObject
    {

        private Element banner = new Element(By.ClassName("container"));
        Element buttonDone = new Element(By.Id("reorder-finished"));
        Element buttonCancel = new Element(By.Id("reorder-canceled"));

        public override void WaitForElements()
        {
            banner.Verify().Visible();
            buttonDone.Verify().Visible();
            buttonCancel.Verify().Visible();
        }

        public DashboardPage ClickDone()
        {
            buttonDone.Click();
            return new DashboardPage();
        }

        public DashboardPage ClickCancel()
        {
            buttonCancel.Click();
            return new DashboardPage();
        }
    }
}