using System;
using Coypu;
using Coypu.Drivers;
using Tests.Properties;

namespace Tests
{
    public abstract class BrowserTestBase
    {
        private SessionConfiguration SessionConfiguration => new SessionConfiguration
        {
            AppHost = Settings.Default.CiderHost,
            Port = 443,
            SSL = true,
            Browser = Browser.Chrome
        };

        protected void FullSizeTest(Action<BrowserSession> a)
        {
            using (var browser = new BrowserSession(SessionConfiguration))
            {
                browser.ResizeTo(1200, 1000);
                a(browser);
            }
        }
    }
}
