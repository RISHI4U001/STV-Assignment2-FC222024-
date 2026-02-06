using AutomationAssignment;
using CSE2522_Assignment.Pages;
using NUnit.Framework;
using System.Buffers.Text;

namespace CSE2522_Assignment.Tests
{
    [TestFixture]
    public class SampleAppTests : TestBase
    {
        [Test]
        [TestCase(TestName = "TC002_1 - Sample App - Verification of elements")]
        public void VerifySampleAppPage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/sampleapp");
            var page = new SampleAppPage(driver);
            Assert.That(page.AreElementsDisplayed(), Is.True);
        }

        [Test]
        [TestCase("User123", "pwd", TestName = "TC002_2 - Sample App - Verification of successful login")]
        public void VerifySuccessfulLogin(string user, string pass)
        {
            driver.Navigate().GoToUrl(baseUrl + "/sampleapp");
            var page = new SampleAppPage(driver);
            page.Login(user, pass);
            Assert.That(page.GetStatusText(), Is.EqualTo($"Welcome, {user}!"));
        }

        [Test]
        [TestCase("User123", "wrong_pass", TestName = "TC002_3 - Sample App - Verification of unsuccessful login")]
        public void VerifyUnsuccessfulLogin(string user, string pass)
        {
            driver.Navigate().GoToUrl(baseUrl + "/sampleapp");
            var page = new SampleAppPage(driver);
            page.Login(user, pass);
            Assert.That(page.GetStatusText(), Is.EqualTo("Invalid username/password"));
        }
    }
}