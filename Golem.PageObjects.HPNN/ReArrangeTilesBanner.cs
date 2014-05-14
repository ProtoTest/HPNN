using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golem.PageObjects.HPNN
{
    class ReArrangeTilesBanner : BasePageObject
    {
            
            Element banner = new Element(By.XPath("//div[(./div/p[text()='Drag and Drop to Rearrange Tiles'])"));
            Element buttonDone = new Element(By.Id("reorder-finished"));
            Element buttonCancel = new Element(By.Id("reorder-canceled"));

            public override void WaitForElements()
            {
                banner.Verify().Visible();
                buttonDone.Verify().Visible();
                buttonCancel.Verify().Visible();
            }
            public void ClickOnDoneButton(Boolean trueOrFalse=false) {
                if (trueOrFalse) {
                    buttonDone.Click();
                }else{
                    buttonCancel.Click();
                }
            }
    }
}
