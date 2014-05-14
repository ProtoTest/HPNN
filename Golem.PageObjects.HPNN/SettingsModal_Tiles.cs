using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{
    public class SettingsModal_Tiles : BasePageObject
    {
        SettingsModal_Sidebar sidebar = new SettingsModal_Sidebar();

        Element PageHeading_Label = new Element("News Feeds Heading Label", By.LinkText("Activate Tiles"));

        public override void WaitForElements()
        {
            PageHeading_Label.Verify().Visible();
        }
        public void InactiveTiles() { 
            Element tilesToActivate = new Element(By.XPath("//div[@id='settings-tiles-tab-1']/div[1]/div/div"));
            List<Element> t = new List<Element>();
            foreach (Element a in tilesToActivate.FindElements(By.TagName("ng-repeat"))) {
                t.Add(a);
            }
        }
    }
}
