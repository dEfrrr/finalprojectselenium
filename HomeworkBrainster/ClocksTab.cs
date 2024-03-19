using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkBrainsterTest
{
    public class ClocksTab
    {
        IWebDriver driver;

        By AllProductsClocksPage = By.ClassName("product-wrapper");

        By CompareButton = By.CssSelector("[data-added-text='Compare products']");

        public ClocksTab(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddProductToCompareTab(string productName)
        {
            IWebElement productElement = driver.FindElements(AllProductsClocksPage).First(el => el.Text.Contains(productName));

            new Actions(driver)
                .ScrollByAmount(0, 250)
                .Perform();
            new Actions(driver)
                .MoveToElement(productElement)
                .Perform();

            productElement.FindElement(CompareButton).Click();
        }
    }
}
