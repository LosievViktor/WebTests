using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class MainPageTests:BaseTest
    {

        [Test]
        [Description("This test go to web site and visit each chapter link.")]
        [TestCaseSource(typeof(Strings), nameof(Strings.Links))]
        public async Task MainPageLinksTest(string pageName) => await LoadPage(pageName);
        

        [Test]
        [Description("This test checks main page Title.")]
        public async Task MainPageAttributes()
        {
            await LoadMainPage();
            await Assertions.Expect(Page).ToHaveTitleAsync(Strings.PageTitle);
        }
    }
}