using HomeworkBrainsterTest;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeworkBrainster
{
    [TestFixture]
    public class HomeworkBrainsterTest
    {
        
        #pragma warning disable CS8618

        public IWebDriver driver;


        Homepage homepage;

        ClocksTab clocksTab;

        RegistrationTab registrationTab;

        CompareTab compareTab;

        string randomize = DateTime.Now.ToString().Replace('/', '1').Replace(':', '2').Replace(' ', '3');

        string BestClockParallelsProduct = "Best clock parallels";

        string DolorAdHacTorquentProduct = "Dolor ad hac torquent";

        string password = "StronGestPassword123!!";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            homepage = new Homepage(driver);

            clocksTab = new ClocksTab(driver);

            registrationTab = new RegistrationTab(driver);

            compareTab = new CompareTab(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://woodmart.xtemos.com/home/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test, Order(1)]
        public void ConfirmActualEmailSameAsRegisterEmail()
        {
            string emailUsedForRegisterProcess = $"user{randomize}@yahoo.com";
            homepage.GoToMyAccountPage();
            registrationTab.Register($"usrnm{randomize}", emailUsedForRegisterProcess, password);
            registrationTab.AccessAccountDetailsPage();
            string actualEmail = registrationTab.GetActualEmail();
            ClassicAssert.AreEqual(emailUsedForRegisterProcess, actualEmail);
            compareTab.LogOutProcess();
        }

        [Test, Order(2)]
        public void ConfirmAddedProductsToCompareTab()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            Assert.Multiple(() =>
            {
                ClassicAssert.IsTrue(compareTab.ConfirmProductsInCompareTab(BestClockParallelsProduct));
                ClassicAssert.IsTrue(compareTab.ConfirmProductsInCompareTab(DolorAdHacTorquentProduct));
            });
            compareTab.LogOutProcess();
        }

        [Test, Order(3)]
        public void ConfirmDiscountedPrice()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            ClassicAssert.IsTrue(compareTab.ConfirmDiscountOfBestClockParallelsItem());
            compareTab.LogOutProcess();
        }

        [Test, Order(4)]
        public void Confirm5StarRating()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            ClassicAssert.IsTrue(compareTab.Confirm5StarRatingOfBestClockParallelsItem());
            compareTab.LogOutProcess();
        }

        [Test, Order(5)]
        public void ConfirmInStockStatusForProducts()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            ClassicAssert.IsTrue(compareTab.ConfirmInStockStatus());
            compareTab.LogOutProcess();
        }


        [Test, Order(6)]
        public void ConfirmDifferentBrands()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            ClassicAssert.IsTrue(compareTab.ConfirmDifferentBrands());
            compareTab.LogOutProcess();
        }


        [Test, Order(7)]
        public void ConfirmNoColorOptionForItemDolorAdHacTorquent()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            ClassicAssert.IsTrue(compareTab.ColorsAvailableForDolorAdhacTorquentProduct());
            compareTab.LogOutProcess();
        }


        [Test, Order(8)]
        public void ConfirmEmptyCompareTabForProducts()
        {
            homepage.LoginProcess();
            homepage.GoToClocksPage();
            clocksTab.AddProductToCompareTab(BestClockParallelsProduct);
            clocksTab.AddProductToCompareTab(DolorAdHacTorquentProduct);
            compareTab.NavigateToCompareTab();
            compareTab.RemoveItemsFromCompareTab(DolorAdHacTorquentProduct);
            compareTab.RemoveItemsFromCompareTab(BestClockParallelsProduct);
            ClassicAssert.IsTrue(compareTab.ConfirmEmptyCompareTab());
            compareTab.LogOutProcess();
        }

        [TearDown] 
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}