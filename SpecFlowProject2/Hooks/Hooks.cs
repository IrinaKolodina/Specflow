
using BoDi;
using OpenQA.Selenium;
using SpecFlowProject2.Drivers;
using SpecFlowProject2.Pages;
using TechTalk.SpecFlow;
using static SpecFlowProject2.Drivers.Driver;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public class Hooks
    {
         Driver driver;
        private readonly IObjectContainer objectContainer;

        public static Browser browserType = Browser.Chrome;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

     

        [BeforeScenario]
        public  void setUp()
        {
            driver = new Driver(browserType);
            objectContainer.RegisterInstanceAs(driver);
        }


        [AfterScenario]
        public void tearDown()
        {
            driver.tearDown();
        }
    }
}
