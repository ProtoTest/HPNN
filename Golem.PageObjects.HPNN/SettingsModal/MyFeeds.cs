using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN.SettingsModal;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.HPNN
{
    public class MyFeeds : BasePageObject
    {
        Sidebar sidebar = new Sidebar();

        Element PageHeading_Label = new Element("News Feeds Heading Label", ByE.Text("News Feeds"));

        public override void WaitForElements()
        {
            PageHeading_Label.Verify().Present();
        }
    }
}
