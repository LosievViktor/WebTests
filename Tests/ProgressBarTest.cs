using PlaywrightTestExamples.Strings;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class ProgressBarTest:BaseTest
    {
        [Test]
        [Description("This test go to web site and test Progress Bar.")]
        public async Task ProgressTest()
        {
            await LoadMainPage();
            await ClickLinkByText(Pages.Strings.ProgressBar);
            await isPageLoaded(Pages.Strings.ProgressBar);

            await _page.Locator(Locators.btnStart).ClickAsync();
            while (GetValueOfProgressBarAsync().Result < 75) Thread.Sleep(1);
            await _page.Locator(Locators.btnStop).ClickAsync();

            Assert.IsTrue(GetValueOfProgressBarAsync().Result == 75);
        }

        private async Task<int> GetValueOfProgressBarAsync() 
        {
            var progressBar = _page.Locator(Locators.ProgressBar);
            string value = await progressBar.GetAttributeAsync(Locators.ProgressBarValue);
            return int.Parse(value);
        }
    }
}
