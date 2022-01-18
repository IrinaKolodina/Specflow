using SpecFlowProject2.Pages;
using System;
using TechTalk.SpecFlow;
using SpecFlowProject2.Drivers;
//livingdoc test-assembly D:\Обучение\SpecFlowProject2\SpecFlowProject2\bin\Debug\netcoreapp3.1\SpecFlowProject2.dll -t D:\Обучение\SpecFlowProject2\SpecFlowProject2\bin\Debug\netcoreapp3.1\TestExecution.json

namespace SpecFlowProject2.Steps
{
    
    [Binding]
    public class LoginSteps
    {

        Driver driver;
        private readonly LoginPage loginPage;
        private readonly SchedulingPage schedulingPage;

        public LoginSteps(Driver driver)
        {
            this.driver = driver;
            //mainPage = new MainPage(driver);
            loginPage = new LoginPage(driver);
            schedulingPage = new SchedulingPage(driver);
        }

        [Given(@"I have navigated to website")]
        public void GivenIHaveNavigatedToWebsite()
        {      
            loginPage.openLoginPage();         
        }

        [Given(@"I have entered valid login and password")]
        public void GivenIHaveEnteredValidLoginAndPassword()
        {        
            loginPage.fillUsernameAndPassword();
        }

        [When(@"I press logIn button")]
        public void WhenIPressLogInButton()
        {
            loginPage.logIn();
        }
        
        [Then(@"I should navigate to the main page of the site")]
        public void ThenIShouldNavigateToTheMainPageOfTheSite()
        {
            loginPage.verifyAuthentification();
        }

        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            loginPage.openLoginPage();
            loginPage.fillUsernameAndPassword();
            loginPage.logIn();
            loginPage.verifyAuthentification();
        }

    }
}
