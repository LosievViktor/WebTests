using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;
using System.Text.RegularExpressions;

namespace PlaywrightTestExamples
{
    [TestFixture]
    public sealed class HomePageTests
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
                Headless = bool.Parse(TestContext.Parameters["Headless"] ?? "false")
            });

            _page = await _browser.NewPageAsync();

            await _page.GotoAsync(TestContext.Parameters["Environment"] ?? "http://uitestingplayground.com/");
        }


        [Test]
        [Category("UI Playwright automation test.")]
        [Description("This automation test will check page title of web page.")]
        public async Task TestHomePageTitle()
        {
            StringAssert.Contains(Strings.Title, await _page.TitleAsync());
        }


        [Test]
        [Category("UI Playwright automation test.")]
        public async Task ClassAttributeTest()
        {
            await ClickLinkByText(Strings.ClassAttribute);
           
        }


        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        public async Task ClickLinkByText(string linkText) => await _page.GetByRole(AriaRole.Link, new() { Name = linkText }).ClickAsync();     
        public async Task isPageLoaded(string linkText) => await Assertions.Expect(_page).ToHaveURLAsync(new Regex("/" + linkText.Replace(" ", "").ToLower()));
      
    }
}