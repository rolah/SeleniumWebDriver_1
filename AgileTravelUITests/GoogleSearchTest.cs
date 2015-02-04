using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace AgileTravelUITests
{
    /// <summary>
    /// Summary description for GoogleSearchTest
    /// </summary>
    [TestClass]
    public class GoogleSearchTest
    {
        public GoogleSearchTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSearchFF()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement element = driver.FindElement(By.Name("q"));

            element.SendKeys("Hi Selenium WebDriver!");

            element.Submit();
        }

        [TestMethod]
        public void TestSearchIE()
        {
            IWebDriver driver = new InternetExplorerDriver();

            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("Hi Selenium WebDriver!");

            element.Submit();
        }

        [TestMethod]
        public void TestSearchChrome()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement element = driver.FindElement(By.Name("q"));

            element.SendKeys("Hi Selenium WebDriver!");

            element.Submit();
        }


        [TestMethod]
        public void TestLinks()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://testwisely.com/demo");

            driver.FindElement(By.LinkText("Recommend Selenium")).Click();

            driver.FindElement(By.PartialLinkText("Recommend Selenium")).Click();

            driver.FindElement(By.XPath("//p/a[text()='Recommend Selenium']")).Click();

            driver.FindElement(By.XPath("//div[contains(text(), \"Second\")]/a[text()=\"Click here\"]")).Click();

            driver.FindElement(By.CssSelector("p > a:nth-child(3)")).Click();

            Assert.IsTrue(driver.FindElement(By.LinkText("Recommend Selenium")).Displayed);

            Assert.AreEqual("recommend_selenium_link", driver.FindElement(By.LinkText("Recommend Selenium")).GetAttribute("id"));
            Assert.AreEqual("Recommend Selenium", driver.FindElement(By.Id("recommend_selenium_link")).Text);
            Assert.AreEqual("a", driver.FindElement(By.Id("recommend_selenium_link")).TagName);
            Assert.AreEqual("font-size: 14px;", driver.FindElement(By.Id("recommend_selenium_link")).GetAttribute("style"));
        }


        [TestMethod]
        public void TestOpenNewLink()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://testwisely.com/demo");

            String currentUrl = driver.Url;

            String newWindowUrl = driver.FindElement(By.LinkText("Survey")).GetAttribute("href");

            driver.Navigate().GoToUrl(newWindowUrl);

            driver.FindElement(By.Name("comment")).SendKeys("sometext");

            driver.Navigate().GoToUrl(currentUrl);
        }

        [TestMethod]
        public void TestButtonClick()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://testwisely.com/demo/survey");

            driver.FindElement(By.XPath("//input[@value = 'Show Solution']")).Click();

            //driver.FindElement(By.XPath("//input[contains(@src, 'button_go.jpg')]")).Click();

        }

        [TestMethod]
        public void TestButtonIsEnalbed()
        {
            IWebDriver driver = new FirefoxDriver();

           // driver.Navigate().GoToUrl("http://www.w3schools.com/tags/tryit.asp?filename=tryhtml_button_disabled");

            driver.Navigate().GoToUrl("http://www.w3schools.com/tags/tryit.asp?filename=tryhtml_button_test");

            driver.FindElement(By.XPath("//button[contains(text(),'Click Me!')]"));

            Assert.IsTrue(driver.FindElement(By.XPath("//button[contains(text(),'Click Me!')]")).Enabled);       
        }
    }
}
