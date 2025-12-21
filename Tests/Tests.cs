using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;
using System.Text.RegularExpressions;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class HomePageTests:BaseTest
    {
        string webUrl = TestContext.Parameters["Environment"];

        [Test]
        [TestCaseSource(typeof(MainPage), nameof(MainPage.Links))]
        public async Task MainPageLinksTest(string pageName)
        {
            await LoadPage(webUrl);
            await ClickLinkByText(pageName);
            await isPageLoaded(pageName);
        }
    }
}