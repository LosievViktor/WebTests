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
            await LoadPage(Strings.ProgressBar);

            await StartButton.ClickAsync();

            while (GetValueOfProgressBar().Result < 75) Thread.Sleep(1);

            await StopButton.ClickAsync();

            Assert.IsTrue(GetValueOfProgressBar().Result == 75);
        }
        
        private ILocator StartButton => _page.Locator(Locators.btnStart);
        private ILocator StopButton =>  _page.Locator(Locators.btnStop);
        private ILocator ProgressBar => _page.Locator(Locators.ProgressBar);

        private async Task<int> GetValueOfProgressBar()
        {
            string? value = await ProgressBar.GetAttributeAsync(Locators.ProgressBarValue);
            return int.Parse(value);
        }
    }
}
