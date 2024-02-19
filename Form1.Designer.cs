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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1384, 396);
            this.dataGridView1.TabIndex = 0;
            //this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshBtn.Location = new System.Drawing.Point(1204, 1);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(192, 34);
            this.RefreshBtn.TabIndex = 2;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // StartServiceBtn
            // 
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
            this.StopServiceBtn.Location = new System.Drawing.Point(157, 1);
            this.StopServiceBtn.Name = "StopServiceBtn";
            this.StopServiceBtn.Size = new System.Drawing.Size(128, 34);
            this.StopServiceBtn.TabIndex = 4;
            this.StopServiceBtn.Text = "Stop";
            this.StopServiceBtn.UseVisualStyleBackColor = true;
            this.StopServiceBtn.Click += new System.EventHandler(this.StopServiceBtn_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 449);
            this.Controls.Add(this.StopServiceBtn);
            this.Controls.Add(this.StartServiceBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button StartServiceBtn;
        private System.Windows.Forms.Button StopServiceBtn;
    }
}

