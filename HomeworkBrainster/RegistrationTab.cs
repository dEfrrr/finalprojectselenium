using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;

namespace HomeworkBrainsterTest
{
    public class RegistrationTab
    {
        IWebDriver driver;

        By UsernameField = By.Id("reg_username");

        By EmailField = By.Id("reg_email");

        By PasswordField = By.Id("reg_password");

        By RegisterButton = By.Name("register");

        By AccountDetails = By.LinkText("Account details");

        By EmailFieldInAccountDetailsPage = By.Id("account_email");

        By ClickToEnableRegistration = By.ClassName("woocommerce-privacy-policy-text");

        public RegistrationTab(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void Register(string username, string email,string password)
        {
            driver.FindElement(UsernameField).SendKeys(username);
            driver.FindElement(EmailField).SendKeys(email);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(ClickToEnableRegistration).Click();
            driver.FindElement(RegisterButton).Click();
        }

        public string GetActualEmail()
        {
            IWebElement accountEmailField = driver.FindElement(EmailFieldInAccountDetailsPage);
            string actualEmail = accountEmailField.GetAttribute("value");
            return actualEmail;
        }

        public void AccessAccountDetailsPage()
        {
            driver.FindElement(AccountDetails).Click();
        }
    }
}
