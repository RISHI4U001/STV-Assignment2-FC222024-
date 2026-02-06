using AutomationAssignment;
using CSE2522_Assignment.Pages;
using NUnit.Framework;
using System.Buffers.Text;

namespace CSE2522_Assignment.Tests
{
    [TestFixture]
    public class TextInputTests : TestBase
    {
        [Test]
        [TestCase(TestName = "TC001_1 - Text Input - Verification of the page and button change")]
        public void VerifyTextInputFunctionality()
        {
            driver.Navigate().GoToUrl(baseUrl + "/textinput");
            var page = new TextInputPage(driver);
            string randomText = "SJP_Student_Test";

            Assert.That(page.IsPageDisplayed(), "Page or elements not displayed.");
            page.EnterText(randomText);
            page.ClickButton();

            Assert.That(page.GetButtonText(), Is.EqualTo(randomText), "Button text did not change to input text.");
        }
    }
}