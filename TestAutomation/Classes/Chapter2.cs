using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Classes
{
    public class Chapter2 : LoadableComponent<Chapter2>
    {
        IWebDriver selenium;

        [FindsBy(How = How.Name, Using = "verifybutton")]
        IWebElement verifybutton;

        public Chapter2(IWebDriver selenium)
        {
            this.selenium = selenium;

            PageFactory.InitElements(selenium, this);

            if (!"Chapter 2".Equals(this.selenium.Title))
            {
                selenium.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/chapter2");
            }
        }

        protected override void ExecuteLoad()
        {
            selenium.Navigate().GoToUrl("http://book.theautomatedtester.co.uk/chapter2");
        }
        
        protected override bool EvaluateLoadedStatus()
        {
            String url = selenium.Url;
            

            //if (url != "http://book.theautomatedtester.co.uk/chapter2")
            //{
            //    throw new Exception("The wrong page has loaded");           
            //}

            return true;
        }

        //public bool isButtonPresent(string button)
        //{
        //    return selenium.FindElement(By.XPath("//input[@id='" + button + "']")).Size.Width > 0;
        //}

        public bool isButtonDisplayed(string button)
        {
            return selenium.FindElement(By.Id(button)).Displayed;       
        }
    }
}