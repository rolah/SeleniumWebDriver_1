using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailTest.Classes
{
    class RegistrationForm
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "GmailAddress")]
        private IWebElement GmailAddress;

        [FindsBy(How = How.Id, Using = "Passwd")]
        private IWebElement Passwd;

        [FindsBy(How = How.Id, Using = "PasswdAgain")]
        private IWebElement PasswdAgain;

        [FindsBy(How = How.Id, Using = "BirthYear")]
        private IWebElement BirthYear;

        [FindsBy(How = How.Id, Using = "HiddenBirthMonth")]
        private IWebElement HiddenBirthMonth;

        [FindsBy(How = How.Id, Using = "BirthDay")]
        private IWebElement BirthDay;

        [FindsBy(How = How.Id, Using = "HiddenGender")]
        private IWebElement HiddenGender;

        [FindsBy(How = How.Id, Using = "RecoveryEmailAddress")]
        private IWebElement RecoveryEmailAddress;

        [FindsBy(How = How.Id, Using = "SkipCaptcha")]
        private IWebElement SkipCaptcha;

        [FindsBy(How = How.Id, Using = "TermsOfService")]
        private IWebElement TermsOfService;

        [FindsBy(How = How.Id, Using = "submitbutton")]
        private IWebElement Submitbutton;

        public RegistrationForm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            if (!String.Equals(driver.Title, "Google-fiók létrehozása"))
            {
                throw new InvalidOperationException("This is not the Registration page");
            }
        }

        public RegistrationForm typeLastName(string lastName)
        {
            LastName.SendKeys(lastName);

            return this;        
        }

        public RegistrationForm typeFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);

            return this;
        }

        public RegistrationForm typeGmailAddress(string gmailAddress)
        {
            GmailAddress.SendKeys(gmailAddress);

            return this;
        }

        public RegistrationForm typePasswd(string passwd) {

            Passwd.SendKeys(passwd);
            
            return this;        
        }

        public RegistrationForm typePasswAgain(string passwdagain)
        {
            PasswdAgain.SendKeys(passwdagain);

            return this;        
        }

        public RegistrationForm typeBirthYear(string birthYear) 
        {
            BirthYear.SendKeys(birthYear);

            return this;            
        }

        public RegistrationForm typeHiddenBirthMonth(string hiddenBirthMonth)
        {
            HiddenBirthMonth.SendKeys(hiddenBirthMonth);

            return this;
        }

        public RegistrationForm typeBirthMonth(string birthMonth)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript(String.Format("document.getElementById('HiddenBirthMonth').value = '{0}';", birthMonth));
           
            return this;
        }

        public RegistrationForm typeBirthDay(string birthDay)
        {
            BirthDay.SendKeys(birthDay);

            return this;
        }

        public RegistrationForm typeHiddenGender(string hiddenGender)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript(String.Format("document.getElementById('HiddenGender').value = '{0}';", hiddenGender));
        
            return this;
        }

        public RegistrationForm typeRecoveryEmailAddress(string recoveryEmailAddress)
        {               
            RecoveryEmailAddress.SendKeys(recoveryEmailAddress);

            return this;        
        }

        public RegistrationForm clickSkipCaptcha()
        {
            SkipCaptcha.Click();

            return this;
        }

        public RegistrationForm clickTermsOfService()
        {
            TermsOfService.Click();

            return this;        
        }

        public RegistrationForm clickSubmitButton()
        {
            Submitbutton.Click();

            return this;
        }
    }
}
