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

            await uploadPage.Upload(_filePath);

            await uploadPage.AssertUploaded();
        }
    }
}