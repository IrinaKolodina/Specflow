using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject2.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowProject2.Pages
{
    public class BasePage
    {

        public TimeSpan timeout = TimeSpan.FromSeconds(10);
        Driver driver;

        public BasePage(Driver driver)
        {
            this.driver = driver;
        }

       

        public bool WaitForInvisibility(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver.webDriver, timeout);
            try
            {
                wait.Until(d => !element.Displayed);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

   
       
    }
}
