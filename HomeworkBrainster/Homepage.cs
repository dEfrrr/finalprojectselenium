using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HomeworkBrainsterTest
{
    public class Homepage
    {
        IWebDriver driver;

        By LoginRegisterButton = By.ClassName("wd-header-my-account");

        By CreateAccountButton = By.ClassName("create-account-button");

        By ProductClocks = By.CssSelector("[aria-label = 'Product category clocks']");

        By HomePageButton = By.XPath("//span[text() = 'Home']");

        By EmailAddressUsernameFieldLogin = By.Id("username");

        By PasswordFieldLogin = By.Id("password");

        By LoginButton = By.Name("login");

        public Homepage(IWebDriver Driver)
        {
            driver = Driver;
        }

        public void GoToMyAccountPage()
        {
            driver.FindElement(LoginRegisterButton).Click();
            driver.FindElement(CreateAccountButton).Click();
        }

        public void LoginProcess()
        {
            string password = "Pasvord123!";
            driver.FindElement(LoginRegisterButton).Click();
            driver.FindElement(EmailAddressUsernameFieldLogin).SendKeys("deonline89@gmail.com");
            driver.FindElement(PasswordFieldLogin).SendKeys(password);
            driver.FindElement(LoginButton).Click();
            driver.FindElement(LoginRegisterButton).Click();
            driver.FindElement(PasswordFieldLogin).SendKeys(password);
            driver.FindElement(LoginButton).Click();
        }

        public void GoToClocksPage()
        {
            driver.FindElement(ProductClocks).Click();
        }

        public void NavigateToHomePage()
        {
            driver.FindElement(HomePageButton).Click();
        }

    }
}
