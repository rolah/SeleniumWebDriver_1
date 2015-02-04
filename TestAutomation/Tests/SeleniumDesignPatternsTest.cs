using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Classes;

namespace TestAutomation.Tests
{
    [TestFixture]
    class SeleniumDesignPatternsTest
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
        public void CheckPageIsCorrectPage()
        {
            if (!"Page 2".Equals(driver.Title))
            {
                //Navigate to the site
                driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/chapter2");
            }

            Assert.AreEqual("Selenium: Beginners Guide", driver.Title);
        }

        [Test]
        public void shouldCheckButtonOnChapter2Page()
        {
            LoadPage();
            ClickAndLoadChapter2();

            Assert.AreEqual(driver.FindElement(By.Id("but1")).Size, 1);
        }

        [Test]
        public void shouldCheckAnotherButtonOnChapter2Page()
        {
            LoadPage();
            ClickAndLoadChapter2();

            Assert.AreEqual(driver.FindElement(By.Id("verifybutton")).Size, 1);
        }

        //[Test]
        //public void ShouldLoadTheHomePageAndTheCheckButtonOnChapter2() 
        //{
        //    driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk");

        //    HomePage hp = new HomePage(driver);

        //    Chapter2 ch2 = hp.clickChapter2();

        //    Assert.True(ch2.isButtonPresent("but1"));
        //}

        [Test]
        public void ShouldLoadTheHomePageAndTheCheckButtonOnChapter2_v2()
        {
            Chapter2 ch2 = new Chapter2(driver).Load();
            Assert.True(ch2.isButtonDisplayed("but1"));
        }

        [Test]
        public void ShouldLoadTheHomePageAndTheCheckButtonOnChapter2_FindButton()
        {
            Chapter2 ch2 = new Chapter2(driver).Load();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("seleniumtest", ImageFormat.Png);
            ss.ToString();

            Assert.True(ch2.isButtonDisplayed("but2"));
        }

        private void LoadPage()
        {
            driver.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/");
        }

        private void ClickAndLoadChapter2()
        {
            driver.FindElement(By.LinkText("Chapter2")).Click();
        }
    }
}
