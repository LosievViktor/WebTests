using Microsoft.Playwright;

namespace PlaywrightTestExamples.Pages
{
    public sealed class ProgressBarPage : BasePage
    {
        public ProgressBarPage(IPage page) : base(page) { }

        public ILocator StartButton => Page.Locator(Locators.btnStart);
        public ILocator StopButton => Page.Locator(Locators.btnStop);
        private ILocator Bar => Page.Locator(Locators.ProgressBar);

        public async Task<int> GetValueOfProgressBar()
        {
            string? value = await Bar.GetAttributeAsync(Locators.ProgressBarValue);

            if (!int.TryParse(value, out var progress))
                throw new InvalidOperationException($"Progress bar value '{value}' is not an integer.");

            return progress;
        }
    }
}