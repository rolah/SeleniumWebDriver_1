using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFirefoxDriver
{
    public class Driver
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            FirefoxProfile profile = new FirefoxProfile();

            profile.AddExtension("firebug.xpi");
            profile.SetPreference("extensions.firebug.currentVersion", "99,9");

            driver = new FirefoxDriver(profile);

            driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/chapter4");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestExample()
        {
            IWebElement element = driver.FindElement(By.Id("nextBid"));
            element.SendKeys("100");        
        }
    }
}
