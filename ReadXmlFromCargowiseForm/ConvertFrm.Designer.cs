namespace ReadXmlFromCargowiseForm
{
    partial class ConvertFrm
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
            this.FileTxt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FileContentTv = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOrigin = new System.Windows.Forms.TabPage();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.ResultTv = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabOrigin.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShipmentBtn
            // 
            this.ShipmentBtn.Location = new System.Drawing.Point(3, 21);
            this.ShipmentBtn.Name = "ShipmentBtn";
            this.ShipmentBtn.Size = new System.Drawing.Size(180, 23);
            this.ShipmentBtn.TabIndex = 0;
            this.ShipmentBtn.Text = "Shipment";
            this.ShipmentBtn.UseVisualStyleBackColor = true;
            this.ShipmentBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookingBtn
            // 
            this.BookingBtn.Location = new System.Drawing.Point(3, 119);
            this.BookingBtn.Name = "BookingBtn";
            this.BookingBtn.Size = new System.Drawing.Size(180, 23);
            this.BookingBtn.TabIndex = 1;
            this.BookingBtn.Text = "Booking";
            this.BookingBtn.UseVisualStyleBackColor = true;
            this.BookingBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // ShipmentFileBtn
            // 
            this.ShipmentFileBtn.Location = new System.Drawing.Point(3, 50);
            this.ShipmentFileBtn.Name = "ShipmentFileBtn";
            this.ShipmentFileBtn.Size = new System.Drawing.Size(180, 23);
            this.ShipmentFileBtn.TabIndex = 2;
            this.ShipmentFileBtn.Text = "ShipmentToFile";
            this.ShipmentFileBtn.UseVisualStyleBackColor = true;
            this.ShipmentFileBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // ConsolBtn
            // 
            this.ConsolBtn.Location = new System.Drawing.Point(3, 199);
            this.ConsolBtn.Name = "ConsolBtn";
            this.ConsolBtn.Size = new System.Drawing.Size(180, 23);
            this.ConsolBtn.TabIndex = 3;
            this.ConsolBtn.Text = "Consol";
            this.ConsolBtn.UseVisualStyleBackColor = true;
            this.ConsolBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // ConsolFileBtn
            // 
            this.ConsolFileBtn.Location = new System.Drawing.Point(3, 228);
            this.ConsolFileBtn.Name = "ConsolFileBtn";
            this.ConsolFileBtn.Size = new System.Drawing.Size(180, 23);
            this.ConsolFileBtn.TabIndex = 4;
            this.ConsolFileBtn.Text = "ConsoleToFile";
            this.ConsolFileBtn.UseVisualStyleBackColor = true;
            this.ConsolFileBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // BookingFileBtn
            // 
            this.BookingFileBtn.Location = new System.Drawing.Point(3, 148);
            this.BookingFileBtn.Name = "BookingFileBtn";
            this.BookingFileBtn.Size = new System.Drawing.Size(180, 23);
            this.BookingFileBtn.TabIndex = 5;
            this.BookingFileBtn.Text = "BookingToFile";
            this.BookingFileBtn.UseVisualStyleBackColor = true;
            this.BookingFileBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // FileTxt
            // 
            this.FileTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FileTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileTxt.Location = new System.Drawing.Point(13, 20);
            this.FileTxt.Name = "FileTxt";
            this.FileTxt.ReadOnly = true;
            this.FileTxt.Size = new System.Drawing.Size(733, 21);
            this.FileTxt.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\ekko.xu\\Documents\\visual studio 2013\\Projects\\ReadXmlFromCargowiseConsol" +
    "e\\ReadXmlFromCargowiseForm\\bin\\Debug\\XML";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.UploadBtn);
            this.splitContainer1.Panel1.Controls.Add(this.linkLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.FileTxt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(867, 578);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 8;
            // 
            // UploadBtn
            // 
            this.UploadBtn.Location = new System.Drawing.Point(753, 17);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(75, 23);
            this.UploadBtn.TabIndex = 9;
            this.UploadBtn.Text = "选择文件";
            this.UploadBtn.UseVisualStyleBackColor = true;
            this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(761, 67);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(101, 12);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Open in sendForm";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BookingFileBtn);
            this.splitContainer2.Panel1.Controls.Add(this.ShipmentBtn);
            this.splitContainer2.Panel1.Controls.Add(this.ConsolBtn);
            this.splitContainer2.Panel1.Controls.Add(this.ShipmentFileBtn);
            this.splitContainer2.Panel1.Controls.Add(this.ConsolFileBtn);
            this.splitContainer2.Panel1.Controls.Add(this.BookingBtn);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(867, 492);
            this.splitContainer2.SplitterDistance = 209;
            this.splitContainer2.TabIndex = 0;
            // 
            // FileContentTv
            // 
            this.FileContentTv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileContentTv.LabelEdit = true;
            this.FileContentTv.Location = new System.Drawing.Point(3, 3);
            this.FileContentTv.Name = "FileContentTv";
            this.FileContentTv.Size = new System.Drawing.Size(640, 460);
            this.FileContentTv.TabIndex = 0;
            this.FileContentTv.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.FileContentTV_AfterLabelEdit);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOrigin);
            this.tabControl1.Controls.Add(this.tabResult);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 492);
            this.tabControl1.TabIndex = 1;
            // 
            // tabOrigin
            // 
            this.tabOrigin.Controls.Add(this.FileContentTv);
            this.tabOrigin.Location = new System.Drawing.Point(4, 22);
            this.tabOrigin.Name = "tabOrigin";
            this.tabOrigin.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrigin.Size = new System.Drawing.Size(646, 466);
            this.tabOrigin.TabIndex = 0;
            this.tabOrigin.Text = "TabOrigin";
            this.tabOrigin.UseVisualStyleBackColor = true;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.ResultTv);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(646, 466);
            this.tabResult.TabIndex = 1;
            this.tabResult.Text = "TabResult";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // ResultTv
            // 
            this.ResultTv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTv.LabelEdit = true;
            this.ResultTv.Location = new System.Drawing.Point(3, 3);
            this.ResultTv.Name = "ResultTv";
            this.ResultTv.Size = new System.Drawing.Size(640, 460);
            this.ResultTv.TabIndex = 1;
            // 
            // ConvertFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 578);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConvertFrm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConvertFrm_Paint);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabOrigin.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShipmentBtn;
        private System.Windows.Forms.Button BookingBtn;
        private System.Windows.Forms.Button ShipmentFileBtn;
        private System.Windows.Forms.Button ConsolBtn;
        private System.Windows.Forms.Button ConsolFileBtn;
        private System.Windows.Forms.Button BookingFileBtn;
        private System.Windows.Forms.TextBox FileTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView FileContentTv;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOrigin;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TreeView ResultTv;
    }
}

