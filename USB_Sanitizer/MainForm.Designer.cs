
namespace USB_Sanitizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSanitize = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxExt = new System.Windows.Forms.TextBox();
            this.checkBoxMonitor = new System.Windows.Forms.CheckBox();
            this.listBoxExtensions = new System.Windows.Forms.ListBox();
            this.buttonRemoveExt = new System.Windows.Forms.Button();
            this.buttonAddExt = new System.Windows.Forms.Button();
            this.notifyIconOne = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrives.DropDownWidth = 230;
            this.comboBoxDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(92, 133);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(251, 28);
            this.comboBoxDrives.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(89, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "SELECT USB DRIVE:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 411);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.buttonSanitize);
            this.tabPage1.Controls.Add(this.comboBoxDrives);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MAIN";
            // 
            // buttonSanitize
            // 
            this.buttonSanitize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSanitize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSanitize.Location = new System.Drawing.Point(92, 167);
            this.buttonSanitize.Name = "buttonSanitize";
            this.buttonSanitize.Size = new System.Drawing.Size(251, 61);
            this.buttonSanitize.TabIndex = 3;
            this.buttonSanitize.Text = "SANITIZE!";
            this.buttonSanitize.UseVisualStyleBackColor = true;
            this.buttonSanitize.Click += new System.EventHandler(this.ButtonSanitize_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBoxExt);
            this.tabPage2.Controls.Add(this.checkBoxMonitor);
            this.tabPage2.Controls.Add(this.listBoxExtensions);
            this.tabPage2.Controls.Add(this.buttonRemoveExt);
            this.tabPage2.Controls.Add(this.buttonAddExt);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CONFIGURATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.MaximumSize = new System.Drawing.Size(400, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 40);
            this.label2.TabIndex = 12;
            this.label2.Text = "DELETE FILES WITH THE FOLLOWING EXTENSIONS";
            // 
            // textBoxExt
            // 
            this.textBoxExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxExt.Location = new System.Drawing.Point(25, 107);
            this.textBoxExt.MaxLength = 30;
            this.textBoxExt.Name = "textBoxExt";
            this.textBoxExt.Size = new System.Drawing.Size(118, 27);
            this.textBoxExt.TabIndex = 11;
            // 
            // checkBoxMonitor
            // 
            this.checkBoxMonitor.AutoSize = true;
            this.checkBoxMonitor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxMonitor.Location = new System.Drawing.Point(20, 23);
            this.checkBoxMonitor.Name = "checkBoxMonitor";
            this.checkBoxMonitor.Size = new System.Drawing.Size(213, 24);
            this.checkBoxMonitor.TabIndex = 10;
            this.checkBoxMonitor.Text = "MONITOR USB DRIVES";
            this.checkBoxMonitor.UseVisualStyleBackColor = true;
            this.checkBoxMonitor.CheckedChanged += new System.EventHandler(this.CheckBoxMonitor_CheckedChanged);
            // 
            // listBoxExtensions
            // 
            this.listBoxExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBoxExtensions.FormattingEnabled = true;
            this.listBoxExtensions.ItemHeight = 20;
            this.listBoxExtensions.Location = new System.Drawing.Point(25, 140);
            this.listBoxExtensions.Name = "listBoxExtensions";
            this.listBoxExtensions.ScrollAlwaysVisible = true;
            this.listBoxExtensions.Size = new System.Drawing.Size(219, 64);
            this.listBoxExtensions.TabIndex = 5;
            // 
            // buttonRemoveExt
            // 
            this.buttonRemoveExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveExt.Location = new System.Drawing.Point(25, 210);
            this.buttonRemoveExt.Name = "buttonRemoveExt";
            this.buttonRemoveExt.Size = new System.Drawing.Size(219, 34);
            this.buttonRemoveExt.TabIndex = 7;
            this.buttonRemoveExt.Text = "REMOVE FROM LIST";
            this.buttonRemoveExt.UseVisualStyleBackColor = true;
            this.buttonRemoveExt.Click += new System.EventHandler(this.ButtonRemoveExt_Click);
            // 
            // buttonAddExt
            // 
            this.buttonAddExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddExt.Location = new System.Drawing.Point(149, 107);
            this.buttonAddExt.Name = "buttonAddExt";
            this.buttonAddExt.Size = new System.Drawing.Size(95, 27);
            this.buttonAddExt.TabIndex = 6;
            this.buttonAddExt.Text = "ADD";
            this.buttonAddExt.UseVisualStyleBackColor = true;
            this.buttonAddExt.Click += new System.EventHandler(this.ButtonAddExt_Click);
            // 
            // notifyIconOne
            // 
            this.notifyIconOne.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconOne.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconOne.Icon")));
            this.notifyIconOne.Text = "USB Sanitizer";
            this.notifyIconOne.Visible = true;
            this.notifyIconOne.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconOne_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB SANITIZER";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonSanitize;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxExtensions;
        private System.Windows.Forms.Button buttonRemoveExt;
        private System.Windows.Forms.Button buttonAddExt;
        private System.Windows.Forms.TextBox textBoxExt;
        private System.Windows.Forms.CheckBox checkBoxMonitor;
        private System.Windows.Forms.NotifyIcon notifyIconOne;
        private System.Windows.Forms.Label label2;
    }
}

