namespace CheckForUpdatesAPP
{
    partial class Form1
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
            btnCheckForUpdates = new Button();
            progressBarUpdate = new ProgressBar();
            lblUpdateStatus = new Label();
            lblVersion = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCheckForUpdates
            // 
            btnCheckForUpdates.Location = new Point(12, 189);
            btnCheckForUpdates.Name = "btnCheckForUpdates";
            btnCheckForUpdates.Size = new Size(103, 65);
            btnCheckForUpdates.TabIndex = 0;
            btnCheckForUpdates.Text = "button1";
            btnCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // progressBarUpdate
            // 
            progressBarUpdate.Location = new Point(121, 237);
            progressBarUpdate.Name = "progressBarUpdate";
            progressBarUpdate.Size = new Size(255, 17);
            progressBarUpdate.TabIndex = 1;
            // 
            // lblUpdateStatus
            // 
            lblUpdateStatus.AutoSize = true;
            lblUpdateStatus.Location = new Point(143, 203);
            lblUpdateStatus.Name = "lblUpdateStatus";
            lblUpdateStatus.Size = new Size(38, 15);
            lblUpdateStatus.TabIndex = 2;
            lblUpdateStatus.Text = "label1";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(154, 95);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(75, 15);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "Version: 1.0.0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 27);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 4;
            label1.Text = "Update Checker";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 266);
            Controls.Add(label1);
            Controls.Add(lblVersion);
            Controls.Add(lblUpdateStatus);
            Controls.Add(progressBarUpdate);
            Controls.Add(btnCheckForUpdates);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCheckForUpdates;
        private ProgressBar progressBarUpdate;
        private Label lblUpdateStatus;
        private Label lblVersion;
        private Label label1;
    }
}
