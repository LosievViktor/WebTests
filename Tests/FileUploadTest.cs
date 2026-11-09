using Microsoft.Playwright;
using PlaywrightTestExamples.Pages;

namespace PlaywrightTestExamples.Tests
{
    [TestFixture]
    public sealed class FileUploadTest:BaseTest
    {
        private const string _filePath = "..\\..\\..\\Resources\\file.txt";     

        [Test]
        [Description("This test go to web site and test File Upload via Drag and Drop.")]
        public async Task UploadFileDragAndDropTest()
        {
            await LoadPage(Strings.FileUpload);

            var uploadPage = new FileUploadPage(Page);

            await Assertions.Expect(uploadPage.FileInput, "File input inside the upload frame should be ready.")
                .ToBeAttachedAsync();

            await uploadPage.Upload(_filePath);

            await Assertions.Expect(
                    uploadPage.SelectedFilesLabel,
                    $"Upload should confirm selection with \"{Strings.MessageOfUpload}\".")
                .ToBeVisibleAsync();
        }
    }
}