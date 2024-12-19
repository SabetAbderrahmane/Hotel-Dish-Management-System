using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HotelDishManagement
{
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
        }

        // Event handler for Generate Report button
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Example logic: Populate the DataGrid with dummy data
            var reportData = new List<Report>
            {
                new Report { Date = DateTime.Now, Item = "Dish 1", Quantity = 10, Status = "Available" },
                new Report { Date = DateTime.Now, Item = "Dish 2", Quantity = 5, Status = "Low Stock" },
            };

            ReportDataGrid.ItemsSource = reportData;
        }

        // Event handler for Export to CSV
        private void ExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            if (ReportDataGrid.ItemsSource is IEnumerable<Report> reportData)
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Save CSV File"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine("Date,Item,Quantity,Status");

                            foreach (var report in reportData)
                            {
                                writer.WriteLine($"{report.Date},{report.Item},{report.Quantity},{report.Status}");
                            }
                        }

                        MessageBox.Show("Export to CSV completed successfully!", "Export Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while exporting to CSV: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export!", "Export Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for Export to PDF
        private void ExportToPDF_Click(object sender, RoutedEventArgs e)
        {
            if (ReportDataGrid.ItemsSource is IEnumerable<Report> reportData)
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save PDF File"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            var document = new Document();
                            PdfWriter.GetInstance(document, stream);

                            document.Open();

                            var titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                            document.Add(new Paragraph("Report", titleFont));
                            document.Add(new Paragraph($"Generated on: {DateTime.Now}"));
                            document.Add(new Paragraph("\n"));

                            var table = new PdfPTable(4) { WidthPercentage = 100 };
                            table.AddCell("Date");
                            table.AddCell("Item");
                            table.AddCell("Quantity");
                            table.AddCell("Status");

                            foreach (var report in reportData)
                            {
                                table.AddCell(report.Date.ToString("g"));
                                table.AddCell(report.Item);
                                table.AddCell(report.Quantity.ToString());
                                table.AddCell(report.Status);
                            }

                            document.Add(table);
                            document.Close();
                        }

                        MessageBox.Show("Export to PDF completed successfully!", "Export Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while exporting to PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export!", "Export Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class Report
    {
        public DateTime Date { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
