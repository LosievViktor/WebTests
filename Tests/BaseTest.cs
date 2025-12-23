using Microsoft.Playwright;

namespace PlaywrightTestExamples.Tests
{
    public class BaseTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        public  IPage _page;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = bool.Parse(TestContext.Parameters["Headless"])
            });

            _page = await _browser.NewPageAsync();
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        public async Task LoadMainPage() =>
            await _page.GotoAsync(TestContext.Parameters["Environment"]);

        private async Task ClickLinkByText(string linkText) => 
            await _page.GetByRole(AriaRole.Link, new() { Name = linkText }).ClickAsync();

        private async  Task isPageLoaded(string headerText) =>
            await Assertions.Expect(_page.Locator("h3")).ToHaveTextAsync(headerText);

        public async Task LoadPage(string chapter)
        {
            await LoadMainPage();
            await ClickLinkByText(chapter);
            await isPageLoaded(chapter);
        }
    }
}