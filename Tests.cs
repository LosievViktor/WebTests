namespace PlaywrightTestExamples
{
    public class Tests
    {
        [TestFixture]
        public sealed class HomePageTests:OneTime
        {
            [Test]
            public async Task TestHomePageTitle()
            {
                StringAssert.Contains("Playwright", await _page.TitleAsync());
            } 

            [Test]
            public async Task Test()
            {
    
            }

        }
    }
}