using OpenQA.Selenium;

namespace CSE2522_Assignment.Pages
{
    public class SampleAppPage
    {
        private readonly IWebDriver driver;
        public SampleAppPage(IWebDriver driver) => this.driver = driver;

        private IWebElement UserNameField => driver.FindElement(By.Name("UserName"));
        private IWebElement PasswordField => driver.FindElement(By.Name("Password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login"));
        private IWebElement StatusLabel => driver.FindElement(By.Id("loginstatus"));

        public bool AreElementsDisplayed() => UserNameField.Displayed && PasswordField.Displayed && LoginButton.Displayed;

        public void Login(string user, string pass)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(user);
            PasswordField.Clear();
            PasswordField.SendKeys(pass);
            LoginButton.Click();
        }

        public string GetStatusText() => StatusLabel.Text;
    }
}