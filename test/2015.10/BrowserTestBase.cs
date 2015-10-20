using System;
using Coypu;
using Coypu.Drivers;
using Microsoft.Framework.Configuration;

namespace Tests
{
    public abstract class BrowserTestBase
    {
        private IConfiguration Settings => new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();
        
        private SessionConfiguration SessionConfiguration => new SessionConfiguration
        {
            AppHost = Settings["site"],
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
