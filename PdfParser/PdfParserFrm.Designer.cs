namespace PdfParser
{
    partial class PdfParserFrm
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
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.pdfFilesListbox = new System.Windows.Forms.ListBox();
            this.lblSelectedFiles = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressText = new System.Windows.Forms.Label();
            this.txtSaveDestination = new System.Windows.Forms.TextBox();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnConvertToExcel = new System.Windows.Forms.Button();
            this.lblSaveDestinationDescr = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnConvertToCsv = new System.Windows.Forms.Button();
            this.btnOpenDest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(30, 41);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(205, 75);
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "Add files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.BtnAddFiles_Click);
            // 
            // pdfFilesListbox
            // 
            this.pdfFilesListbox.FormattingEnabled = true;
            this.pdfFilesListbox.Location = new System.Drawing.Point(281, 37);
            this.pdfFilesListbox.Name = "pdfFilesListbox";
            this.pdfFilesListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.pdfFilesListbox.Size = new System.Drawing.Size(460, 199);
            this.pdfFilesListbox.TabIndex = 1;
            // 
            // lblSelectedFiles
            // 
            this.lblSelectedFiles.AutoSize = true;
            this.lblSelectedFiles.Location = new System.Drawing.Point(278, 21);
            this.lblSelectedFiles.Name = "lblSelectedFiles";
            this.lblSelectedFiles.Size = new System.Drawing.Size(97, 13);
            this.lblSelectedFiles.TabIndex = 2;
            this.lblSelectedFiles.Text = "Selected PDF files:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 351);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(716, 32);
            this.progressBar.TabIndex = 3;
            // 
            // lblProgressText
            // 
            this.lblProgressText.AutoSize = true;
            this.lblProgressText.Location = new System.Drawing.Point(344, 398);
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Size = new System.Drawing.Size(66, 13);
            this.lblProgressText.TabIndex = 4;
            this.lblProgressText.Text = "Progress bar";
            // 
            // txtSaveDestination
            // 
            this.txtSaveDestination.Location = new System.Drawing.Point(281, 325);
            this.txtSaveDestination.Name = "txtSaveDestination";
            this.txtSaveDestination.ReadOnly = true;
            this.txtSaveDestination.Size = new System.Drawing.Size(465, 20);
            this.txtSaveDestination.TabIndex = 6;
            this.txtSaveDestination.Click += new System.EventHandler(this.TxtSaveDestination_Click);
            // 
            // btnConvertToExcel
            // 
            this.btnConvertToExcel.Location = new System.Drawing.Point(30, 271);
            this.btnConvertToExcel.Name = "btnConvertToExcel";
            this.btnConvertToExcel.Size = new System.Drawing.Size(205, 75);
            this.btnConvertToExcel.TabIndex = 7;
            this.btnConvertToExcel.Text = "Convert to Excel";
            this.btnConvertToExcel.UseVisualStyleBackColor = true;
            this.btnConvertToExcel.Click += new System.EventHandler(this.BtnConvertToExcel_Click);
            // 
            // lblSaveDestinationDescr
            // 
            this.lblSaveDestinationDescr.AutoSize = true;
            this.lblSaveDestinationDescr.Location = new System.Drawing.Point(278, 306);
            this.lblSaveDestinationDescr.Name = "lblSaveDestinationDescr";
            this.lblSaveDestinationDescr.Size = new System.Drawing.Size(208, 13);
            this.lblSaveDestinationDescr.TabIndex = 8;
            this.lblSaveDestinationDescr.Text = "Click on textbox to select save destination:";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(458, 241);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(134, 23);
            this.btnRemoveSelected.TabIndex = 9;
            this.btnRemoveSelected.Text = "Remove selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.BtnRemoveSelected_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(607, 241);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(134, 23);
            this.btnRemoveAll.TabIndex = 10;
            this.btnRemoveAll.Text = "Remove all";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(543, 393);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(203, 43);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop converting";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnConvertToCsv
            // 
            this.btnConvertToCsv.Location = new System.Drawing.Point(30, 190);
            this.btnConvertToCsv.Name = "btnConvertToCsv";
            this.btnConvertToCsv.Size = new System.Drawing.Size(205, 75);
            this.btnConvertToCsv.TabIndex = 12;
            this.btnConvertToCsv.Text = "Convert to CSV";
            this.btnConvertToCsv.UseVisualStyleBackColor = true;
            this.btnConvertToCsv.Click += new System.EventHandler(this.BtnConvertToCsv_Click);
            // 
            // btnOpenDest
            // 
            this.btnOpenDest.Location = new System.Drawing.Point(607, 296);
            this.btnOpenDest.Name = "btnOpenDest";
            this.btnOpenDest.Size = new System.Drawing.Size(134, 23);
            this.btnOpenDest.TabIndex = 13;
            this.btnOpenDest.Text = "Open destination";
            this.btnOpenDest.UseVisualStyleBackColor = true;
            this.btnOpenDest.Click += new System.EventHandler(this.BtnOpenDest_Click);
            // 
            // PdfParserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 439);
            this.Controls.Add(this.btnOpenDest);
            this.Controls.Add(this.btnConvertToCsv);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.lblSaveDestinationDescr);
            this.Controls.Add(this.btnConvertToExcel);
            this.Controls.Add(this.txtSaveDestination);
            this.Controls.Add(this.lblProgressText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblSelectedFiles);
            this.Controls.Add(this.pdfFilesListbox);
            this.Controls.Add(this.btnAddFiles);
            this.Name = "PdfParserFrm";
            this.ShowIcon = false;
            this.Text = "PDF parser and converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ListBox pdfFilesListbox;
        private System.Windows.Forms.Label lblSelectedFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressText;
        private System.Windows.Forms.TextBox txtSaveDestination;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnConvertToExcel;
        private System.Windows.Forms.Label lblSaveDestinationDescr;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnConvertToCsv;
        private System.Windows.Forms.Button btnOpenDest;
    }
}

