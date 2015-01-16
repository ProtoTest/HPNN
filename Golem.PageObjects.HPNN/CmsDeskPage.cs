using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class CmsDeskPage : BasePageObject
    {
        public DashboardPage OpenDashoard(string env)
        {
            driver.Navigate().GoToUrl(env);
            return new DashboardPage();
        }

        public override void WaitForElements()
        {
           
        }
    }
}
