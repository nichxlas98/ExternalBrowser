/*
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
        private static Form form;
        private static ChromiumWebBrowser webBrowser;
        private static bool isFormVisible = true;

        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int WM_NCHITTEST = 0x0084;
        private const int HTTRANSPARENT = (-1);

        private static int HEIGHT = 480;
        private static int WIDTH = 854;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Create a dictionary to track open tabs
        private static readonly Dictionary<ToolStripMenuItem, TabInfo> openTabs = new Dictionary<ToolStripMenuItem, TabInfo>();

        private static readonly ContextMenuStrip tabsDropdown = new ContextMenuStrip();
        
        [STAThread]
        static void Main()
        {
            // Initialize CefSharp
            CefSettings settings = new CefSettings
            {
                CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF",
                // Enable audio capture permission
                CefCommandLineArgs = { ["enable-media-stream"] = "1" }
            };

            Cef.Initialize(settings);

            // Create a Form and ChromiumWebBrowser
            form = new Form
            {
                Text = "ExternalBrowser",
                Width = WIDTH,
                Height = HEIGHT,
                FormBorderStyle = FormBorderStyle.None, // No borders
                TopMost = true // Always on top
            };

            webBrowser = new ChromiumWebBrowser("https://discord.com/channels/@me")
            {
                Dock = DockStyle.Fill
            };

            Register();
            AddNewTab("https://discord.com/channels/@me", "https://discord.com/channels/@me");

            // Create a thread for the form
            Thread formThread = new Thread(() =>
            {
                System.Windows.Forms.Application.Run(form);
            });
            formThread.SetApartmentState(ApartmentState.STA); // Required for Windows Forms
            formThread.Start();

            // Create a thread for listening to the hotkey
            Thread hotkeyThread = new Thread(() =>
            {
                Thread.Sleep(1000);
                ToggleFormVisibility();
                ToggleFormVisibility();

                const int VK_RIGHT_ALT = 0xA5; // Virtual key code for RIGHT_ALT
                while (true)
                {
                    if (NativeMethods.GetAsyncKeyState(VK_RIGHT_ALT) != 0)
                    {
                        ToggleFormVisibility();
                        Thread.Sleep(100); // Sleep to avoid rapid toggling due to key repetition
                    }
                    Thread.Sleep(10); // Polling interval
                }
            });
            hotkeyThread.Start();

            // Wait for both threads to finish
            formThread.Join();
            hotkeyThread.Join();

            // Shutdown CefSharp when the application exits
            Cef.Shutdown();
        }

        private static void ToggleFormVisibility()
        {
            form.Invoke((MethodInvoker)delegate
            {
                
                if (isFormVisible)
                {
                    // Hide the form
                    //form.Hide();

                    form.Height = 0;
                    form.Width = 0;

                    // Move the form to the bottom left corner of the screen
                    form.Left = 0;
                    form.Top = Screen.PrimaryScreen.Bounds.Height - form.Height;

                    form.TopMost = false;
                }
                else 
                {
                    // Show the form
                    //form.Show();

                    form.BringToFront();

                    form.Width = WIDTH;
                    form.Height = HEIGHT;

                    // Move the form to a new position (e.g., center of the screen)
                    form.Left = (Screen.PrimaryScreen.Bounds.Width - form.Width) / 2;
                    form.Top = (Screen.PrimaryScreen.Bounds.Height - form.Height) / 2;

                    form.TopMost = true;
                }

                isFormVisible = !isFormVisible;
                //form.Visible = isFormVisible;
            });
        }

        private static void OpenTab(string url)
        {
            webBrowser.Load(url);
            
            //webBrowser = tabs[url];
            //form.Controls.Add(webBrowser);


            // Logic to open a new tab or navigate an existing tab
            // You can create a new instance of ChromiumWebBrowser or reuse an existing one
            // and load the URL.
        }

        private static void CloseTab(ToolStripMenuItem tabItem, string url)
        {
            tabsDropdown.Items.Remove(tabItem);
            openTabs.Remove(tabItem);
            // Logic to close the tab and remove it from the UI
        }

        private static void AddNewTab(string url, string title)
        {
            TabInfo tabInfo = new TabInfo { Url = url, Title = title };
            ToolStripMenuItem tabItem = new ToolStripMenuItem(title);
            tabItem.Click += (sender, e) => OpenTab(url);
            tabItem.MouseDown += (sender, e) => CloseTab(tabItem, url);

            openTabs.Add(tabItem, tabInfo);
            tabsDropdown.Items.Add(tabItem);

            
            //tabs.Add(url, new ChromiumWebBrowser("https://discord.com/channels/@me"){Dock = DockStyle.Fill});
        }

        private static void Register() {
            // Inside your form initialization code
            TextBox searchBar = new TextBox
            {
                Width = 300,
                Location = new System.Drawing.Point(10, 10)
            };

            Button navigateButton = new Button
            {
                Text = "Go",
                Location = new System.Drawing.Point(searchBar.Right + 10, 10)
            };

            navigateButton.Click += (sender, e) =>
            {
                webBrowser.Load(searchBar.Text);
                AddNewTab(searchBar.Text, searchBar.Text);
            };

            Button hideButton = new Button
            {
                Text = "Toggle",
                Location = new System.Drawing.Point(navigateButton.Right + 10, 10)
            };

            Button editSizeButton = new Button
            {
                Text = "Edit Size",
                Location = new System.Drawing.Point(10, navigateButton.Bottom + 10)
            };          

            Label widthLabel = new Label
            {
                Text = "Width:",
                Location = new System.Drawing.Point(editSizeButton.Right + 10, editSizeButton.Top + 3),
            };

            TextBox widthTextBox = new TextBox
            {
                Location = new System.Drawing.Point(widthLabel.Right + 5, editSizeButton.Top),
                Width = 60,
                Text = form.Width.ToString(),
            };

            Label heightLabel = new Label
            {
                Text = "Height:",
                Location = new System.Drawing.Point(widthTextBox.Right + 10, editSizeButton.Top + 3),
            };

            TextBox heightTextBox = new TextBox
            {
                Location = new System.Drawing.Point(heightLabel.Right + 5, editSizeButton.Top),
                Width = 60,
                Text = form.Height.ToString(),
            }; 

            Button exitButton = new Button
            {
                Text = "Exit",
                Location = new System.Drawing.Point(hideButton.Right + 10, 10)
            };       

            exitButton.Click += (sender, e) =>
            {
                form.Close(); // Close the application
            };
            
            editSizeButton.Click += (sender, e) =>
            {
                if (int.TryParse(widthTextBox.Text, out int newWidth) &&
                    int.TryParse(heightTextBox.Text, out int newHeight))
                {
                    form.Width = newWidth;
                    form.Height = newHeight;

                    WIDTH = newWidth;
                    HEIGHT = newHeight;

                    // Move the form to a new position (e.g., center of the screen)
                    form.Left = (Screen.PrimaryScreen.Bounds.Width - form.Width) / 2;
                    form.Top = (Screen.PrimaryScreen.Bounds.Height - form.Height) / 2;
                }
            };

            Button viewTabsButton = new Button
            {
                Text = "View Tabs",
                Location = new System.Drawing.Point(exitButton.Right + 10, 10)
            };
                        
            viewTabsButton.Click += (sender, e) =>
            {
                tabsDropdown.Items.Clear();
            
                foreach (var tab in openTabs.Values)
                {
                    ToolStripMenuItem tabItem = new ToolStripMenuItem(tab.Title);
                    tabItem.Click += (tabSender, tabE) =>
                    {
                        // Handle left-click to open the tab
                        OpenTab(tab.Url);
                    };
            
                    tabItem.MouseDown += (tabSender, tabE) =>
                    {
                        if (tabE.Button == MouseButtons.Right)
                        {
                            // Handle right-click to close the tab
                            CloseTab(tabItem, tab.Url);
                        }
                    };
            
                    tabsDropdown.Items.Add(tabItem);
                }
            
                tabsDropdown.Show(viewTabsButton, new System.Drawing.Point(0, viewTabsButton.Height));
            };
            
            form.Controls.Add(viewTabsButton);

            hideButton.Click += (sender, e) =>
            {
                viewTabsButton.Visible = !viewTabsButton.Visible;
                searchBar.Visible = !searchBar.Visible;
                navigateButton.Visible = !navigateButton.Visible;
                editSizeButton.Visible = !editSizeButton.Visible;
                heightLabel.Visible = !heightLabel.Visible;
                heightTextBox.Visible = !heightTextBox.Visible;
                widthLabel.Visible = !widthLabel.Visible;
                widthTextBox.Visible = !widthTextBox.Visible;
                exitButton.Visible = !exitButton.Visible;
            };

            form.Controls.Add(searchBar);
            form.Controls.Add(navigateButton);
            form.Controls.Add(hideButton);
            form.Controls.Add(exitButton);
            form.Controls.Add(editSizeButton);
            form.Controls.Add(heightLabel);
            form.Controls.Add(heightTextBox);
            form.Controls.Add(widthLabel);
            form.Controls.Add(widthTextBox);

            form.Controls.Add(webBrowser);
        }
    }

    // NativeMethods class to import user32.dll for GetAsyncKeyState function
    class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }

    // Define a class to represent tabs
    class TabInfo
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public ChromiumWebBrowser Browser { get; set; }

    }
}
*/
