using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject2.Drivers;
using System;

namespace SpecFlowProject2.Hooks
{
    public class Element
    {
        public By locator;
        public TimeSpan timeout = TimeSpan.FromSeconds(10);

        public Element(By locator)
        {
            this.locator = locator;
        }

        public bool TypeText(Driver driver, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver.webDriver, timeout);
            try
            {
                wait.Until(d => driver.webDriver.FindElement(locator));
                driver.webDriver.FindElement(locator).Click();
                driver.webDriver.FindElement(locator).Clear();
                driver.webDriver.FindElement(locator).SendKeys(text + Keys.Enter);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void JsClick(Driver driver)
        {
            var js = (IJavaScriptExecutor)driver.webDriver;
            js.ExecuteScript("arguments[0].click();", driver.webDriver.FindElement(locator));
        }

        public IWebElement AsIWebElement(Driver driver)
        {
            return driver.webDriver.FindElement(locator);
        }

        public void ScrollToElement(Driver driver)
        {
            Actions actions = new Actions(driver.webDriver);
            actions.MoveToElement(driver.webDriver.FindElement(locator));
            actions.Perform();
        }

        public bool WaitForElement(Driver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver.webDriver, timeout);
            try
            {
                wait.Until(d => driver.webDriver.FindElement(locator));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool WaitForInvisibility(Driver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver.webDriver, timeout);
            try
            {
                wait.Until(d => !driver.webDriver.FindElement(locator).Displayed);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Click(Driver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver.webDriver, timeout);
            try
            {
                wait.Until(d => driver.webDriver.FindElement(locator));
                driver.webDriver.FindElement(locator).Click();
            }
            catch (Exception e)
            { }
        }

    }
}
