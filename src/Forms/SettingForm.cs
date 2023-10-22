using System;
using System.Threading;
using System.Windows.Forms;

namespace ExternalBrowser.Forms
{
    public class SettingForm : Form
    {
        private ComboBox windowSizeCB;
        private Label crashReportL;
        private CheckBox checkBox1;
        private TextBox issueTitle;
        private Label bugReportL;
        private RichTextBox issueDesc;
        private LinkLabel repoLink;
        private Button subReportBtn;
        private Label settingsLabel;
        private Label windowSizeL;
        private Button homeBtn;
        private TextBox contactInfoTB;
        private Label reportInfoL;
        private Label label1;
        private ComboBox hotkeyCB;
        private BrowserForm mainForm;

        public SettingForm(BrowserForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.windowSizeL = new System.Windows.Forms.Label();
            this.windowSizeCB = new System.Windows.Forms.ComboBox();
            this.crashReportL = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.issueTitle = new System.Windows.Forms.TextBox();
            this.bugReportL = new System.Windows.Forms.Label();
            this.issueDesc = new System.Windows.Forms.RichTextBox();
            this.repoLink = new System.Windows.Forms.LinkLabel();
            this.subReportBtn = new System.Windows.Forms.Button();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.homeBtn = new System.Windows.Forms.Button();
            this.contactInfoTB = new System.Windows.Forms.TextBox();
            this.reportInfoL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hotkeyCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // windowSizeL
            // 
            this.windowSizeL.AutoSize = true;
            this.windowSizeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSizeL.Location = new System.Drawing.Point(12, 50);
            this.windowSizeL.Name = "windowSizeL";
            this.windowSizeL.Size = new System.Drawing.Size(87, 16);
            this.windowSizeL.TabIndex = 0;
            this.windowSizeL.Text = "Window Size:";
            this.windowSizeL.Click += new System.EventHandler(this.label1_Click);
            // 
            // windowSizeCB
            // 
            this.windowSizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowSizeCB.FormattingEnabled = true;
            this.windowSizeCB.Items.AddRange(new object[] {
            "1280x720",
            "800x600",
            "854x480",
            "600x480",
            "600x400"});
            this.windowSizeCB.Location = new System.Drawing.Point(105, 49);
            this.windowSizeCB.Name = "windowSizeCB";
            this.windowSizeCB.Size = new System.Drawing.Size(108, 21);
            this.windowSizeCB.TabIndex = 1;
            this.windowSizeCB.SelectedIndexChanged += new System.EventHandler(this.windowSizeCB_SelectedIndexChanged);
            // 
            // crashReportL
            // 
            this.crashReportL.AutoSize = true;
            this.crashReportL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crashReportL.Location = new System.Drawing.Point(242, 51);
            this.crashReportL.Name = "crashReportL";
            this.crashReportL.Size = new System.Drawing.Size(96, 16);
            this.crashReportL.TabIndex = 2;
            this.crashReportL.Text = "Crash Reports:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(344, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Send crash logs?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // issueTitle
            // 
            this.issueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueTitle.Location = new System.Drawing.Point(14, 301);
            this.issueTitle.Name = "issueTitle";
            this.issueTitle.Size = new System.Drawing.Size(176, 20);
            this.issueTitle.TabIndex = 4;
            this.issueTitle.Text = "Issue Title...";
            // 
            // bugReportL
            // 
            this.bugReportL.AutoSize = true;
            this.bugReportL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bugReportL.Location = new System.Drawing.Point(11, 255);
            this.bugReportL.Name = "bugReportL";
            this.bugReportL.Size = new System.Drawing.Size(78, 16);
            this.bugReportL.TabIndex = 5;
            this.bugReportL.Text = "Bug Report:";
            // 
            // issueDesc
            // 
            this.issueDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueDesc.Location = new System.Drawing.Point(15, 327);
            this.issueDesc.Name = "issueDesc";
            this.issueDesc.Size = new System.Drawing.Size(175, 58);
            this.issueDesc.TabIndex = 6;
            this.issueDesc.Text = "Issue Description...";
            // 
            // repoLink
            // 
            this.repoLink.AutoSize = true;
            this.repoLink.Location = new System.Drawing.Point(221, 401);
            this.repoLink.Name = "repoLink";
            this.repoLink.Size = new System.Drawing.Size(231, 13);
            this.repoLink.TabIndex = 7;
            this.repoLink.TabStop = true;
            this.repoLink.Text = "https://github.com/nichxlas98/ExternalBrowser";
            // 
            // subReportBtn
            // 
            this.subReportBtn.Location = new System.Drawing.Point(15, 391);
            this.subReportBtn.Name = "subReportBtn";
            this.subReportBtn.Size = new System.Drawing.Size(175, 23);
            this.subReportBtn.TabIndex = 8;
            this.subReportBtn.Text = "Send Bug Report";
            this.subReportBtn.UseVisualStyleBackColor = true;
            this.subReportBtn.Click += new System.EventHandler(this.sendBugReport_Click);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.Location = new System.Drawing.Point(180, 8);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(78, 20);
            this.settingsLabel.TabIndex = 9;
            this.settingsLabel.Text = "Settings";
            // 
            // homeBtn
            // 
            this.homeBtn.Location = new System.Drawing.Point(12, 8);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(55, 23);
            this.homeBtn.TabIndex = 10;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // contactInfoTB
            // 
            this.contactInfoTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactInfoTB.Location = new System.Drawing.Point(15, 276);
            this.contactInfoTB.Name = "contactInfoTB";
            this.contactInfoTB.Size = new System.Drawing.Size(175, 20);
            this.contactInfoTB.TabIndex = 11;
            this.contactInfoTB.Text = "Contact Info - Email, Discord, etc...";
            // 
            // reportInfoL
            // 
            this.reportInfoL.AutoSize = true;
            this.reportInfoL.Location = new System.Drawing.Point(221, 355);
            this.reportInfoL.Name = "reportInfoL";
            this.reportInfoL.Size = new System.Drawing.Size(196, 39);
            this.reportInfoL.TabIndex = 12;
            this.reportInfoL.Text = "Use https://pastebin.com/ and add it to\r\nthe issue description for detailed repor" +
    "ts.\r\nOr use github\'s issue system.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hide Hotkey:";
            // 
            // hotkeyCB
            // 
            this.hotkeyCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotkeyCB.FormattingEnabled = true;
            this.hotkeyCB.Items.AddRange(new object[] {
            "VK_BACK",
            "VK_TAB",
            "VK_ENTER",
            "VK_SHIFT",
            "VK_CTRL",
            "VK_ALT",
            "VK_PAUSE",
            "VK_CAPS_LOCK",
            "VK_ESCAPE",
            "VK_SPACE",
            "VK_PAGE_UP",
            "VK_PAGE_DOWN",
            "VK_END",
            "VK_HOME",
            "VK_LEFT",
            "VK_UP",
            "VK_RIGHT",
            "VK_DOWN",
            "VK_PRINT_SCREEN",
            "VK_INSERT",
            "VK_DELETE",
            "VK_0",
            "VK_1",
            "VK_2",
            "VK_3",
            "VK_4",
            "VK_5",
            "VK_6",
            "VK_7",
            "VK_8",
            "VK_9",
            "VK_A",
            "VK_B",
            "VK_C",
            "VK_D",
            "VK_E",
            "VK_F",
            "VK_G",
            "VK_H",
            "VK_I",
            "VK_J",
            "VK_K",
            "VK_L",
            "VK_M",
            "VK_N",
            "VK_O",
            "VK_P",
            "VK_Q",
            "VK_R",
            "VK_S",
            "VK_T",
            "VK_U",
            "VK_V",
            "VK_W",
            "VK_X",
            "VK_Y",
            "VK_Z"});
            this.hotkeyCB.Location = new System.Drawing.Point(105, 76);
            this.hotkeyCB.Name = "hotkeyCB";
            this.hotkeyCB.Size = new System.Drawing.Size(108, 21);
            this.hotkeyCB.TabIndex = 14;
            this.hotkeyCB.SelectedIndexChanged += new System.EventHandler(this.hotkeyCB_SelectedIndexChanged);
            // 
            // SettingForm
            // 
            this.ClientSize = new System.Drawing.Size(464, 428);
            this.ControlBox = false;
            this.Controls.Add(this.hotkeyCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportInfoL);
            this.Controls.Add(this.contactInfoTB);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.subReportBtn);
            this.Controls.Add(this.repoLink);
            this.Controls.Add(this.issueDesc);
            this.Controls.Add(this.bugReportL);
            this.Controls.Add(this.issueTitle);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.crashReportL);
            this.Controls.Add(this.windowSizeCB);
            this.Controls.Add(this.windowSizeL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void windowSizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (windowSizeCB.Text.Contains("Default") || windowSizeCB.Text == "")
            {
                MessageBox.Show("Please select a valid window size.");
                return;
            }

            int width = Convert.ToInt32(windowSizeCB.Text.Split('x')[0]);
            int height = Convert.ToInt32(windowSizeCB.Text.Split('x')[1]);
            mainForm.SetWindowSize(height, width);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sendBugReport_Click(object sender, EventArgs e)
        {
            if (contactInfoTB.Text == ""|| issueTitle.Text == "" || issueDesc.Text == "")
            {
                MessageBox.Show("Please enter a issue title and description, and a means of contact.", "Report Failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contactInfoTB.Text == "Contact Info - Email, Discord, etc..." || issueTitle.Text == "Issue Title..." || issueDesc.Text == "Issue Description...")
            {
                MessageBox.Show("Please enter a issue title and description, and a means of contact.", "Report Failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (issueDesc.Text.Length < 47)
            {
                MessageBox.Show("Please enter a longer issue description.", "Report Failed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DisHook.SendDiscordWebhook(
                "https://discord.com/api/webhooks/1029067247232221306/kqSKqY9wyGLpL0fWIkIHA2WzxnOGnqJD7F5UAjrLZf1maErHSnodHbjbdewPf8XgTgbD", 
                "",
                "ExternalBrowser — Bug Report",
                "Contact Info: " + contactInfoTB.Text + "\n" +
                "Title: " + issueTitle.Text + "\nDescription: " + issueDesc.Text + "\n" +
                "Date & Time: " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH: mm:ss"));

            issueTitle.Text = "Issue Title...";
            issueDesc.Text = "Issue Description...";
            MessageBox.Show("Successfully sent your bug report!");
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.ToggleFormVisibility();
        }

        private void hotkeyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int key = Key.FromString(hotkeyCB.Text);
            mainForm.SetHotkey(key);
        }
    }
}