using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PdfParser
{
    //TODO this heavy conversion process should be done in a thread properly
   public partial class PdfParserFrm : Form
   {
        List<string> pdfFiles = new List<string>();
        bool stopConverting = false;

        public PdfParserFrm()
        {
            InitializeComponent();

            txtSaveDestination.Text = Properties.Settings.Default.SaveDestination;
        }
                
        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            var fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = Properties.Settings.Default.AddFileFolderPath;
            fdialog.Multiselect = true;
            fdialog.Filter = "PDF files (*.pdf)|*.pdf";

            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.AddFileFolderPath = System.IO.Path.GetDirectoryName(fdialog.FileName);
                Properties.Settings.Default.Save();

                foreach (string name in fdialog.FileNames)
                {
                    pdfFiles.Add(name);
                    pdfFilesListbox.Items.Add(name);
                }
            }
        }

        private void BtnConvertToExcel_Click(object sender, EventArgs e)
        {
            //string solutionPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            var items = new List<OutputData>();
            stopConverting = false;

            for (int i = 0; i < pdfFiles.Count; i++)
            {
                using (var reader = new PdfReader(pdfFiles[i]))
                {
                    var parser = new PageParser();
                    progressBar.Maximum = reader.NumberOfPages;

                    lblProgressText.Text = "Document: " + i + "/" + pdfFiles.Count + ", Page: " + 1 + "/" + reader.NumberOfPages;
                    for (int page = 1; page < reader.NumberOfPages; page++)
                    {
                        if (stopConverting)
                            break;

                        if (page % 10 == 0)
                        {
                            lblProgressText.Text = "Document: " + (i+1) + "/" + pdfFiles.Count +
                                ", Page: " + page + "/" + reader.NumberOfPages;
                            progressBar.Value = page;
                            Application.DoEvents(); //force gui update..
                        }
                        items.AddRange(parser.Parse(PdfTextExtractor.GetTextFromPage(reader, page)));
                        progressBar.Value = progressBar.Maximum;
                    }

                    reader.Close();
                    string saveFileName = System.IO.Path.GetFileNameWithoutExtension(pdfFiles[i]) + ".xlsx";
                    try
                    {
                        ExcelSaving.Save(items, txtSaveDestination.Text + "\\" + saveFileName);
                    }
                    catch (Exception ex)
                    {
                        string msg = "Unable to create file: " + saveFileName + ". Is it already open?\n\n"
                            + ex.ToString();
                        MessageBox.Show(msg, "Error Excel saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }                
            }

            progressBar.Value = 0;
            if(stopConverting)
                lblProgressText.Text = "Conversion stopped!";
            else
                lblProgressText.Text = "Conversion finished!";
        }

        private void BtnConvertToCsv_Click(object sender, EventArgs e)
        {
            //string solutionPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            var items = new List<OutputData>();
            stopConverting = false;

            for (int i = 0; i < pdfFiles.Count; i++)
            {
                using (var reader = new PdfReader(pdfFiles[i]))
                {
                    var parser = new PageParser();
                    progressBar.Maximum = reader.NumberOfPages;

                    lblProgressText.Text = "Document: " + i + "/" + pdfFiles.Count + ", Page: " + 1 + "/" + reader.NumberOfPages;
                    for (int page = 1; page < reader.NumberOfPages; page++)
                    {
                        if (stopConverting)
                            break;

                        if (page % 10 == 0)
                        {
                            lblProgressText.Text = "Document: " + (i + 1) + "/" + pdfFiles.Count +
                                ", Page: " + page + "/" + reader.NumberOfPages;
                            progressBar.Value = page;
                            Application.DoEvents(); //force gui update..
                        }
                        items.AddRange(parser.Parse(PdfTextExtractor.GetTextFromPage(reader, page)));
                        progressBar.Value = progressBar.Maximum;
                    }

                    reader.Close();
                    string saveFileName = System.IO.Path.GetFileNameWithoutExtension(pdfFiles[i]) + ".csv";
                    try
                    {
                        CSVSaving.Save(items, txtSaveDestination.Text + "\\" + saveFileName);
                    }
                    catch (Exception ex)
                    {
                        string msg = "Unable to create file: " + saveFileName + ". Is it already open?\n\n"
                            + ex.ToString();
                        MessageBox.Show(msg, "Error CSV saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            progressBar.Value = 0;
            if (stopConverting)
                lblProgressText.Text = "Conversion stopped!";
            else
                lblProgressText.Text = "Conversion finished!";
        }

        private void TxtSaveDestination_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.SaveDestination;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSaveDestination.Text = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.SaveDestination = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            var selIndices = pdfFilesListbox.SelectedIndices;
            for (int i = selIndices.Count - 1; i >= 0; i--)
            {
                pdfFiles.RemoveAt(selIndices[i]);
                pdfFilesListbox.Items.RemoveAt(selIndices[i]);                
            }
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            pdfFilesListbox.Items.Clear();
            pdfFiles.Clear();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            stopConverting = true;            
        }

        private void BtnOpenDest_Click(object sender, EventArgs e)
        {
            string myComputerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            System.Diagnostics.Process.Start("explorer", txtSaveDestination.Text);
        }
    }
}

