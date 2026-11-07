using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class ProgressBarTest : BaseTest
    {
        [Test]
        [Description("This test go to web site and test Progress Bar.")]
        public async Task ProgressTest()
        {
            await LoadPage(Strings.ProgressBar);

            var progressBarPage = new ProgressBarPage(Page);

            await progressBarPage.StartButton.ClickAsync();

            var timeoutAt = DateTime.UtcNow.AddSeconds(35);
            var value = await progressBarPage.GetValueOfProgressBar();

            while (value < 75)
            {
                if (DateTime.UtcNow > timeoutAt)
                    Assert.Fail($"Progress bar did not reach 75. Last value: {value}.");

                await Task.Delay(50);
                value = await progressBarPage.GetValueOfProgressBar();
            }

            await progressBarPage.StopButton.ClickAsync();

            value = await progressBarPage.GetValueOfProgressBar();
            Assert.That(value, Is.InRange(75, 77));
        }
    }
}