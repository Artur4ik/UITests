using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.PageObjects
{
    class AviaTicketsMenuPageObject
    {
        private IWebDriver _driver;
        private readonly By _aviaTicketsForm = By.XPath("//section[@class='form-section ']");
        public AviaTicketsMenuPageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        public bool CheckAviaTickets()
        {
            try
            {
                _driver.FindElement(_aviaTicketsForm);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
    }
}
