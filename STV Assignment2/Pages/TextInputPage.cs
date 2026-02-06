using OpenQA.Selenium;

namespace CSE2522_Assignment.Pages
{
    public class TextInputPage
    {
        private readonly IWebDriver driver;
        public TextInputPage(IWebDriver driver) => this.driver = driver;

        private IWebElement InputBox => driver.FindElement(By.Id("newAttributeName"));
        private IWebElement ActionButton => driver.FindElement(By.Id("updatingButton"));

        public bool IsPageDisplayed() => driver.Url.Contains("/textinput") && InputBox.Displayed && ActionButton.Displayed;

        public void EnterText(string text) => InputBox.SendKeys(text);

        public void ClickButton() => ActionButton.Click();

        public string GetButtonText() => ActionButton.Text;
    }
}