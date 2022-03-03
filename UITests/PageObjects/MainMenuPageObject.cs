using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _driver;
        private readonly By _languageButton = By.XPath("//button[@data-modal-id='language-selection']");
        private readonly By _aviaTicketsButton = By.XPath("//a[@data-decider-header='flights']");
        private readonly By _accountButton = By.XPath("//span[contains(text(),'Управлять аккаунтом')]");
        private readonly By _englishLang = By.XPath("//div[@lang='en-us']");
        private readonly By _cityInput = By.XPath("//input[@placeholder='Куда вы хотите поехать?']");
        private readonly By _datesInput = By.XPath("//div[@class='xp__dates xp__group']");
        private readonly By _guestInput = By.XPath("//div[@class='xp__input-group xp__guests']");
        private readonly By _addChieldButton = By.XPath("//button[@aria-label='Детей: увеличить количество']");
        private readonly By _inDate = By.XPath("//span[@aria-label='" + DateTime.Now.AddDays(7).ToString("d ") + DateTime.Now.AddDays(7).ToString("MMMM ") + DateTime.Now.AddDays(7).ToString("yyyy") + "']");
        private readonly By _outDate = By.XPath("//span[@aria-label='" + DateTime.Now.AddDays(9).ToString("d ") + DateTime.Now.AddDays(9).ToString("MMMM ") + DateTime.Now.AddDays(9).ToString("yyyy") + "']");

        public MainMenuPageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ChangeLanguage()
        {
            _driver.FindElement(_languageButton).Click();
            _driver.FindElement(_englishLang).Click();
        }
        public AviaTicketsMenuPageObject OpenAviaTicketsMenu()
        {
            _driver.FindElement(_aviaTicketsButton).Click();
            return new AviaTicketsMenuPageObject(_driver);
        }
        public bool CheckAccountAuthorization()
        {
            try
            {
                _driver.FindElement(_accountButton);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool CheckFilters()
        {
            try
            {
                var cityInput = _driver.FindElement(_cityInput);
                cityInput.SendKeys("Минск");
                var datesInput = _driver.FindElement(_datesInput);
                datesInput.Click();
                var inDateInput = _driver.FindElement(_inDate);
                inDateInput.Click();
                var outDateInput = _driver.FindElement(_outDate);
                outDateInput.Click();
                var guestInput = _driver.FindElement(_guestInput);
                guestInput.Click();
                var addChieldButton = _driver.FindElement(_addChieldButton);
                addChieldButton.Click();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}
