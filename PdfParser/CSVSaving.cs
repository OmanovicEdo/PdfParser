using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PdfParser
{
    class CSVSaving
    {
        public static void Save(List<OutputData> items, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    string header = "Day processed, Type of action, Company name, Company address line 1, Company address line 2 - 3, Filer name, Filer address, County";
                    sw.WriteLine(header);

                    foreach (var item in items)
                    {

                        string row = PrepItem(item.DayProcessed.Date.ToShortDateString()) + ",";
                        row += PrepItem(item.TypeOfAction) + ",";
                        row += PrepItem(item.CompanyName) + ",";
                        row += PrepItem(item.Address1) + ",";
                        row += PrepItem(item.Address23) + ",";
                        row += PrepItem(item.FilerName) + ",";
                        row += PrepItem(item.FilerAddress) + ",";
                        row += PrepItem(item.County);
                        sw.WriteLine(row);
                    }
                }
            }
            catch
            {
                throw;
            }
        }        

        private static string PrepItem(string item)
        {
            if (item == null)
                return "";
            if (item.Contains(','))
                return "\"" + item + "\"";
            else
                return item;
        }
    }

    
}

