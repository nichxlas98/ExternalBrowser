using CefSharp.WinForms;

namespace ExternalBrowser
{
    // Define a class to represent tabs
    class TabInfo
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public ChromiumWebBrowser Browser { get; set; }
    }
}