namespace MojoRobo.UI
{
    partial class Board
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReportButton = new System.Windows.Forms.Button();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FPlaceTextBox = new System.Windows.Forms.TextBox();
            this.YPlaceTextBox = new System.Windows.Forms.TextBox();
            this.XPlaceTextBox = new System.Windows.Forms.TextBox();
            this.PlaceButton = new System.Windows.Forms.Button();
            this.MoveButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.RoboPanel = new System.Windows.Forms.Panel();
            this.ClearLogsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.BoardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReportButton);
            this.groupBox1.Controls.Add(this.ExecuteButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FPlaceTextBox);
            this.groupBox1.Controls.Add(this.YPlaceTextBox);
            this.groupBox1.Controls.Add(this.XPlaceTextBox);
            this.groupBox1.Controls.Add(this.PlaceButton);
            this.groupBox1.Controls.Add(this.MoveButton);
            this.groupBox1.Controls.Add(this.LeftButton);
            this.groupBox1.Controls.Add(this.RightButton);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Corbel", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 424);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // ReportButton
            // 
            this.ReportButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportButton.Location = new System.Drawing.Point(286, 92);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(103, 34);
            this.ReportButton.TabIndex = 4;
            this.ReportButton.Text = "Report";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.Location = new System.Drawing.Point(176, 92);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(103, 34);
            this.ExecuteButton.TabIndex = 4;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "F";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // FPlaceTextBox
            // 
            this.FPlaceTextBox.Location = new System.Drawing.Point(151, 40);
            this.FPlaceTextBox.Name = "FPlaceTextBox";
            this.FPlaceTextBox.Size = new System.Drawing.Size(35, 24);
            this.FPlaceTextBox.TabIndex = 2;
            // 
            // YPlaceTextBox
            // 
            this.YPlaceTextBox.Location = new System.Drawing.Point(95, 40);
            this.YPlaceTextBox.Name = "YPlaceTextBox";
            this.YPlaceTextBox.Size = new System.Drawing.Size(35, 24);
            this.YPlaceTextBox.TabIndex = 2;
            // 
            // XPlaceTextBox
            // 
            this.XPlaceTextBox.Location = new System.Drawing.Point(37, 40);
            this.XPlaceTextBox.Name = "XPlaceTextBox";
            this.XPlaceTextBox.Size = new System.Drawing.Size(35, 24);
            this.XPlaceTextBox.TabIndex = 2;
            // 
            // PlaceButton
            // 
            this.PlaceButton.Location = new System.Drawing.Point(195, 35);
            this.PlaceButton.Name = "PlaceButton";
            this.PlaceButton.Size = new System.Drawing.Size(75, 32);
            this.PlaceButton.TabIndex = 1;
            this.PlaceButton.Text = "Place";
            this.PlaceButton.UseVisualStyleBackColor = true;
            this.PlaceButton.Click += new System.EventHandler(this.PlaceButton_Click);
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(474, 35);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(75, 32);
            this.MoveButton.TabIndex = 1;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(395, 35);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(35, 32);
            this.LeftButton.TabIndex = 0;
            this.LeftButton.Text = "◀";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(432, 35);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(35, 32);
            this.RightButton.TabIndex = 0;
            this.RightButton.Text = "▶";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.LogTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Corbel", 10F);
            this.groupBox2.Location = new System.Drawing.Point(13, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 149);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs";
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Location = new System.Drawing.Point(6, 23);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(556, 120);
            this.LogTextBox.TabIndex = 0;
            // 
            // BoardPanel
            // 
            this.BoardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoardPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BoardPanel.Controls.Add(this.RoboPanel);
            this.BoardPanel.Location = new System.Drawing.Point(179, 12);
            this.BoardPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(231, 231);
            this.BoardPanel.TabIndex = 2;
            this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            // 
            // RoboPanel
            // 
            this.RoboPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RoboPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RoboPanel.Location = new System.Drawing.Point(3, 194);
            this.RoboPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RoboPanel.Name = "RoboPanel";
            this.RoboPanel.Size = new System.Drawing.Size(33, 33);
            this.RoboPanel.TabIndex = 3;
            this.RoboPanel.Visible = false;
            // 
            // ClearLogsButton
            // 
            this.ClearLogsButton.Location = new System.Drawing.Point(522, 402);
            this.ClearLogsButton.Name = "ClearLogsButton";
            this.ClearLogsButton.Size = new System.Drawing.Size(60, 23);
            this.ClearLogsButton.TabIndex = 3;
            this.ClearLogsButton.Text = "Clear";
            this.ClearLogsButton.UseVisualStyleBackColor = true;
            this.ClearLogsButton.Click += new System.EventHandler(this.ClearLogsButton_Click);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 571);
            this.Controls.Add(this.ClearLogsButton);
            this.Controls.Add(this.BoardPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(610, 610);
            this.MinimumSize = new System.Drawing.Size(610, 610);
            this.Name = "Board";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MojoRobo - The Toy Robot Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.BoardPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FPlaceTextBox;
        private System.Windows.Forms.TextBox YPlaceTextBox;
        private System.Windows.Forms.TextBox XPlaceTextBox;
        private System.Windows.Forms.Button PlaceButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Panel RoboPanel;
        private System.Windows.Forms.Button ClearLogsButton;
    }
}

