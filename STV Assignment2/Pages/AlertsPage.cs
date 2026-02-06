using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment.Pages
{
    public class AlertsPage
    {
        private readonly IWebDriver driver;
        public AlertsPage(IWebDriver driver) => this.driver = driver;

        private IWebElement AlertBtn => driver.FindElement(By.Id("alert"));
        private IWebElement ConfirmBtn => driver.FindElement(By.Id("confirm"));
        private IWebElement PromptBtn => driver.FindElement(By.Id("prompt"));

        // Wait for presence/visibility of the three buttons to avoid NoSuchElementException
        public bool AreButtonsVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(d => 
                {
                    var alertEls = d.FindElements(By.Id("alert"));
                    var confirmEls = d.FindElements(By.Id("confirm"));
                    var promptEls = d.FindElements(By.Id("prompt"));

                    if (alertEls.Count == 0 || confirmEls.Count == 0 || promptEls.Count == 0)
                        return false;

                    return alertEls[0].Displayed && confirmEls[0].Displayed && promptEls[0].Displayed;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void ClickAlert() => AlertBtn.Click();
        public void ClickConfirm() => ConfirmBtn.Click();
        public void ClickPrompt() => PromptBtn.Click();

        public string HandleAlert(bool accept)
        {
            IAlert alert = driver.SwitchTo().Alert();
            string text = alert.Text;
            if (accept) alert.Accept(); else alert.Dismiss();
            return text;
        }

        public void EnterPromptValue(string text, bool accept)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
            if (accept) alert.Accept(); else alert.Dismiss();
        }
    }
}