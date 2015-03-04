using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using GmailTest.Classes;

namespace GmailTest
{
    public class GmailTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void Test2()
        {
            var startPage = new StartPage(driver);
            var loginForm = startPage.clickLoginButton();
            var registrationForm = loginForm.clickNewRegistrationLink();

            registrationForm.typeFirstName("Test");
            registrationForm.typeLastName("User");
            registrationForm.typeGmailAddress("testuser198022");
            registrationForm.typePasswd("Pwd12345");
            registrationForm.typePasswAgain("Pwd12345");
            registrationForm.typeBirthYear("1980");
            registrationForm.typeBirthMonth("01");
            registrationForm.typeBirthDay("01");
            registrationForm.typeHiddenGender("MALE");
            registrationForm.typeRecoveryEmailAddress("nick1@freemail.com");
            registrationForm.clickSkipCaptcha();
            registrationForm.clickTermsOfService();
            registrationForm.clickSubmitButton();


            Assert.True(String.Equals(driver.Title, "Google-fiók"));
        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}