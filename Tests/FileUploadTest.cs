using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class FileUploadTest:BaseTest
    {
        private const string _file = "..\\..\\..\\Resources\\file.txt";

        [Test]
        [Description("This test go to web site and test File Upload via Drag and Drop.")]
        public async Task UploadFileDragAndDropTest()
        {
            await LoadMainPage();

            await ClickLinkByText(Strings.FileUpload);
            await isPageLoaded(Strings.FileUpload);

            var frame = _page.FrameLocator(Locators.iFrame);

            var fileInput = frame.Locator(Locators.inputFile);

            await Assertions.Expect(fileInput).ToBeAttachedAsync();

            await fileInput.SetInputFilesAsync(_file);

            await Assertions.Expect(_page.FrameLocator(Locators.iFrame)
                .Locator("p", new() { HasText =  Strings.MessageOfUpload}))
                .ToBeVisibleAsync();

        }
    }
}