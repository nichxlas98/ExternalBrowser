using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ExternalBrowser.Forms;

namespace ExternalBrowser
{
    class Program
    {
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize CefSharp
            CefSettings settings = new CefSettings
            {
                CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF",
                
                // Enable audio capture permission
                CefCommandLineArgs = { ["enable-media-stream"] = "1" }
            };

            Cef.Initialize(settings);

            Application.Run(new BrowserForm());
            
            // Shutdown CefSharp when the application exits
            Cef.Shutdown();
        }
    }
}