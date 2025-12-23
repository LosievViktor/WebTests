namespace PlaywrightTestExamples.Pages
{
    public sealed class Strings
    {
        // Main page
        public static IEnumerable<string> Links => new[]
        {
                DynamicId,
                ClassAttribute,
                HiddenLayers,                
                AjaxData,
                ClientSideDelay,
                Click,
                TextInput,
                Scrollbars,
                DynamicTable,
                VerifyText,
                ProgressBar,
                Visibility,
                SampleApp,
                MouseOver,
                NonBreakingSpace,
                OverlappedElement,
                ShadowDom,
                Alerts,
                FileUpload,
                AnimatedButton,
                DisabledInput,
                AutoWait
        };

        public const string PageTitle = "UI Test Automation Playground";

        public const string Title = "UI Test Automation Playground";
        public const string DynamicId = "Dynamic ID";
        public const string ClassAttribute = "Class Attribute";
        public const string HiddenLayers = "Hidden Layers";
        public const string LoadDelay = "Load Delay";
        public const string AjaxData = "AJAX Data";
        public const string ClientSideDelay = "Client Side Delay";
        public const string Click = "Click";
        public const string TextInput = "Text Input";
        public const string Scrollbars = "Scrollbars";
        public const string DynamicTable = "Dynamic Table";
        public const string VerifyText = "Verify Text";
        public const string ProgressBar = "Progress Bar";
        public const string Visibility = "Visibility";
        public const string SampleApp = "Sample App";
        public const string MouseOver = "Mouse Over";
        public const string NonBreakingSpace = "Non-Breaking Space";
        public const string OverlappedElement = "Overlapped Element";
        public const string ShadowDom = "Shadow DOM";
        public const string Alerts = "Alerts";
        public const string FileUpload = "File Upload";
        public const string AnimatedButton = "Animated Button";
        public const string DisabledInput = "Disabled Input";
        public const string AutoWait = "Auto Wait";

        
        // SampleApp page.
        public const string WrongPasswordMessage = "Invalid username/password";
        public const string WelcomeUserMessage = "Welcome,";

        // Upload page.
        public const string MessageOfUpload = "1 file(s) selected";
    }
}