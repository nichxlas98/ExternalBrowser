using System;
using System.Threading;
using System.Windows.Forms;
using CefSharp.WinForms;
using System.Collections.Generic;
using System.Net;
using CefSharp;


namespace ExternalBrowser
{
    public class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser webBrowser;
        private Dictionary<ToolStripMenuItem, TabInfo> openTabs = new Dictionary<ToolStripMenuItem, TabInfo>();
        private static readonly ContextMenuStrip tabsDropdown = new ContextMenuStrip();

        private static bool isFormVisible = true;
        private static int appHeight = 480;
        private static int appWidth = 854;

        public BrowserForm()
        {
            Text = "ExternalBrowser";
            Width = 854;
            Height = 480;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;

            webBrowser = new ChromiumWebBrowser("https://discord.com/channels/@me")
            {
                Dock = DockStyle.Fill
            };

            this.Shown += new EventHandler(Form1_Shown);

            // Add an event handler for the LoadError event to capture CefSharp errors
            webBrowser.LoadError += Browser_LoadError;

            JsHandler jh = new JsHandler();
            webBrowser.JsDialogHandler = jh;

            RegisterControls();
            AddNewTab("https://discord.com/channels/@me", "https://discord.com/channels/@me");

            // Create a thread for listening to the hotkey
            Thread hotkeyThread = new Thread(() =>
            {
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
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
            Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
        }

        private void Browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            // To Be Removed - error MessageBox example for later
            //string errorMessage = $"Error loading URL '{e.FailedUrl}': {e.ErrorText}";
            //MessageBox.Show(errorMessage, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // URL doesn't exist, so search for it.
            string url = e.FailedUrl.Replace("http://", "");
            webBrowser.Load("https://google.com/search?q=" + url.Substring(0, url.Length - 1));
        }

        private void RegisterControls()
        {
            // Create UI controls and set their properties
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
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(editSizeButton.Right + 10, editSizeButton.Top),
            };

            TextBox widthTextBox = new TextBox
            {
                Location = new System.Drawing.Point(widthLabel.Right + 5, editSizeButton.Top),
                Width = 35,
                Text = Width.ToString(),
            };

            Label heightLabel = new Label
            {
                Text = "Height:",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(widthTextBox.Right + 10, editSizeButton.Top),
            };

            TextBox heightTextBox = new TextBox
            {
                Location = new System.Drawing.Point(heightLabel.Right + 5, editSizeButton.Top),
                Width = 35,
                Text = Height.ToString(),
            };

            Button exitButton = new Button
            {
                Text = "Exit",
                Location = new System.Drawing.Point(hideButton.Right + 10, 10)
            };

            Button viewTabsButton = new Button
            {
                Text = "View Tabs",
                Location = new System.Drawing.Point(exitButton.Right + 10, 10)
            };

            // Add event handlers for buttons
            navigateButton.Click += (sender, e) =>
            {
                string urlTitle = searchBar.Text.Replace("https://", "").Replace("http://", "");
                webBrowser.Load(AddNewTab(searchBar.Text, urlTitle));
            };

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

            editSizeButton.Click += (sender, e) =>
            {
                // Parse the String provided in the Text boxes as integers.
                if (int.TryParse(widthTextBox.Text, out int newWidth) &&
                    int.TryParse(heightTextBox.Text, out int newHeight))
                {
                    // Resize application constants for consistency using the integers provided.
                    Width = newWidth;
                    Height = newHeight;

                    appWidth = newWidth;
                    appHeight = newHeight;

                    // Move the form to the new position (center of the screen)
                    Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                    Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
                }
            };

            exitButton.Click += (sender, e) =>
            {
                Application.Exit();
                Close(); // Close the application
            };

            viewTabsButton.Click += (sender, e) =>
            {
                ViewTabs(viewTabsButton); // Dropdown view of application's opened tabs.
            };

            // Add controls to the form
            Controls.Add(viewTabsButton);
            Controls.Add(searchBar);
            
            Controls.Add(navigateButton);
            Controls.Add(hideButton);
            Controls.Add(exitButton);
            Controls.Add(editSizeButton);

            Controls.Add(heightLabel);
            Controls.Add(heightTextBox);
            Controls.Add(widthLabel);
            Controls.Add(widthTextBox);

            Controls.Add(webBrowser);
        }

        private void ToggleFormVisibility()
        {
            Invoke((MethodInvoker)delegate
            {
                if (isFormVisible)
                {
                    //Hide();
                    Height = 0;
                    Width = 0;
                    Left = 0;
                    Top = Screen.PrimaryScreen.Bounds.Height - Height;
                    TopMost = false;
                }
                else
                {
                    //Show();
                    BringToFront();
                    Width = appWidth;
                    Height = appHeight;
                    Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                    Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
                    TopMost = true;
                }

                isFormVisible = !isFormVisible;
            });
        }

        private void OpenTab(string url)
        {
            webBrowser.Load(url);
        }

        private void CloseTab(ToolStripMenuItem tabItem, string url)
        {
            tabsDropdown.Items.Remove(tabItem);
            openTabs.Remove(tabItem);

            if (webBrowser.Address == url)
            {
                OpenTab(AddNewTab("https://google.com", "Google"));
            }
        }

        private string AddNewTab(string url, string title)
        {

            TabInfo tabInfo = new TabInfo { Url = url, Title = title };
            ToolStripMenuItem tabItem = new ToolStripMenuItem(title);

            tabItem.Click += (sender, e) => OpenTab(url);
            tabItem.MouseDown += (sender, e) => CloseTab(tabItem, url);

            openTabs.Add(tabItem, tabInfo);
            tabsDropdown.Items.Add(tabItem);

            return url;
        }

        private void ViewTabs(Button viewTabsButton)
        {
            tabsDropdown.Items.Clear();

            foreach (var tab in openTabs.Values)
            {
                ToolStripMenuItem tabItem = new ToolStripMenuItem(tab.Title);
                tabItem.Click += (tabSender, tabE) => OpenTab(tab.Url);

                tabItem.MouseDown += (tabSender, tabE) =>
                {
                    if (tabE.Button == MouseButtons.Right)
                    {
                        CloseTab(tabItem, tab.Url);
                    }
                };

                tabsDropdown.Items.Add(tabItem);
            }

            tabsDropdown.Show(viewTabsButton, new System.Drawing.Point(0, viewTabsButton.Height));
        }
    }
}