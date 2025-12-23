using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class ProgressBarTest:BaseTest
    {
        [Test]
        [Description("This test go to web site and test Progress Bar.")]
        public async Task ProgressTest()
        {
            var progressBarPage = new ProgressBarPage(Page);

            await LoadPage(Strings.ProgressBar);

            await progressBarPage.Start.ClickAsync();

            while (progressBarPage.GetValueOfProgressBar().Result < 75) Thread.Sleep(1);

            await progressBarPage.Start.ClickAsync();

            Assert.IsTrue(progressBarPage.GetValueOfProgressBar().Result == 75);
        }
    }
}