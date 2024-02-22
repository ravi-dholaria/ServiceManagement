namespace ServiceManagement
{
    partial class ServiceDetailForm
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
            this.DisplayName = new System.Windows.Forms.Label();
            this.DisplayNametextBox = new System.Windows.Forms.TextBox();
            this.DescriptiontextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.StartTypeComboBox = new System.Windows.Forms.ComboBox();
            this.StartType = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ServiceFileBtn = new System.Windows.Forms.Button();
            this.SelectFileLabel = new System.Windows.Forms.Label();
            this.SerivceFileBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSize = true;
            this.DisplayName.Location = new System.Drawing.Point(99, 51);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(99, 16);
            this.DisplayName.TabIndex = 0;
            this.DisplayName.Text = "Service Name :";
            // 
            // DisplayNametextBox
            // 
            this.DisplayNametextBox.Location = new System.Drawing.Point(204, 48);
            this.DisplayNametextBox.Name = "DisplayNametextBox";
            this.DisplayNametextBox.Size = new System.Drawing.Size(163, 22);
            this.DisplayNametextBox.TabIndex = 1;
            // 
            // DescriptiontextBox
            // 
            this.DescriptiontextBox.Location = new System.Drawing.Point(204, 89);
            this.DescriptiontextBox.Name = "DescriptiontextBox";
            this.DescriptiontextBox.Size = new System.Drawing.Size(163, 22);
            this.DescriptiontextBox.TabIndex = 3;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(68, 92);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(130, 16);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Service Description :";
            // 
            // StartTypeComboBox
            // 
            this.StartTypeComboBox.FormattingEnabled = true;
            this.StartTypeComboBox.Location = new System.Drawing.Point(204, 130);
            this.StartTypeComboBox.Name = "StartTypeComboBox";
            this.StartTypeComboBox.Size = new System.Drawing.Size(163, 24);
            this.StartTypeComboBox.TabIndex = 4;
            // 
            // StartType
            // 
            this.StartType.AutoSize = true;
            this.StartType.Location = new System.Drawing.Point(108, 133);
            this.StartType.Name = "StartType";
            this.StartType.Size = new System.Drawing.Size(90, 16);
            this.StartType.TabIndex = 5;
            this.StartType.Text = "Startup Type :";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(158, 174);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(98, 35);
            this.SubmitBtn.TabIndex = 6;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ServiceFileBtn
            // 
            this.ServiceFileBtn.Location = new System.Drawing.Point(373, 12);
            this.ServiceFileBtn.Name = "ServiceFileBtn";
            this.ServiceFileBtn.Size = new System.Drawing.Size(86, 30);
            this.ServiceFileBtn.TabIndex = 7;
            this.ServiceFileBtn.Text = "Open";
            this.ServiceFileBtn.UseVisualStyleBackColor = true;
            this.ServiceFileBtn.Click += new System.EventHandler(this.ServiceFileBtn_Click);
            // 
            // SelectFileLabel
            // 
            this.SelectFileLabel.AutoSize = true;
            this.SelectFileLabel.Location = new System.Drawing.Point(73, 19);
            this.SelectFileLabel.Name = "SelectFileLabel";
            this.SelectFileLabel.Size = new System.Drawing.Size(125, 16);
            this.SelectFileLabel.TabIndex = 8;
            this.SelectFileLabel.Text = "Select Service File :";
            // 
            // SerivceFileBox
            // 
            this.SerivceFileBox.Location = new System.Drawing.Point(204, 16);
            this.SerivceFileBox.Name = "SerivceFileBox";
            this.SerivceFileBox.Size = new System.Drawing.Size(163, 22);
            this.SerivceFileBox.TabIndex = 9;
            // 
            // ServiceDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 307);
            this.Controls.Add(this.SerivceFileBox);
            this.Controls.Add(this.SelectFileLabel);
            this.Controls.Add(this.ServiceFileBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.StartType);
            this.Controls.Add(this.StartTypeComboBox);
            this.Controls.Add(this.DescriptiontextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DisplayNametextBox);
            this.Controls.Add(this.DisplayName);
            this.Name = "ServiceDetailForm";
            this.Text = "ServiceDetailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DisplayName;
        private System.Windows.Forms.TextBox DisplayNametextBox;
        private System.Windows.Forms.TextBox DescriptiontextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.ComboBox StartTypeComboBox;
        private System.Windows.Forms.Label StartType;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button ServiceFileBtn;
        private System.Windows.Forms.Label SelectFileLabel;
        private System.Windows.Forms.TextBox SerivceFileBox;
    }
}