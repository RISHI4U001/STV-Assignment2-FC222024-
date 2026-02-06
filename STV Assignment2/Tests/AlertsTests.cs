using AutomationAssignment;
using CSE2522_Assignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium; // Add this if not already present

namespace CSE2522_Automation.Tests
{
    public class AlertsTests : TestBase
    {
        protected IWebDriver Driver => driver; // Add this property if 'driver' is defined in TestBase

        [Test]
        public void TC004_Verify_Alert_Text()
        {
            var page = new AlertsPage(Driver);
            page.Open();

            string text = page.HandleAlert(true); // Pass required 'accept' argument
            Assert.That(text, Does.Contain("working day"));
        }

        [Test]
        public void TC004_Verify_Confirm_Accept()
        {
            var page = new AlertsPage(Driver);
            page.Open();

            string result = page.HandleConfirm(true);
            Assert.That(result, Does.Contain("Yes"));
        }

        [Test]
        public void TC004_Verify_Prompt()
        {
            var page = new AlertsPage(Driver);
            page.Open();

            string result = page.HandlePrompt("Hello", true);
            Assert.That(result, Does.Contain("Hello"));
        }
    }
}