namespace NeuroVoting
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.LanguageB = new System.Windows.Forms.Button();
            this.DescRTB = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.DebateB = new System.Windows.Forms.Button();
            this.ChangeDecisionCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.PlacetCLB = new System.Windows.Forms.CheckedListBox();
            this.ArgumentCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewArgumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteArgumentTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OppositeCLB = new System.Windows.Forms.CheckedListBox();
            this.MainInfoLabel = new System.Windows.Forms.Label();
            this.DecisionOFD = new System.Windows.Forms.OpenFileDialog();
            this.DecisionSFD = new System.Windows.Forms.SaveFileDialog();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.EndDebateCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PauseTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EndCMSSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.EndTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainPanel.SuspendLayout();
            this.ChangeDecisionCMS.SuspendLayout();
            this.ArgumentCMS.SuspendLayout();
            this.EndDebateCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.Info;
            this.MainPanel.Controls.Add(this.LanguageB);
            this.MainPanel.Controls.Add(this.DescRTB);
            this.MainPanel.Controls.Add(this.progressBar);
            this.MainPanel.Controls.Add(this.propertyGrid);
            this.MainPanel.Controls.Add(this.DebateB);
            this.MainPanel.Controls.Add(this.ScoreLabel);
            this.MainPanel.Controls.Add(this.PlacetCLB);
            this.MainPanel.Controls.Add(this.OppositeCLB);
            this.MainPanel.Controls.Add(this.MainInfoLabel);
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            // 
            // LanguageB
            // 
            resources.ApplyResources(this.LanguageB, "LanguageB");
            this.LanguageB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LanguageB.Name = "LanguageB";
            this.helpToolTip.SetToolTip(this.LanguageB, resources.GetString("LanguageB.ToolTip"));
            this.LanguageB.UseVisualStyleBackColor = false;
            this.LanguageB.Click += new System.EventHandler(this.LanguageB_Click);
            // 
            // DescRTB
            // 
            this.DescRTB.AcceptsTab = true;
            this.DescRTB.BackColor = System.Drawing.SystemColors.Info;
            this.DescRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DescRTB, "DescRTB");
            this.DescRTB.ForeColor = System.Drawing.SystemColors.InfoText;
            this.DescRTB.Name = "DescRTB";
            this.helpToolTip.SetToolTip(this.DescRTB, resources.GetString("DescRTB.ToolTip"));
            this.DescRTB.EnabledChanged += new System.EventHandler(this.DescRTB_EnabledChanged);
            this.DescRTB.TextChanged += new System.EventHandler(this.DescRTB_TextChanged);
            this.DescRTB.Enter += new System.EventHandler(this.DescRTB_Enter);
            this.DescRTB.Leave += new System.EventHandler(this.DescRTB_Leave);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.MarqueeAnimationSpeed = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // propertyGrid
            // 
            this.propertyGrid.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.propertyGrid.CategorySplitterColor = System.Drawing.SystemColors.ActiveCaption;
            this.propertyGrid.CommandsBackColor = System.Drawing.Color.PaleGoldenrod;
            this.propertyGrid.CommandsVisibleIfAvailable = false;
            resources.ApplyResources(this.propertyGrid, "propertyGrid");
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ActiveBorder;
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.ViewBackColor = System.Drawing.Color.PaleGoldenrod;
            this.propertyGrid.ViewBorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            this.propertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid_SelectedGridItemChanged);
            // 
            // DebateB
            // 
            resources.ApplyResources(this.DebateB, "DebateB");
            this.DebateB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DebateB.ContextMenuStrip = this.ChangeDecisionCMS;
            this.DebateB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DebateB.Name = "DebateB";
            this.DebateB.UseVisualStyleBackColor = false;
            this.DebateB.Click += new System.EventHandler(this.DebateB_Click);
            // 
            // ChangeDecisionCMS
            // 
            this.ChangeDecisionCMS.AllowMerge = false;
            this.ChangeDecisionCMS.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.ChangeDecisionCMS, "ChangeDecisionCMS");
            this.ChangeDecisionCMS.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ChangeDecisionCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI,
            this.toolStripSeparator2,
            this.createTSMI});
            this.ChangeDecisionCMS.Name = "DecisionCMS";
            // 
            // openTSMI
            // 
            this.openTSMI.Image = global::NeuroVoting.Properties.Resources.folder_open_icon;
            this.openTSMI.Name = "openTSMI";
            resources.ApplyResources(this.openTSMI, "openTSMI");
            this.openTSMI.Click += new System.EventHandler(this.DecisionTSMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // createTSMI
            // 
            this.createTSMI.Image = global::NeuroVoting.Properties.Resources._6c2103350605922a5e147f85e95e8e1c;
            this.createTSMI.Name = "createTSMI";
            resources.ApplyResources(this.createTSMI, "createTSMI");
            this.createTSMI.Click += new System.EventHandler(this.DecisionTSMI_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.BackColor = System.Drawing.Color.Orange;
            this.ScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScoreLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.ScoreLabel, "ScoreLabel");
            this.ScoreLabel.Name = "ScoreLabel";
            this.helpToolTip.SetToolTip(this.ScoreLabel, resources.GetString("ScoreLabel.ToolTip"));
            this.ScoreLabel.Click += new System.EventHandler(this.ScoreLabel_Click);
            // 
            // PlacetCLB
            // 
            this.PlacetCLB.BackColor = System.Drawing.Color.Green;
            this.PlacetCLB.ContextMenuStrip = this.ArgumentCMS;
            this.PlacetCLB.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.PlacetCLB, "PlacetCLB");
            this.PlacetCLB.FormattingEnabled = true;
            this.PlacetCLB.Name = "PlacetCLB";
            this.helpToolTip.SetToolTip(this.PlacetCLB, resources.GetString("PlacetCLB.ToolTip"));
            this.PlacetCLB.SelectedIndexChanged += new System.EventHandler(this.CLB_SelectedIndexChanged);
            this.PlacetCLB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CLB_KeyPress);
            // 
            // ArgumentCMS
            // 
            this.ArgumentCMS.AllowMerge = false;
            this.ArgumentCMS.BackColor = System.Drawing.Color.PowderBlue;
            resources.ApplyResources(this.ArgumentCMS, "ArgumentCMS");
            this.ArgumentCMS.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ArgumentCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewArgumentToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteArgumentTSMI});
            this.ArgumentCMS.Name = "ArgumentCMS";
            // 
            // addNewArgumentToolStripMenuItem
            // 
            this.addNewArgumentToolStripMenuItem.Image = global::NeuroVoting.Properties.Resources.GreenG;
            this.addNewArgumentToolStripMenuItem.Name = "addNewArgumentToolStripMenuItem";
            resources.ApplyResources(this.addNewArgumentToolStripMenuItem, "addNewArgumentToolStripMenuItem");
            this.addNewArgumentToolStripMenuItem.Click += new System.EventHandler(this.addNewArgumentTSMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // deleteArgumentTSMI
            // 
            this.deleteArgumentTSMI.Image = global::NeuroVoting.Properties.Resources.kisspng_computer_icons_x_mark_check_mark_clip_art_red_x_5ac2fb83ead779_9359571015227278119619;
            this.deleteArgumentTSMI.Name = "deleteArgumentTSMI";
            resources.ApplyResources(this.deleteArgumentTSMI, "deleteArgumentTSMI");
            this.deleteArgumentTSMI.Click += new System.EventHandler(this.deleteArgumentTSMI_Click);
            // 
            // OppositeCLB
            // 
            this.OppositeCLB.BackColor = System.Drawing.Color.Firebrick;
            this.OppositeCLB.ContextMenuStrip = this.ArgumentCMS;
            this.OppositeCLB.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.OppositeCLB, "OppositeCLB");
            this.OppositeCLB.FormattingEnabled = true;
            this.OppositeCLB.Name = "OppositeCLB";
            this.OppositeCLB.ThreeDCheckBoxes = true;
            this.helpToolTip.SetToolTip(this.OppositeCLB, resources.GetString("OppositeCLB.ToolTip"));
            this.OppositeCLB.SelectedIndexChanged += new System.EventHandler(this.CLB_SelectedIndexChanged);
            this.OppositeCLB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CLB_KeyPress);
            // 
            // MainInfoLabel
            // 
            this.MainInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainInfoLabel.Cursor = System.Windows.Forms.Cursors.Help;
            resources.ApplyResources(this.MainInfoLabel, "MainInfoLabel");
            this.MainInfoLabel.Name = "MainInfoLabel";
            this.helpToolTip.SetToolTip(this.MainInfoLabel, resources.GetString("MainInfoLabel.ToolTip"));
            this.MainInfoLabel.Click += new System.EventHandler(this.MainInfoLabel_Click);
            // 
            // DecisionOFD
            // 
            this.DecisionOFD.DefaultExt = "xml";
            resources.ApplyResources(this.DecisionOFD, "DecisionOFD");
            this.DecisionOFD.RestoreDirectory = true;
            this.DecisionOFD.SupportMultiDottedExtensions = true;
            this.DecisionOFD.FileOk += new System.ComponentModel.CancelEventHandler(this.DecisionFD_FileOk);
            // 
            // DecisionSFD
            // 
            resources.ApplyResources(this.DecisionSFD, "DecisionSFD");
            this.DecisionSFD.RestoreDirectory = true;
            this.DecisionSFD.FileOk += new System.ComponentModel.CancelEventHandler(this.DecisionFD_FileOk);
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 1000;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // EndDebateCMS
            // 
            this.EndDebateCMS.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.EndDebateCMS, "EndDebateCMS");
            this.EndDebateCMS.ImageScalingSize = new System.Drawing.Size(32, 24);
            this.EndDebateCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PauseTSMI,
            this.EndCMSSeparator,
            this.EndTSMI});
            this.EndDebateCMS.Name = "DecisionCMS";
            // 
            // PauseTSMI
            // 
            this.PauseTSMI.Image = global::NeuroVoting.Properties.Resources.Floppy;
            this.PauseTSMI.Name = "PauseTSMI";
            resources.ApplyResources(this.PauseTSMI, "PauseTSMI");
            this.PauseTSMI.Click += new System.EventHandler(this.EndDebateTSMI_Click);
            // 
            // EndCMSSeparator
            // 
            this.EndCMSSeparator.Name = "EndCMSSeparator";
            resources.ApplyResources(this.EndCMSSeparator, "EndCMSSeparator");
            // 
            // EndTSMI
            // 
            this.EndTSMI.Image = global::NeuroVoting.Properties.Resources.unnamed;
            this.EndTSMI.Name = "EndTSMI";
            resources.ApplyResources(this.EndTSMI, "EndTSMI");
            this.EndTSMI.Click += new System.EventHandler(this.EndDebateTSMI_Click);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutoPopDelay = 7000;
            this.helpToolTip.InitialDelay = 500;
            this.helpToolTip.IsBalloon = true;
            this.helpToolTip.ReshowDelay = 100;
            this.helpToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.helpToolTip.ToolTipTitle = "Help";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.MainPanel.ResumeLayout(false);
            this.ChangeDecisionCMS.ResumeLayout(false);
            this.ArgumentCMS.ResumeLayout(false);
            this.EndDebateCMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox OppositeCLB;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Label MainInfoLabel;
        private System.Windows.Forms.CheckedListBox PlacetCLB;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.ContextMenuStrip ArgumentCMS;
        private System.Windows.Forms.ToolStripMenuItem addNewArgumentToolStripMenuItem;
        private System.Windows.Forms.Button DebateB;
        private System.Windows.Forms.RichTextBox DescRTB;
        private System.Windows.Forms.OpenFileDialog DecisionOFD;
        private System.Windows.Forms.ContextMenuStrip ChangeDecisionCMS;
        private System.Windows.Forms.ToolStripMenuItem openTSMI;
        private System.Windows.Forms.ToolStripMenuItem createTSMI;
        private System.Windows.Forms.SaveFileDialog DecisionSFD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.ContextMenuStrip EndDebateCMS;
        private System.Windows.Forms.ToolStripMenuItem PauseTSMI;
        private System.Windows.Forms.ToolStripSeparator EndCMSSeparator;
        private System.Windows.Forms.ToolStripMenuItem EndTSMI;
        private System.Windows.Forms.ToolStripMenuItem deleteArgumentTSMI;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Button LanguageB;
    }
}

