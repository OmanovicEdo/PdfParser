using System;
using System.Collections.Generic;
using System.Linq;

namespace PdfParser
{
    class PageParser
    {
        public List<OutputData> Parse(string pageText)
        {                                                                        
            string typeOfAction = ""; //once per page
            string datetime = ""; //once per page
            string fillerAddressPart1 = "";
            string fillerAddressPart2 = "";

            var data = new OutputData();
            var dataList = new List<OutputData>();

            var lines = pageText.Split('\n').Where(x => !string.IsNullOrEmpty(x) && x != " ").ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                string trimmed = lines[i].TrimStart();                

                if (trimmed.Contains("DOCUMENTS PROCESSED"))
                {
                    var dateLineArr = trimmed.Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != " ").ToArray();
                    if (dateLineArr.Length > 0)                    
                        datetime = dateLineArr[dateLineArr.Length - 1].Trim();
                }
                else if (trimmed.StartsWith("---------------------"))
                {
                    int index = lines[i - 1].IndexOf(')');
                    if(index != -1)
                        typeOfAction = lines[i - 1].Substring(0, index + 1).Trim();
                    else
                        typeOfAction = lines[i - 1].Trim();
                }
                else if (trimmed.StartsWith("LAW"))
                {
                    int index = lines[i - 1].IndexOf(' ');
                    string companyName = lines[i - 1].Substring(index).Trim();
                    data.CompanyName = companyName;
                }
                else if (trimmed.StartsWith("COUNTY"))
                {
                    var line = lines[i].Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != " ").ToArray();
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (line[j] == ":")
                        {
                            data.County = line[j + 1];

                            string filerName = "";
                            for (int k = j + 2; k < line.Length; k++)
                            {
                                filerName += line[k] + " ";
                            }
                            data.FilerName = filerName.Trim();
                            break;
                        }
                    }
                }
                else if (trimmed.StartsWith("EFF."))
                {
                    var line = trimmed.Split(':')[1];
                    string[] words = line.Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != " ").ToArray();
                    for (int w = 1; w < words.Length; w++)
                    {                        
                        fillerAddressPart1 += words[w].Trim() + " ";
                    }                    
                }
                else if (trimmed.StartsWith("DUR."))
                {
                    fillerAddressPart2 = trimmed.Split(':')[1].Trim();
                    if (fillerAddressPart2.StartsWith("PERPETUAL"))
                        fillerAddressPart2 = fillerAddressPart2.Replace("PERPETUAL", "");
                    data.FilerAddress = fillerAddressPart1.Trim() + " " + fillerAddressPart2.Trim();

                    if (lines.Length > i + 2)
                    {                        
                        data.Address1 = lines[i + 1].Trim();

                        //there are a few exception here that would need to be dealt with
                        //i'd have to check with client what to do about those
                        //if (!typeOfAction.StartsWith("AMENDMENT") && !typeOfAction.StartsWith("CORRECTION"))
                        //{
                            var wordsAddress2 = lines[i + 2].Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != " ").ToArray();
                            var wordsAddress3 = lines[i + 3].Split(' ').Where(x => !string.IsNullOrEmpty(x) && x != " ").ToArray();
                            string address2 = "";
                            string address3 = "";
                            foreach (string w in wordsAddress2)
                                address2 += w + " ";
                            foreach (string w in wordsAddress3)
                                address3 += w + " ";

                            data.Address23 = address2.Trim() + ", " + address3.Trim();
                        //}
                    }

                    //finishing data here first OutputData here since we pare chronologically
                    data.TypeOfAction = typeOfAction;
                    if (DateTime.TryParse(datetime, out DateTime dt))
                        data.DayProcessed = dt;

                    fillerAddressPart1 = "";
                    fillerAddressPart2 = "";

                    dataList.Add(data);
                    data = new OutputData();
                }                
            }


            return dataList;
        }
    }
}
