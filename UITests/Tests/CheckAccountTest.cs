using NUnit.Framework;
using OpenQA.Selenium;
using Tests.PageObjects;

namespace CheckAccountTest
{
    public class Tests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.booking.com");
        }

        [Test]
        public void Test1()
        {
            var mainMenu = new MainMenuPageObject(_driver);
            Assert.IsTrue(!mainMenu.CheckAccountAuthorization());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}