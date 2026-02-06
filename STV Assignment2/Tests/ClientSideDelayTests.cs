using AutomationAssignment;
using CSE2522_Assignment.Pages;
using NUnit.Framework;
using System.Buffers.Text;

namespace CSE2522_Assignment.Tests
{
    [TestFixture]
    public class ClientSideDelayTests : TestBase
    {
        [Test]
        [TestCase(TestName = "TC003_1 - Client Side Delay - Verification of delay and banner")]
        public void VerifyClientSideDelay()
        {
            driver.Navigate().GoToUrl(baseUrl + "/clientdelay");
            var page = new ClientSideDelayPage(driver);

            Assert.That(page.IsButtonDisplayed(), Is.True);
            page.ClickTriggerButton();

            Assert.That(page.IsLoadingIndicatorDisplayed(), Is.True, "Spinner did not appear.");

            string result = page.GetSuccessBannerText();
            Assert.That(result, Is.EqualTo("Data calculated on the client side."));
        }
    }
}