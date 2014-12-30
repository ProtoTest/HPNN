using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
 
    public class LoadingPanel : BasePageObject
    {
        public Element LoadingAnimation = new Element("Loading Animation", By.Id("preloadAnim"));

        public override void WaitForElements()
        {
            for (var i = 0; i < 20; i++)
            {
                Thread.Sleep(5000);
                if (!LoadingAnimation.Displayed)
                {
                    return;
                }
                else
                {
                    Common.Log("Loading animation still present, refreshing page");
                    driver.Navigate().Refresh();
                    
                }

            }
            Assert.Fail("Loading panel is still visible after 20 refreshes. ");
        }
    }
}
