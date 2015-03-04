using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest.Classes
{
    class LoginForm
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "link-signup")]
        private IWebElement LinkSignUp;

        public LoginForm(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

            this.driver = driver;

            if (!String.Equals(driver.Title, "Bejelentkezés – Google-fiók"))
            {
                throw new InvalidOperationException("This is not the Login page");
            }
        }

        public RegistrationForm clickNewRegistrationLink()
        {
            LinkSignUp.Click();

            return new RegistrationForm(driver);        
        }
    }
}
