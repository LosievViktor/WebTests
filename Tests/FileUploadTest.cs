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
            await LoadPage(Strings.FileUpload);
           
            await Assertions.Expect(fileInput).ToBeAttachedAsync();

            await fileInput.SetInputFilesAsync(_file);

            await Assertions.Expect(iFrame.Locator("p", new() { HasText =  Strings.MessageOfUpload})).ToBeVisibleAsync();

        }

        private IFrameLocator iFrame => _page.FrameLocator(Locators.iFrame);
        private ILocator fileInput => iFrame.Locator(Locators.inputFile);
    }
}