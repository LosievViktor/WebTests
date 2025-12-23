using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class SampleAppTest:BaseTest
    {
        private string _login = TestContext.Parameters["Login"];
        private string _password = TestContext.Parameters["Password"];
        private string _wrongPassword = TestContext.Parameters["WrongPassword"];
        

        [Test]
        [Description("This test go to web site and test login page in Positive case.")]
        public async Task LoginFormPositiveTest()
        {
            await LoadPage(Strings.SampleApp);

            await LogIn(_login, _password);

            await Assertions.Expect(StatusLabel).ToHaveTextAsync($"{Strings.WelcomeUserMessage} {_login}!");  
        }

        [Test]
        [Description("This test go to web site and test login page in Negative case.")]
        public async Task LoginFormNegativeTest()
        {
            await LoadPage(Strings.SampleApp);

            await LogIn(_login, _wrongPassword);
                     
            await Assertions.Expect(StatusLabel).ToHaveTextAsync(Strings.WrongPasswordMessage);
        }
       
        private async Task LogIn(string user, string pass) 
        {
            await LoginTextField.FillAsync(user);
            await PasswordTextField.FillAsync(pass);
            await LoginButton.ClickAsync();
        }

        private ILocator LoginTextField => _page.Locator(Locators.txtLogin);
        private ILocator PasswordTextField => _page.Locator(Locators.txtPassword);
        private ILocator LoginButton => _page.Locator(Locators.btnLogin);
        private ILocator StatusLabel=> _page.Locator(Locators.lblStatus);

    }
}