using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golem.PageObjects.HPNN
{
    class Marquee : BasePageObject
    {
        Element marquee = new Element("Marquee", By.Id("marquee"));
        Element flexActiveSlide = new Element("Flex active slide",By.XPath("//div[@id='marquee']/div/div/div/div/div/div/ul/li[contains(@class,'flex-active-slide')]"));
        Element sliderLeft = new Element("Slider Left", By.XPath("//div[@id='marquee']/div/div/div/div/div/ul[@class='flex-direction-nav']/li/a[@class='flex-prev']"));
        Element sliderRight = new Element("Slider Right", By.XPath("//div[@id='marquee']/div/div/div/div/div/ul[@class='flex-direction-nav']/li/a[@class='flex-next']"));
        Element flexControlThumb = new Element("Flex Control Thumb", By.XPath("//div[@id='marquee']/div/div/div/div/div/ol[@class='flex-control-nav flex-control-thumbs']/li/img[@class='flex-active']"));
        public override void WaitForElements()
        {
            marquee.Verify().Visible();
            flexActiveSlide.Verify().Visible();
            sliderLeft.Verify().Visible();
            sliderRight.Verify().Visible();
            flexControlThumb.Verify().Visible();
        }

        public void ClickOnSliderAndCompareThumbs(Boolean leftSlider)
        {
            if (leftSlider)
            {
                sliderLeft.Click();
            }
            else
            {
                sliderRight.Click();
            }
            this.flexActiveSlide = new Element(By.XPath("//div[@id='marquee']/div/div/div/div/div/div/ul/li[contains(@class,'flex-active-slide')]"));
            this.flexControlThumb = new Element(By.XPath("//div[@id='marquee']/div/div/div/div/div/ol[@class='flex-control-nav flex-control-thumbs']/li/img[@class='flex-active']"));
            String flexThumb = this.flexControlThumb.GetAttribute("src");
            String flexSlide = this.flexActiveSlide.GetAttribute("data-thumb");
            if (!flexThumb.Equals(flexSlide)) { 
                throw new ArgumentException("There are no matches between flex image and flex thumb");
            }
        }
    
    }
}
