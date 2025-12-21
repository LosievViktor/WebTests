using PlaywrightTestExamples.Pages;
using NUnit.Framework;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class HomePageTests:BaseTest
    {
        string webUrl = TestContext.Parameters["Environment"];

        [Test]
        [Description("This test go to web site and visit each chapter link.")]
        [TestCaseSource(typeof(MainPage), nameof(MainPage.Links))]
        public async Task MainPageLinksTest(string pageName)
        {
            await LoadPage(webUrl);
            await ClickLinkByText(pageName);
            await isPageLoaded(pageName);
        }
    }
}