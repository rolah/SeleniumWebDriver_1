using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation
{
    [TestFixture]
    public class Driver
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Create a new instance of the Firefox driver
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void GoogleSearch()
        {
            //Navigate to the site
            driver.Navigate().GoToUrl("http://www.google.com.au");
            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));
            // Enter something to search for
            query.SendKeys("Selenium");
            // Now submit the form
            query.Submit();
            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 5 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until((d) => { return d.Title.StartsWith("Selenium"); });
            //Check that the Title is what we are expecting
            Assert.AreEqual("Selenium - Google keresés", driver.Title);
        }
    }
}
