using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace SpecFlowProject2.Drivers
{
    public class Driver
    {
        public IWebDriver webDriver;

        public enum Browser 
        {
            Firefox,
            Chrome,
            Opera
        }
       
       public Driver(Browser type)
       {
           switch(type)
           {
                case Browser.Chrome:
                    {
                        var options = new ChromeOptions();
                        options.AddArgument("start-maximized");
                        options.AddArgument("forced-maximize-mode");
                        options.AddArgument("no-sandbox");
                        options.AddArgument("--mute-audio");
                        webDriver = new ChromeDriver(options); 

                        break;
                    }
                case Browser.Firefox: 
                    {
                        webDriver = new FirefoxDriver();
                        break;
                    }
                case Browser.Opera:
                    {
                        webDriver = new OperaDriver();
                        break;
                    }
                default:
                    {
                        break;
                    }
           }
            webDriver.Navigate().GoToUrl("");
       }


        public void tearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
