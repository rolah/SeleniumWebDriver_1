using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUserInteractions
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo2.html");
        }

        [Test]
        public void TestExample()
        {
            IWebElement someElement = driver.FindElement(By.ClassName("draggable"));
            IWebElement otherElement = driver.FindElement(By.Name("droppable"));

            Actions builder = new Actions(driver);
            IAction dragAndDrop = builder.ClickAndHold(someElement)
                .MoveToElement(otherElement)
                .Release(otherElement)
                .Build();
        }

        [Test]
        public void TestDragAndDropToOffset()
        {
            IWebElement drag = driver.FindElement(By.ClassName("draggable"));

            Actions builder = new Actions(driver);
            IAction dragAndDrop = builder.DragAndDropToOffset(drag, 10, 20)
                .Build();
        }

        [Test]
        public void TestContextClick()
        {
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo1.html");
            Actions builder = new Actions(driver);
            IWebElement element = driver.FindElement(By.TagName("body"));
            IAction contextClick = builder.ContextClick(element).Build();
            contextClick.Perform();
        }

        [Test]
        public void TestHoldingMouseButtonDownAndMoving()
        {
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo1.html");
            Actions builder = new Actions(driver);
            IWebElement canvas = driver.FindElement(By.Id("tutorial"));
            IAction dragAndDrop = builder.ClickAndHold(canvas)
                .MoveByOffset(-20, -60)
                .MoveByOffset(20, 20)
                .MoveByOffset(100, 150)
                .Build();

            dragAndDrop.Perform();
        }

        [Test]
        public void TestHoldingMouseButtonDownAndMoving2()
        {
            driver.Navigate().GoToUrl("http://www.theautomatedtester.co.uk/demo1.html");
            Actions builder = new Actions(driver);
            IWebElement canvas = driver.FindElement(By.Id("tutorial"));
            IAction dragAndDrop = builder.ClickAndHold(canvas)
                .MoveByOffset(-20, -60)
                .MoveByOffset(20, 20)
                .MoveByOffset(100, 150)
                .Build();

            dragAndDrop.Perform();

            dragAndDrop = builder
                .MoveByOffset(-400, -600)
                .MoveByOffset(200, 200)
                .MoveByOffset(100, 150)
                .Build();

            dragAndDrop.Perform();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
