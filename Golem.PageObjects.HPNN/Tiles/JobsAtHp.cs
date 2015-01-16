using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class JobsAtHp : BasePageObject
    {
        public Element Container = new Element(By.Id("Jobs-at-HP"));
        public Element Title = new Element(By.ClassName("tile-title"));
        public Element Link = new Element(By.XPath("//a[@target='_blank']"));
        
        public override void WaitForElements()
        {
            Container.FindElement(Link).Verify().Present();
        }
    }
}
