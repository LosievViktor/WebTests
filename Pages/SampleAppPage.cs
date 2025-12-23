using Microsoft.Playwright;

namespace PlaywrightTestExamples.Pages
{
    public sealed class SampleAppPage : BasePage
    {
        public SampleAppPage(IPage page) : base(page) { }

        private ILocator LoginTextField => Page.Locator(Locators.txtLogin);
        private ILocator PasswordTextField => Page.Locator(Locators.txtPassword);
        private ILocator LoginButton => Page.Locator(Locators.btnLogin);
        public  ILocator StatusLabel => Page.Locator(Locators.lblStatus);

        public async Task Login(string user, string pass)
        {
            await LoginTextField.FillAsync(user);
            await PasswordTextField.FillAsync(pass);
            await LoginButton.ClickAsync();
        }
    }
}
