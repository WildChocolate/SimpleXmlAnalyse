namespace ReadXmlFromCargowiseForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ShipmentBtn = new System.Windows.Forms.Button();
            this.BookingBtn = new System.Windows.Forms.Button();
            this.ShipmentFileBtn = new System.Windows.Forms.Button();
            this.ConsolBtn = new System.Windows.Forms.Button();
            this.ConsolFileBtn = new System.Windows.Forms.Button();
            this.BookingFileBtn = new System.Windows.Forms.Button();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ShipmentBtn
            // 
            this.ShipmentBtn.Location = new System.Drawing.Point(12, 110);
            this.ShipmentBtn.Name = "ShipmentBtn";
            this.ShipmentBtn.Size = new System.Drawing.Size(120, 23);
            this.ShipmentBtn.TabIndex = 0;
            this.ShipmentBtn.Text = "Shipment";
            this.ShipmentBtn.UseVisualStyleBackColor = true;
            this.ShipmentBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookingBtn
            // 
            this.BookingBtn.Location = new System.Drawing.Point(181, 110);
            this.BookingBtn.Name = "BookingBtn";
            this.BookingBtn.Size = new System.Drawing.Size(132, 23);
            this.BookingBtn.TabIndex = 1;
            this.BookingBtn.Text = "Booking";
            this.BookingBtn.UseVisualStyleBackColor = true;
            this.BookingBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // ShipmentFileBtn
            // 
            this.ShipmentFileBtn.Location = new System.Drawing.Point(12, 159);
            this.ShipmentFileBtn.Name = "ShipmentFileBtn";
            this.ShipmentFileBtn.Size = new System.Drawing.Size(120, 23);
            this.ShipmentFileBtn.TabIndex = 2;
            this.ShipmentFileBtn.Text = "ShipmentToFile";
            this.ShipmentFileBtn.UseVisualStyleBackColor = true;
            this.ShipmentFileBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // ConsolBtn
            // 
            this.ConsolBtn.Location = new System.Drawing.Point(372, 110);
            this.ConsolBtn.Name = "ConsolBtn";
            this.ConsolBtn.Size = new System.Drawing.Size(204, 23);
            this.ConsolBtn.TabIndex = 3;
            this.ConsolBtn.Text = "Consol";
            this.ConsolBtn.UseVisualStyleBackColor = true;
            this.ConsolBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // ConsolFileBtn
            // 
            this.ConsolFileBtn.Location = new System.Drawing.Point(372, 159);
            this.ConsolFileBtn.Name = "ConsolFileBtn";
            this.ConsolFileBtn.Size = new System.Drawing.Size(204, 23);
            this.ConsolFileBtn.TabIndex = 4;
            this.ConsolFileBtn.Text = "ConsoleToFile";
            this.ConsolFileBtn.UseVisualStyleBackColor = true;
            this.ConsolFileBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // BookingFileBtn
            // 
            this.BookingFileBtn.Location = new System.Drawing.Point(181, 159);
            this.BookingFileBtn.Name = "BookingFileBtn";
            this.BookingFileBtn.Size = new System.Drawing.Size(132, 23);
            this.BookingFileBtn.TabIndex = 5;
            this.BookingFileBtn.Text = "BookingToFile";
            this.BookingFileBtn.UseVisualStyleBackColor = true;
            this.BookingFileBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // UploadBtn
            // 
            this.UploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UploadBtn.Location = new System.Drawing.Point(498, 47);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(75, 23);
            this.UploadBtn.TabIndex = 6;
            this.UploadBtn.Text = "Select File";
            this.UploadBtn.UseVisualStyleBackColor = true;
            this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // FileBox
            // 
            this.FileBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FileBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileBox.Location = new System.Drawing.Point(12, 49);
            this.FileBox.Name = "FileBox";
            this.FileBox.ReadOnly = true;
            this.FileBox.Size = new System.Drawing.Size(472, 21);
            this.FileBox.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\ekko.xu\\Documents\\visual studio 2013\\Projects\\ReadXmlFromCargowiseConsol" +
    "e\\ReadXmlFromCargowiseForm\\bin\\Debug\\XML";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 213);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.UploadBtn);
            this.Controls.Add(this.BookingFileBtn);
            this.Controls.Add(this.ConsolFileBtn);
            this.Controls.Add(this.ConsolBtn);
            this.Controls.Add(this.ShipmentFileBtn);
            this.Controls.Add(this.BookingBtn);
            this.Controls.Add(this.ShipmentBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShipmentBtn;
        private System.Windows.Forms.Button BookingBtn;
        private System.Windows.Forms.Button ShipmentFileBtn;
        private System.Windows.Forms.Button ConsolBtn;
        private System.Windows.Forms.Button ConsolFileBtn;
        private System.Windows.Forms.Button BookingFileBtn;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.TextBox FileBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

