using System;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ExternalBrowser
{
    class Program
    {
        [STAThread]
        static void Main()
        {   
            Console.WriteLine("DEBUGGER");
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