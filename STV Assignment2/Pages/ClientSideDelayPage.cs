using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment.Pages
{
    public class ClientSideDelayPage
    {
        private readonly IWebDriver driver;
        public ClientSideDelayPage(IWebDriver driver) => this.driver = driver;

        private IWebElement TriggerButton => driver.FindElement(By.Id("ajaxButton"));
        private IWebElement Spinner => driver.FindElement(By.Id("spinner"));
        private By SuccessBannerLocator = By.CssSelector(".bg-success");

        public bool IsButtonDisplayed() => TriggerButton.Displayed;

        public void ClickTriggerButton() => TriggerButton.Click();

        public bool IsLoadingIndicatorDisplayed() => Spinner.Displayed;

        public string GetSuccessBannerText()
        {
            // Explicit wait for the client-side delay (usually 15 seconds)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait.Until(d => d.FindElement(SuccessBannerLocator)).Text;
        }
    }
}