using Microsoft.Playwright;

namespace PlaywrightTestExamples.Pages
{
    public sealed class ProgressBarPage : BasePage
    {
        public ProgressBarPage(IPage page) : base(page) { }

        public ILocator Start => Page.Locator(Locators.btnStart);
        public ILocator Stop => Page.Locator(Locators.btnStop);
        private ILocator Bar => Page.Locator(Locators.ProgressBar);

        public async Task<int> GetValueOfProgressBar()
        {
            string? value = await Bar.GetAttributeAsync(Locators.ProgressBarValue);
            return int.Parse(value);
        }
    }
}
