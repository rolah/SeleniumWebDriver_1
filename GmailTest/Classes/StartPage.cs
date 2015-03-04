using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest.Classes
{
    class StartPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "gb_70")]
        private IWebElement LogInButton;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);

            if (!String.Equals(driver.Title, "Google"))
            {
                throw new InvalidOperationException("This is not Google start page!");
            }
        }

        public LoginForm clickLoginButton()
        {
            LogInButton.Click();

            return new LoginForm(driver);
        }
    }
}
