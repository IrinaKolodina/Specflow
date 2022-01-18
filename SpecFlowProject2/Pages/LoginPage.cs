using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject2.Drivers;
using SpecFlowProject2.Hooks;

namespace SpecFlowProject2.Pages
{
    public class LoginPage: BasePage
    {
        public Driver driver;

        public LoginPage(Driver driver): base(driver)
        {
            this.driver = driver;
        }

        public Element spinner = new Element(By.XPath("//div[@ng-show='isLoading']"));

        public Element login = new Element(By.XPath("//input[@name = 'User']"));

        public Element password = new Element(By.XPath("//input[@type = 'password']"));

        public Element signInButton = new Element(By.XPath("//div[contains(@ng-click , 'Login(LoginForm)')]"));

        public Element greeting = new Element(By.XPath("//a[contains(text() ,'Welcome Back,')]"));

        public Element logout = new Element(By.XPath("//span[contains(text() ,'Log Out')]"));

        public Element loginButton = new Element(By.Id("menu-item-185"));


        public void fillUsernameAndPassword()
        {
           
            login.WaitForElement(driver);
            login.TypeText(driver, "");
            password.TypeText(driver, "");
        }

        public void logIn() => signInButton.Click(driver);

        public void openLoginPage()
        {
            loginButton.WaitForElement(driver);
            loginButton.Click(driver);
        }

        public void verifyAuthentification()
        {
            spinner.WaitForInvisibility(driver);
            Assert.True(greeting.WaitForElement(driver));
            Assert.True(logout.AsIWebElement(driver).Displayed);
        }

        public void logOut()
        {
            logout.Click(driver);
        }

        public void verifyUserIsLoggedOut()
        {
            Assert.Multiple(() => {
                Assert.True(logout.WaitForInvisibility(driver));
                Assert.True(!greeting.AsIWebElement(driver).Displayed);
                Assert.True(loginButton.WaitForElement(driver));
            });
        }

    }
}
