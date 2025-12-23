using Microsoft.Playwright;

namespace PlaywrightTestExamples.Pages
{
    public sealed class SampleAppPage : BasePage
    {
        public SampleAppPage(IPage page) : base(page) { }

        private ILocator Login => Page.Locator(Locators.txtLogin);
        private ILocator Password => Page.Locator(Locators.txtPassword);
        private ILocator Button => Page.Locator(Locators.btnLogin);
        public  ILocator Status => Page.Locator(Locators.lblStatus);

        public async Task LogIn(string user, string pass)
        {
            await Login.FillAsync(user);
            await Password.FillAsync(pass);
            await Button.ClickAsync();
        }
    }
}
