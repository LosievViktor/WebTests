using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class SampleAppTests:BaseTest
    {
        private string _login = TestContext.Parameters["Login"];
        private string _password = TestContext.Parameters["Password"];
        private string _wrongPassword = TestContext.Parameters["WrongPassword"];
        

        [Test]
        [Description("This test go to web site and test login page in Positive case.")]
        public async Task LoginFormPositiveTest()
        {
            var page = new SampleAppPage(Page);

            await LoadPage(Strings.SampleApp);

            await page.LogIn(_login, _password);

            await Assertions.Expect(page.Status).ToHaveTextAsync($"{Strings.WelcomeUserMessage} {_login}!");  
        }

        [Test]
        [Description("This test go to web site and test login page in Negative case.")]
        public async Task LoginFormNegativeTest()
        {
            var page = new SampleAppPage(Page);

            await LoadPage(Strings.SampleApp);

            await page.LogIn(_login, _wrongPassword);
                     
            await Assertions.Expect(page.Status).ToHaveTextAsync(Strings.WrongPasswordMessage);
        }
    }
}