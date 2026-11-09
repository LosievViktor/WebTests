using Microsoft.Playwright;

namespace PlaywrightTestExamples.Pages
{
    public sealed class FileUploadPage : BasePage
    {
        public FileUploadPage(IPage page) : base(page) { }

        private IFrameLocator iFrame => Page.FrameLocator(Locators.iFrame);
        public ILocator FileInput => iFrame.Locator(Locators.inputFile);
        public ILocator SelectedFilesLabel => iFrame.Locator("p", new() { HasText = Strings.MessageOfUpload });

        public async Task Upload(string file) =>
            await FileInput.SetInputFilesAsync(file);
    }
}