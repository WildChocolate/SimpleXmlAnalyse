namespace ReadXmlFromCargowiseForm
{
    partial class SendFrm
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
            this.components = new System.ComponentModel.Container();
            this.editContentBox = new DevExpress.XtraRichEdit.RichEditControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.commonBar1 = new DevExpress.XtraRichEdit.UI.CommonBar();
            this.undoItem1 = new DevExpress.XtraRichEdit.UI.UndoItem();
            this.redoItem1 = new DevExpress.XtraRichEdit.UI.RedoItem();
            this.fileNewItem1 = new DevExpress.XtraRichEdit.UI.FileNewItem();
            this.fileOpenItem1 = new DevExpress.XtraRichEdit.UI.FileOpenItem();
            this.fileSaveItem1 = new DevExpress.XtraRichEdit.UI.FileSaveItem();
            this.fileSaveAsItem1 = new DevExpress.XtraRichEdit.UI.FileSaveAsItem();
            this.quickPrintItem1 = new DevExpress.XtraRichEdit.UI.QuickPrintItem();
            this.printItem1 = new DevExpress.XtraRichEdit.UI.PrintItem();
            this.printPreviewItem1 = new DevExpress.XtraRichEdit.UI.PrintPreviewItem();
            this.SendToCWBtn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.richEditBarController1 = new DevExpress.XtraRichEdit.UI.RichEditBarController();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CompressCheckBox = new System.Windows.Forms.CheckBox();
            this.responseTxt = new System.Windows.Forms.TextBox();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // editContentBox
            // 
            this.editContentBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editContentBox.EnableToolTips = true;
            this.editContentBox.Location = new System.Drawing.Point(0, 0);
            this.editContentBox.MenuManager = this.barManager1;
            this.editContentBox.Name = "editContentBox";
            this.editContentBox.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.editContentBox.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.editContentBox.Options.Printing.PrintPreviewFormKind = DevExpress.XtraRichEdit.PrintPreviewFormKind.Bars;
            this.editContentBox.Size = new System.Drawing.Size(668, 515);
            this.editContentBox.TabIndex = 0;
            this.editContentBox.Text = "Loading...";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.commonBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.undoItem1,
            this.redoItem1,
            this.fileNewItem1,
            this.fileOpenItem1,
            this.fileSaveItem1,
            this.fileSaveAsItem1,
            this.quickPrintItem1,
            this.printItem1,
            this.printPreviewItem1,
            this.barButtonItem1,
            this.barLargeButtonItem1,
            this.barButtonItem2,
            this.SendToCWBtn,
            this.barEditItem1,
            this.barButtonItem3,
            this.barLargeButtonItem2});
            this.barManager1.MaxItemId = 18;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1});
            // 
            // commonBar1
            // 
            this.commonBar1.Control = this.editContentBox;
            this.commonBar1.DockCol = 0;
            this.commonBar1.DockRow = 0;
            this.commonBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.commonBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.undoItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.redoItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileNewItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileOpenItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileSaveItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileSaveAsItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.quickPrintItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.printItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.SendToCWBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItem1)});
            // 
            // undoItem1
            // 
            this.undoItem1.Id = 0;
            this.undoItem1.Name = "undoItem1";
            // 
            // redoItem1
            // 
            this.redoItem1.Id = 1;
            this.redoItem1.Name = "redoItem1";
            // 
            // fileNewItem1
            // 
            this.fileNewItem1.Id = 2;
            this.fileNewItem1.Name = "fileNewItem1";
            // 
            // fileOpenItem1
            // 
            this.fileOpenItem1.Id = 3;
            this.fileOpenItem1.Name = "fileOpenItem1";
            // 
            // fileSaveItem1
            // 
            this.fileSaveItem1.Id = 4;
            this.fileSaveItem1.Name = "fileSaveItem1";
            // 
            // fileSaveAsItem1
            // 
            this.fileSaveAsItem1.Id = 5;
            this.fileSaveAsItem1.Name = "fileSaveAsItem1";
            // 
            // quickPrintItem1
            // 
            this.quickPrintItem1.Id = 6;
            this.quickPrintItem1.Name = "quickPrintItem1";
            // 
            // printItem1
            // 
            this.printItem1.Id = 7;
            this.printItem1.Name = "printItem1";
            // 
            // printPreviewItem1
            // 
            this.printPreviewItem1.Id = 8;
            this.printPreviewItem1.Name = "printPreviewItem1";
            // 
            // SendToCWBtn
            // 
            this.SendToCWBtn.Caption = "发送到Cargowise";
            this.SendToCWBtn.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.SendToCWBtn.Id = 12;
            this.SendToCWBtn.ImageUri.Uri = "Up";
            this.SendToCWBtn.Name = "SendToCWBtn";
            this.SendToCWBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1184, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Size = new System.Drawing.Size(1184, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 515);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1184, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 515);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Id = 10;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // richEditBarController1
            // 
            this.richEditBarController1.BarItems.Add(this.undoItem1);
            this.richEditBarController1.BarItems.Add(this.redoItem1);
            this.richEditBarController1.BarItems.Add(this.fileNewItem1);
            this.richEditBarController1.BarItems.Add(this.fileOpenItem1);
            this.richEditBarController1.BarItems.Add(this.fileSaveItem1);
            this.richEditBarController1.BarItems.Add(this.fileSaveAsItem1);
            this.richEditBarController1.BarItems.Add(this.quickPrintItem1);
            this.richEditBarController1.BarItems.Add(this.printItem1);
            this.richEditBarController1.BarItems.Add(this.printPreviewItem1);
            this.richEditBarController1.Control = this.editContentBox;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editContentBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CompressCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.responseTxt);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 515);
            this.splitContainer1.SplitterDistance = 668;
            this.splitContainer1.TabIndex = 5;
            // 
            // CompressCheckBox
            // 
            this.CompressCheckBox.AutoSize = true;
            this.CompressCheckBox.Checked = true;
            this.CompressCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompressCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompressCheckBox.Location = new System.Drawing.Point(0, 0);
            this.CompressCheckBox.Name = "CompressCheckBox";
            this.CompressCheckBox.Size = new System.Drawing.Size(512, 16);
            this.CompressCheckBox.TabIndex = 1;
            this.CompressCheckBox.Text = "Compress Response";
            this.CompressCheckBox.UseVisualStyleBackColor = true;
            // 
            // responseTxt
            // 
            this.responseTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseTxt.Location = new System.Drawing.Point(0, 0);
            this.responseTxt.Multiline = true;
            this.responseTxt.Name = "responseTxt";
            this.responseTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseTxt.Size = new System.Drawing.Size(512, 515);
            this.responseTxt.TabIndex = 0;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemFontEdit1;
            this.barEditItem1.EditWidth = 58;
            this.barEditItem1.Id = 15;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Reset";
            this.barButtonItem3.Id = 16;
            this.barButtonItem3.ImageUri.Uri = "Refresh";
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.Caption = "Reset";
            this.barLargeButtonItem2.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.barLargeButtonItem2.Id = 17;
            this.barLargeButtonItem2.ImageUri.Uri = "Refresh";
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem2_ItemClick_1);
            // 
            // SendFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "SendFrm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl editContentBox;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraRichEdit.UI.CommonBar commonBar1;
        private DevExpress.XtraRichEdit.UI.UndoItem undoItem1;
        private DevExpress.XtraRichEdit.UI.RedoItem redoItem1;
        private DevExpress.XtraRichEdit.UI.FileNewItem fileNewItem1;
        private DevExpress.XtraRichEdit.UI.FileOpenItem fileOpenItem1;
        private DevExpress.XtraRichEdit.UI.FileSaveItem fileSaveItem1;
        private DevExpress.XtraRichEdit.UI.FileSaveAsItem fileSaveAsItem1;
        private DevExpress.XtraRichEdit.UI.QuickPrintItem quickPrintItem1;
        private DevExpress.XtraRichEdit.UI.PrintItem printItem1;
        private DevExpress.XtraRichEdit.UI.PrintPreviewItem printPreviewItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraRichEdit.UI.RichEditBarController richEditBarController1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraBars.BarLargeButtonItem SendToCWBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox responseTxt;
        private System.Windows.Forms.CheckBox CompressCheckBox;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}