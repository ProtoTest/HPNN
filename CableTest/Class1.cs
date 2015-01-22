using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace CableTest
{
    public class Class1 : WebDriverTestBase
    {
        private string ADD_JQUERY_LIBRARY =
          "function loadScript(scriptUrl) {var head =  document.getElementsByTagName('head')[0];var script = document.createElement('script');script.type = 'text/javascript';script.src = scriptUrl;head.appendChild(script);}loadScript('https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.js');loadScript('https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.js');return;";

        private string TEST_JQUERY_SCRIPT = "jQuery(function($) {$('input[name=\"q\"]').val('bada-bing').closest('form').submit();});return; ";

        [Test]
        public void test()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            var js = (IJavaScriptExecutor) driver;
            Thread.Sleep(5000);
            js.ExecuteScript(ADD_JQUERY_LIBRARY);
            Thread.Sleep(5000);
            driver.ExecuteJavaScript(TEST_JQUERY_SCRIPT);
            Thread.Sleep(5000);

            
        }

    }
}
