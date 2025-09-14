using Microsoft.Playwright;

namespace PlaywrightTestExamples
{
    [TestFixture]
    public class OneTime
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        public IPage _page;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            _page = await _browser.NewPageAsync();

            await _page.GotoAsync(Environments.GetProductionName());
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}