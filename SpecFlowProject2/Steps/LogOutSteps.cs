using SpecFlowProject2.Drivers;
using SpecFlowProject2.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public sealed class LogOutSteps
    {
        Driver driver;
        private readonly LoginPage loginPage;
        private readonly SchedulingPage schedulingPage;

        public LogOutSteps(Driver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            schedulingPage = new SchedulingPage(driver);
        }

        [When(@"I press logout button")]
        public void WhenIPressLogoutButton()
        {
            loginPage.logOut();
        }


        [Then(@"user should be logged out")]
        public void ThenUserShouldBeLoggedOut()
        {
            loginPage.verifyUserIsLoggedOut();
        }


    }
}
