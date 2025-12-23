using Microsoft.Playwright;

namespace PlaywrightTestExamples.Pages
{
    public sealed class FileUploadPage : BasePage
    {
        public FileUploadPage(IPage page) : base(page) { }

        private IFrameLocator iFrame => Page.FrameLocator(Locators.iFrame);
        private ILocator fileInput => iFrame.Locator(Locators.inputFile);

        public async Task Upload(string file)
        {
            await Assertions.Expect(fileInput).ToBeAttachedAsync();
            await fileInput.SetInputFilesAsync(file);
        }

        public async Task AssertUploaded()
        {
            await Assertions.Expect(iFrame.Locator("p", new() { HasText = Strings.MessageOfUpload })).ToBeVisibleAsync();
        }
    }
}