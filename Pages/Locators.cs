namespace PlaywrightTestExamples.Pages
{
    public sealed class Locators
    {
        // Main page locator
        public const string headerTag = "h3";

        // Sample App page locators
        public const string txtLogin = "[name='UserName']";
        public const string txtPassword = "[name='Password']";
        public const string btnLogin = "#login";
        public const string lblStatus = "#loginstatus";

        // Progress Bar page locators
        public const string btnStart = "#startButton";
        public const string btnStop = "#stopButton";
        public const string ProgressBar = "#progressBar";
        public const string ProgressBarValue = "aria-valuenow";

        // File Upload page locators
        public const string iFrame = "iframe";
        public const string inputFile = "#browse";
    }
}