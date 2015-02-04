using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFindigElements
{

    public class Driver
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/chapter1");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void FindButtonByID()
        {
            IWebElement element = driver.FindElement(By.Id("verifybutton"));
            IWebElement element2 = driver.FindElement(By.Name("selected(1234)"));
            List<IWebElement> elements = driver.FindElements(By.ClassName("storetext")).ToList();

            Assert.AreEqual(24, element.Size.Height);
            Assert.AreEqual(13, element2.Size.Height);
            Assert.AreNotEqual(0, elements.Count);
        }

        [Test]
        public void ImplicitlyWaits()
        {
            //driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 10));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            List<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='ajaxdiv']")).ToList();

            Assert.AreNotEqual(0, elements.Count);
        }

        [Test]
        public void ExplicitlyWaits()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement myDynamicElement = wait.Until<IWebElement>((d) => 
            {
                try
                {
                    return d.FindElement(By.XPath("//div[@id='ajaxdiv']"));
                }
                catch
                {
                    return null;
                }
            });

            Assert.IsNotNull(myDynamicElement);
        }
    }
}
