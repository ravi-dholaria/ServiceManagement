namespace ServiceManagement
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.StartServiceBtn = new System.Windows.Forms.Button();
            this.StopServiceBtn = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1337, 396);
            this.dataGridView1.TabIndex = 0;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RefreshBtn.Location = new System.Drawing.Point(1157, 1);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(192, 34);
            this.RefreshBtn.TabIndex = 2;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // StartServiceBtn
            // 
            this.StartServiceBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartServiceBtn.Location = new System.Drawing.Point(12, 1);
            this.StartServiceBtn.Name = "StartServiceBtn";
            this.StartServiceBtn.Size = new System.Drawing.Size(139, 34);
            this.StartServiceBtn.TabIndex = 3;
            this.StartServiceBtn.Text = "Start";
            this.StartServiceBtn.UseVisualStyleBackColor = true;
            this.StartServiceBtn.Click += new System.EventHandler(this.StartServiceBtn_Click_1);
            // 
            // StopServiceBtn
            // 
            this.StopServiceBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StopServiceBtn.Location = new System.Drawing.Point(157, 1);
            this.StopServiceBtn.Name = "StopServiceBtn";
            this.StopServiceBtn.Size = new System.Drawing.Size(128, 34);
            this.StopServiceBtn.TabIndex = 4;
            this.StopServiceBtn.Text = "Stop";
            this.StopServiceBtn.UseVisualStyleBackColor = true;
            this.StopServiceBtn.Click += new System.EventHandler(this.StopServiceBtn_Click_1);
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchBox.Location = new System.Drawing.Point(356, 9);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(572, 22);
            this.SearchBox.TabIndex = 5;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search:";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ClearBtn.Location = new System.Drawing.Point(934, 9);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 449);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.StopServiceBtn);
            this.Controls.Add(this.StartServiceBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button StartServiceBtn;
        private System.Windows.Forms.Button StopServiceBtn;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearBtn;
    }
}

