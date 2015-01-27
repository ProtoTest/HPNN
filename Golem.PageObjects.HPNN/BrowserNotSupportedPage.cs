using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class BrowserNotSupportedPage : BasePageObject
    {
        public Element BrowserNotSupportedHeader = new Element("BrowserNotSupportedHeader", ByE.Text("Browser Not Supported"));

        public override void WaitForElements()
        {
            BrowserNotSupportedHeader.WaitUntil().Visible();
        }
    }
}
