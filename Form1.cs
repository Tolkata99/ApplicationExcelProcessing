using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ClosedXML.Excel;
using System.Globalization;

namespace WindowsFormsApp8
{
    public partial class Form1 : MaterialForm
    {
        private string loadedFilePath;
        private string outputDate;

        public Form1()
        {
            InitializeComponent();
            btnLoadFile.AllowDrop = true;

            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            this.btnLoadFile.DragEnter += new DragEventHandler(btnLoadFile_DragEnter);
            this.btnLoadFile.DragDrop += new DragEventHandler(btnLoadFile_DragDrop);

            this.btnProcessFile.Click += new EventHandler(btnProcessFile_Click);
            this.btnClear.Click += new EventHandler(btnClear_Click);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string file = files[0];
                string fileExtension = System.IO.Path.GetExtension(file).ToLower();

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    loadedFilePath = file;
                    lblStatus.Text = "Файлът е зареден успешно.";
                }
                else
                {
                    MessageBox.Show("Моля, изберете файл с разширение .xls или .xlsx.");
                    lblStatus.Text = "Неподдържан формат на файла.";
                }
            }
        }

        private void btnLoadFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btnLoadFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string file = files[0];
                string fileExtension = System.IO.Path.GetExtension(file).ToLower();

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    loadedFilePath = file;
                    lblStatus.Text = "Файлът е зареден успешно.";
                }
                else
                {
                    MessageBox.Show("Моля, изберете файл с разширение .xls или .xlsx.");
                    lblStatus.Text = "Неподдържан формат на файла.";
                }
            }
        }


        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loadedFilePath))
            {
                MessageBox.Show("Моля, първо заредете файл.");
                lblStatus.Text = "Моля, първо заредете файл.";
                return;
            }

            if (string.IsNullOrEmpty(outputDate)) // Check if the date has already been read and stored
            {
                try
                {
                    using (var workbook = new XLWorkbook(loadedFilePath))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var dateCellValue = worksheet.Cell(3, 1).GetValue<string>();
                        DateTime date;
                        if (DateTime.TryParse(dateCellValue, out date))
                        {
                            outputDate = date.ToString("ddMMyyyy"); // Store the formatted date for later use
                        }
                        else
                        {
                            MessageBox.Show("Не може да се прочете датата в правилния формат.");
                            lblStatus.Text = "Грешка при определяне на името на файла.";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Възникна грешка при четене на файла: {ex.Message}");
                    lblStatus.Text = "Възникна грешка при четене на файла.";
                    return;
                }
            }

            // Now that we have the date, proceed with processing the file
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var outputFileName = outputDate + "All#.xlsx"; // Use the stored date in the file name
            var outputFilePath = System.IO.Path.Combine(desktopPath, outputFileName);

            try
            {
                var newWorkbook = new XLWorkbook();
                var newWorksheet = newWorkbook.Worksheets.Add("Sheet1");

                int newRow = 1;
                using (var workbook = new XLWorkbook(loadedFilePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                    {
                        // Example logic for processing each row
                        // Adjust according to your actual needs
                        string eventLevel = worksheet.Cell(row, 6).Value.ToString();
                        string firstName = worksheet.Cell(row, 8).Value.ToString();
                        string cardNumber = worksheet.Cell(row, 10).Value.ToString();
                        string deviceName = worksheet.Cell(row, 3).Value.ToString();

                        if (!string.IsNullOrWhiteSpace(firstName) &&
                            !string.IsNullOrWhiteSpace(cardNumber) &&
                            eventLevel == "Normal" &&
                            deviceName != "Barrier Office" &&
                            deviceName != "Sofbuld Village Mee") // Ensure correct spelling if comparing strings
                        {
                            // Copy and modify data from specific columns as per your requirements
                            newWorksheet.Cell(newRow, 1).Value = worksheet.Cell(row, 11).Value; // Example: Department Name
                            newWorksheet.Cell(newRow, 2).Value = worksheet.Cell(row, 8).Value;  // Example: First Name

                            // Modifying the 'Time' column
                            var timeCell = worksheet.Cell(row, 1);
                            if (DateTime.TryParse(timeCell.Value.ToString(), out DateTime dateTime))
                            {
                                var formattedTime = dateTime.ToString("dd.MM.yyyy ã. HH:mm:ss", CultureInfo.InvariantCulture);
                                newWorksheet.Cell(newRow, 4).Value = formattedTime;  // Time with new format
                            }
                            else
                            {
                                newWorksheet.Cell(newRow, 4).Value = timeCell.Value;  // Keep original value if not a date
                            }

                            // Rest of the columns
                            var readerName = worksheet.Cell(row, 12).Value.ToString();
                            newWorksheet.Cell(newRow, 5).Value = readerName.Contains("-Out") ? "C/Out" : readerName.Contains("-In") ? "C/In" : readerName; // Reader Name with replacement
                            newWorksheet.Cell(newRow, 6).Value = worksheet.Cell(row, 4).Value;  // Event Point
                                                                                                // Seventh and eighth columns are left blank
                            newWorksheet.Cell(newRow, 9).Value = worksheet.Cell(row, 10).Value; // Card Number



                            newRow++;
                        }
                    }
                }

                newWorkbook.SaveAs(outputFilePath);
                lblStatus.Text = "Файлът е създаден успешно на работния плот с името " + outputFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Възникна грешка при обработка на файла: {ex.Message}");
                lblStatus.Text = "Възникна грешка при обработка на файла.";
            }
        }



    

        private void lblStatus_Click(object sender, EventArgs e)
        {
            // Логика за кликване на lblStatus, ако е необходимо
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализационна логика при зареждане на формата, ако е необходимо
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog1.Title = "Изберете Excel файл";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadedFilePath = openFileDialog1.FileName;
                lblStatus.Text = "Файлът е зареден успешно.";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            loadedFilePath = string.Empty;
            lblStatus.Text = string.Empty;
        }
    }
}
