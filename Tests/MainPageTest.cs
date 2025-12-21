using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class MainPageTest:BaseTest
    {

        [Test]
        [Description("This test go to web site and visit each chapter link.")]
        [TestCaseSource(typeof(MainPage), nameof(MainPage.Links))]
        public async Task MainPageLinksTest(string pageName)
        {
            await LoadMainPage();
            await ClickLinkByText(pageName);
            if (pageName == Pages.Strings.LoadDelay)
            
                await isPageLoaded(pageName+"s");
           
            else
                await isPageLoaded(pageName);
        }

        [Test]
        [Description("This test checks main page Title and other atttributes.")]
        public async Task MainPageAttributes()
        {
            await LoadMainPage();
            await Assertions.Expect(_page).ToHaveTitleAsync(MainPage.PageTitle);
        }
    }
}