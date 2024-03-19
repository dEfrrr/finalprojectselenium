using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkBrainsterTest
{
    public class CompareTab
    {
        IWebDriver driver;

        By ComparePageButton = By.ClassName("wd-header-compare");

        By MyAccountLocator = By.CssSelector("[title='My account']");

        By LogOutButtonLocator = By.XPath("//span[text() = 'Logout']");

        By Price = By.ClassName("price");

        By ColorsAvailable = By.CssSelector("td[data-title='Color']");

        By EmptyListMessage = By.ClassName("wd-empty-compare");

        By NumberOfCompareItems = By.CssSelector("span.wd-tools-count");

        By RemoveButton = By.ClassName("wd-compare-remove");

        By StockStatus = By.ClassName("stock");

        By AllProductsInCompareTab = By.ClassName("compare-value");

        public CompareTab(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToCompareTab()
        {
            driver.FindElement(ComparePageButton).Click();
        }

        public void RemoveItemsFromCompareTab(string productName)
        {
            IWebElement productElement = driver.FindElements(AllProductsInCompareTab).First(el => el.Text.Contains(productName));
            productElement.FindElement(RemoveButton).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.StalenessOf(productElement));
        }

        public void LogOutProcess()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(MyAccountLocator)).Perform();
            driver.FindElement(LogOutButtonLocator).Click();
        }

        public bool ConfirmProductsInCompareTab(string productName)
        {
            return driver.FindElements(AllProductsInCompareTab).Any(el => el.Text.Contains(productName));
        }

        public bool ConfirmDiscountOfBestClockParallelsItem()
        {
            List<IWebElement> price = driver.FindElements(Price).ToList();
            return price[0].Text.Equals("$555.00 – $780.00");
        }

        public bool Confirm5StarRatingOfBestClockParallelsItem()
        {
            string rating = driver.FindElement(By.CssSelector(".star-rating")).GetAttribute("aria-label");
            return rating.Equals("Rated 5.00 out of 5");
        }

        public bool ConfirmDifferentBrands()
        {
            string brandLocatorForBestClockParallels = "Joseph Joseph";
            string brandLocatorForDolorAdHacTorquent = "Louis Poulsen";
            string brand = driver.FindElement(By.CssSelector($"[title = '{brandLocatorForBestClockParallels}']")).GetAttribute("title");
            string brand1 = driver.FindElement(By.CssSelector($"[title = '{brandLocatorForDolorAdHacTorquent}']")).GetAttribute("title");
            return brand != brand1;
            
        }

        public bool ColorsAvailableForDolorAdhacTorquentProduct()
        {
            List<IWebElement> colorsAvailable = driver.FindElements(ColorsAvailable).ToList();
            return colorsAvailable[1].Text.Equals("-");
        }
        public bool ConfirmEmptyCompareTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span.wd-tools-count"), "0"));
            bool IsEmptyListMessage = driver.FindElement(EmptyListMessage).Text.Equals("Compare list is empty.");
            bool NumberOfCompareItemsCount = driver.FindElement(NumberOfCompareItems).Text.Equals("0");
            return IsEmptyListMessage && NumberOfCompareItemsCount;
        }

        public bool ConfirmInStockStatus()
        {
            List<IWebElement> productsInStockStatus = driver.FindElements(StockStatus).ToList();
            foreach (var product in productsInStockStatus)
            {
                string stockStatusText = product.Text;
                if (stockStatusText == "In stock")
                {
                    return true;
                }
            }
            return false;
        }
    }
}