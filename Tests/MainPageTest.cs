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
            await isPageLoaded(pageName);
        }
    }
}