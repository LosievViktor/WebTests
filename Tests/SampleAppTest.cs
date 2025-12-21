using Microsoft.Playwright;
using PlaywrightTestExamples.Strings;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class SampleAppTest:BaseTest
    {
        private string _login, _password, _wrongPassword;

        [SetUp]
        public void Setup()
        {
            _login = TestContext.Parameters["Login"];
            _password = TestContext.Parameters["Password"];
            _wrongPassword = TestContext.Parameters["WrongPassword"];
        }

        [Test]
        [Description("This test go to web site and test login page in Positive case.")]
        public async Task LoginFormPositiveTest()
        {
            await LoadSampleAppPage();

            await LogIn(_login, _password);

            await Assertions.Expect(_page.Locator(Locators.lblStatus))
                .ToHaveTextAsync($"{Pages.Strings.WelcomeUserMessage} {_login}!");  
        }

        [Test]
        [Description("This test go to web site and test login page in Negative case.")]
        public async Task LoginFormNegativeTest()
        {
            await LoadSampleAppPage();

            await LogIn(_login, _wrongPassword);
                     
            await Assertions.Expect(_page.Locator(Locators.lblStatus))
                .ToHaveTextAsync(Pages.Strings.WrongPasswordMessage);
        }

        private async Task LoadSampleAppPage() {
            await LoadMainPage();
            await ClickLinkByText(Pages.Strings.SampleApp);
            await isPageLoaded(Pages.Strings.SampleApp);
        }

        private async Task LogIn(string user, string pass) 
        {
            await _page.Locator(Locators.txtLogin).FillAsync(user);
            await _page.Locator(Locators.txtPassword).FillAsync(pass);
            await _page.ClickAsync(Locators.btnLogin);
        }
    }
}
