using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class ProgressBarTest:BaseTest
    {
        [Test]
        [Description("This test go to web site and test Progress Bar.")]
        public async Task ProgressTest()
        {
            await LoadPage(Strings.ProgressBar);

            var progressBarPage = new ProgressBarPage(Page);

            await progressBarPage.StartButton.ClickAsync();

            while (progressBarPage.GetValueOfProgressBar().Result < 75) Thread.Sleep(1);

            await progressBarPage.StopButton.ClickAsync();
            
            Assert.IsTrue(progressBarPage.GetValueOfProgressBar().Result == 75);
        }
    }
}