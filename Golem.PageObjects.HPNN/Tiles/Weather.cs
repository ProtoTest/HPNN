using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN.Tiles
{
    public class Weather : BasePageObject
    {
        public Element Container = new Element(By.Id("weather"));
        public Element Temperature = new Element(By.ClassName("weather_temperature"));
        public Element Location = new Element(By.ClassName("weather_location"));

        public override void WaitForElements()
        {
            Container.FindElement(Temperature).Verify().Present();
            Container.FindElement(Location).Verify().Present();
        }
    }
}
