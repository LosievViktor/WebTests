namespace PlaywrightTestExamples
{
        [TestFixture]
        public sealed class HomePageTests:OneTime
        {
            [Test]
            [Description("This automation test will check page title of web page.")]
            public async Task TestHomePageTitle()
            {
                StringAssert.Contains("Playwright", await _page.TitleAsync());
            } 
        }
}