using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTestExamples.Pages
{
    public sealed class FileUploadPage : BasePage
    {
        public FileUploadPage(IPage page) : base(page) { }

        private IFrameLocator iFrame => Page.FrameLocator(Locators.iFrame);
        private ILocator fileInput => iFrame.Locator(Locators.inputFile);
        private ILocator Message => iFrame.Locator("p");

        public async Task Upload(string file) =>
            await fileInput.SetInputFilesAsync(file);

        public async Task AssertUploaded() =>
            await Assertions.Expect(Message).ToHaveTextAsync(Strings.MessageOfUpload);
    }
}
