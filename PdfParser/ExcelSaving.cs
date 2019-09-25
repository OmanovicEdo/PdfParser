using ClosedXML.Excel;
using System.Collections.Generic;

namespace PdfParser
{
    class ExcelSaving
    {
        public static void Save(List<OutputData> items, string fileName)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("CSV Export");
                    worksheet.Cell("A1").Value = "Day processed";
                    worksheet.Cell("B1").Value = "Type of action";
                    worksheet.Cell("C1").Value = "Company name";
                    worksheet.Cell("D1").Value = "Company address line 1";
                    worksheet.Cell("E1").Value = "Company address line 2-3";
                    worksheet.Cell("F1").Value = "Filer name";
                    worksheet.Cell("G1").Value = "Filer address";
                    worksheet.Cell("H1").Value = "County";

                    int i = 2;
                    foreach (var item in items)
                    {
                        worksheet.Cell("A" + i).Value = item.DayProcessed;
                        worksheet.Cell("A" + i).DataType = XLDataType.DateTime;
                        worksheet.Cell("B" + i).Value = item.TypeOfAction;
                        worksheet.Cell("C" + i).Value = item.CompanyName;
                        worksheet.Cell("D" + i).Value = item.Address1;
                        worksheet.Cell("E" + i).Value = item.Address23;
                        worksheet.Cell("F" + i).Value = item.FilerName;
                        worksheet.Cell("G" + i).Value = item.FilerAddress;
                        worksheet.Cell("H" + i).Value = item.County;
                        ++i;
                    }

                    workbook.SaveAs(fileName);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

