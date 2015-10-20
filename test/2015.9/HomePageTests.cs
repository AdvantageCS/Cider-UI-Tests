using Xunit;

namespace Tests
{
    public class HomePageTests : BrowserTestBase
    {
        [Fact]
        public void HomePageContainsExpectedLinksAtFullScreen()
        {
            FullSizeTest(browser =>
            {
                // Go to the home page
                browser.Visit("/");

                // Close the modal popup from the interstitial list signup widget
                browser.FindCss("button.close").Click();

                // Check for the standard home page
                Assert.Equal("Cider", browser.Title);
                Assert.True(browser.HasContent("Customer Service"));

                // Test the menu links for each product category
                Assert.True(browser.HasContent("Cider Enthusiasts"));
                Assert.True(browser.HasContent("Finance"));
                Assert.True(browser.HasContent("Gardening"));
                Assert.True(browser.HasContent("Hypertension"));
                Assert.True(browser.HasContent("Sports"));
                Assert.True(browser.HasContent("My Account"));

                // Test that the sub-category links are not visible
                Assert.False(browser.HasContent("Financial News"), "Financial News link should be hidden on home page");
                Assert.False(browser.HasContent("Financial Planning"), "Financial Planning link should be hidden on home page");

                // Test hovering over a menu to see sub-category links
                browser.FindLink("Finance").Hover();
                Assert.True(browser.HasContent("Financial News"), "Financial News link should be visible on hover");
                Assert.True(browser.HasContent("Financial Planning"), "Financial Planning link should be visible on hover");
            });
        }
    }
}
