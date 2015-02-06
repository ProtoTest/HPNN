using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Golem.PageObjects.HPNN.SettingsModal;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.HPNN
{

    public class PersonalizeAccountNews : BasePersonalizeTile
    {
        public Sidebar sidebar = new Sidebar();
        public Element CompanyField = new Element("Account Name FIeld", By.Id("select-company"));
        public Element AddButton = new Element(By.CssSelector("input[value=Add]"));
        public Element RemoveLinkForName = new Element(By.CssSelector("li[title~={0}] a"));
        public Element NameList = new Element(By.ClassName("ui-autocomplete"));
        public PersonalizeAccountNews EnterName(string name)
        {
           CompanyField.SendKeys(name);
            NameList.WaitUntil().Visible();
            CompanyField.SendKeys(Keys.Down + Keys.Enter);
            AddButton.Click();
            return this;
        }

        public EditDashboardPage Done()
        {
            DoneButton.WaitUntil().Visible().Click();
            return new EditDashboardPage();
        }

        public PersonalizeAccountNews RemoveNameIfPresent(string name)
        {
            var link = RemoveLinkForName.WithParam(name);
            link.timeoutSec = 5;
            if(link.Present)
                link.WaitUntil().Visible().Click();
            return this;
        }
        public PersonalizeAccountNews VerifyNameIsPresent(string name)
        {
            RemoveLinkForName.WithParam(name).Verify().Visible();
            return this;
        }

        public MyTiles ClickBack()
        {
            BackButton.Click();
            return new MyTiles();
        }

        public override void WaitForElements()
        {
            base.WaitForElements();
            CompanyField.Verify().Present();
            AddButton.Verify().Present();
            DoneButton.Verify().Present();
            RemoveButton.Verify().Present();
        }
    }
}
