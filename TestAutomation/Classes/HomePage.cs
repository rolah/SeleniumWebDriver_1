using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Classes
{
    public class HomePage
    {
        IWebDriver selenium;

        public HomePage(IWebDriver selenium)
        {
            this.selenium = selenium;
        }

        public Chapter2 clickChapter2() 
        {
            clickChapter("2");
            return new Chapter2(selenium);
        }

        private void clickChapter(string number)
        {
            selenium.FindElement(By.LinkText("Chapter" + number)).Click();
        }
    }
}