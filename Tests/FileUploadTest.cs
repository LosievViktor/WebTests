using Microsoft.Playwright;
using PlaywrightTestExamples.Strings;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class FileUploadTest:BaseTest
    {
        private const string _file = "..\\..\\..\\Resources\\file.txt";
        private const string _wrongFile = "..\\..\\..\\Resources\\file.bbb";

        [Test]
        [Description("This test go to web site and test File Upload via Drag and Drop.")]
        public async Task UploadFileDragAndDropTest()
        {
            await LoadMainPage();

            await ClickLinkByText(Pages.Strings.FileUpload);
            await isPageLoaded(Pages.Strings.FileUpload);

            var frame = _page.FrameLocator(Locators.iFrame);

            var fileInput = frame.Locator(Locators.inputFile);

            await Assertions.Expect(fileInput).ToBeAttachedAsync();

            await fileInput.SetInputFilesAsync(_file);

            await Assertions.Expect(_page.FrameLocator(Locators.iFrame)
                .Locator("p", new() { HasText = "1 file(s) selected" }))
                .ToBeVisibleAsync();

        }
    }
}