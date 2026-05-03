namespace UseHelp
{
    partial class HelpWindow
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
            TipLabel = new Label();
            HelpListView = new TreeView();
            DecorationIcon = new PictureBox();
            CloseButton = new Button();
            OnlineHelpButton = new Button();
            InfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DecorationIcon).BeginInit();
            SuspendLayout();
            // 
            // TipLabel
            // 
            TipLabel.AutoSize = true;
            TipLabel.Font = new Font("Microsoft YaHei UI", 14.25F);
            TipLabel.Location = new Point(21, 9);
            TipLabel.Margin = new Padding(8, 0, 8, 0);
            TipLabel.Name = "TipLabel";
            TipLabel.Size = new Size(831, 62);
            TipLabel.TabIndex = 3;
            TipLabel.Text = "已列出部分常见问题，希望能帮助您~";
            // 
            // HelpListView
            // 
            HelpListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HelpListView.Location = new Point(21, 92);
            HelpListView.Margin = new Padding(8, 7, 8, 7);
            HelpListView.Name = "HelpListView";
            HelpListView.Size = new Size(1501, 683);
            HelpListView.TabIndex = 0;
            // 
            // DecorationIcon
            // 
            DecorationIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DecorationIcon.Location = new Point(1440, 9);
            DecorationIcon.Margin = new Padding(8, 7, 8, 7);
            DecorationIcon.Name = "DecorationIcon";
            DecorationIcon.Size = new Size(82, 73);
            DecorationIcon.SizeMode = PictureBoxSizeMode.Zoom;
            DecorationIcon.TabIndex = 2;
            DecorationIcon.TabStop = false;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(1317, 798);
            CloseButton.Margin = new Padding(8, 7, 8, 7);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(206, 92);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "关闭";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // OnlineHelpButton
            // 
            OnlineHelpButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OnlineHelpButton.Location = new Point(1095, 798);
            OnlineHelpButton.Margin = new Padding(8, 7, 8, 7);
            OnlineHelpButton.Name = "OnlineHelpButton";
            OnlineHelpButton.Size = new Size(206, 92);
            OnlineHelpButton.TabIndex = 1;
            OnlineHelpButton.Text = "联机帮助";
            OnlineHelpButton.UseVisualStyleBackColor = true;
            OnlineHelpButton.Click += OnlineHelpButton_Click;
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Location = new Point(21, 798);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(197, 78);
            InfoLabel.TabIndex = 4;
            InfoLabel.Text = "程序版本：\r\n运行时版本：";
            // 
            // HelpWindow
            // 
            AutoScaleDimensions = new SizeF(18F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1543, 918);
            Controls.Add(InfoLabel);
            Controls.Add(OnlineHelpButton);
            Controls.Add(CloseButton);
            Controls.Add(DecorationIcon);
            Controls.Add(HelpListView);
            Controls.Add(TipLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(8, 7, 8, 7);
            MaximizeBox = false;
            Name = "HelpWindow";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "手册";
            FormClosed += HelpWindow_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)DecorationIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TipLabel;
        private TreeView HelpListView;
        private PictureBox DecorationIcon;
        private Button CloseButton;
        private Button OnlineHelpButton;
        private Label InfoLabel;
    }
}
