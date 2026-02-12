using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    public abstract class BaseTest:PageTest
    {
        public async Task LoadMainPage() =>
            await Page.GotoAsync(TestContext.Parameters["Environment"]);

        private async Task ClickLinkByText(string linkText) => 
            await Page.GetByRole(AriaRole.Link, new() { Name = linkText }).ClickAsync();

        private async  Task isPageLoaded(string headerText) =>
            await Assertions.Expect(Page.Locator(Locators.headerTag)).ToHaveTextAsync(headerText);

        public async Task LoadPage(string chapter)
        {
            await LoadMainPage();
            await ClickLinkByText(chapter);
            await isPageLoaded(chapter);
        }
    }
}