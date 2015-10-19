using Coypu.NUnit.Matchers;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HomePageTests : BrowserTestBase
    {
        [Test]
        public void HomePageContainsExpectedLinksAtFullScreen()
        {
            FullSizeTest(browser =>
            {
                // Go to the home page
                browser.Visit("/");

                // Close the modal popup from the interstitial list signup widget
                browser.FindCss("button.close").Click();

                // Check for the standard home page
                Assert.That(browser.Title, Is.EqualTo("Cider"));
                Assert.That(browser, Shows.Content("Customer Service"));

                // Check that the home page includes links for each product category
                Assert.That(browser, Shows.Content("Cider Enthusiasts"));
                Assert.That(browser, Shows.Content("Finance"));
                Assert.That(browser, Shows.Content("Gardening"));
                Assert.That(browser, Shows.Content("Hypertension"));
                Assert.That(browser, Shows.Content("Sports"));
                Assert.That(browser, Shows.Content("My Account"));

                // Test the menu on the home page
                Assert.That(browser, Shows.No.Content("Financial News"), "Financial News link should be hidden on home page");
                Assert.That(browser, Shows.No.Content("Financial Planning"), "Financial Planning link should be hidden on home page");

                // Test hovering over a menu with children
                browser.FindLink("Finance").Hover();
                Assert.That(browser, Shows.Content("Financial News"), "Financial News link should be visible on hover");
                Assert.That(browser, Shows.Content("Financial Planning"), "Financial Planning link should be visible on hover");
            });
        }
    }
}
