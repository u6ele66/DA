using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    class FileIO : IFileIO
    {
        private static readonly string[] _commentTokens = { "#" };
        private static readonly string[] _delimiters = { "," };
        private static readonly bool _hasFieldEnclosedInQuotes = true;
        private string dataLine;

        private static TextFieldParser GetFileforParse(string path)
        {
            TextFieldParser file = new TextFieldParser(path);

            file.CommentTokens = _commentTokens;
            file.SetDelimiters(_delimiters);
            file.HasFieldsEnclosedInQuotes = _hasFieldEnclosedInQuotes;

            return file;
        }

        private static int GetStringNumber(string path)
        {
            var file = GetFileforParse(path);

            int lineCount = 0;

            while(!file.EndOfData)
            {
                file.ReadLine();
                lineCount++;
            }

            return lineCount;
        }

        private static void RemoveAt(ref string[] arr, int index)
        {
            string[] newArr = new string[arr.Length - 1];
            
            for(int i = 0; i < index; i++)
            {
                newArr[i] = arr[i];
            }
            
            for(int i = index + 1; i < arr.Length; i++)
            {
                newArr[i - 1] = arr[i];
            }

            arr = newArr;
        } 

        public string[,] ReadFile(string path)
        {
            var parser = GetFileforParse(path);

            string[] header = parser.ReadFields();
            string[] dataList = new string[header.Length];

            int rows = GetStringNumber(path) - 1;
            int columns = header.Length;
            string[,] data = new string[rows, columns];

            while (!parser.EndOfData)
            {
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        while ((dataLine = parser.ReadLine()) != null)
                        {
                            dataList = new string[header.Length];
                            int i = 0;
                            string[] itemList = dataLine.Split(',');
                            for (int itemIndex = 0; itemIndex < itemList.Length; itemIndex++)
                            {
                                if(itemList[itemIndex].StartsWith("\""))
                                {
                                    string lineStart = itemList[itemIndex];
                                    string resultItem = "";
                                    string lineEnd = "";
                                    int iterCount = 0;
                                    while (!itemList[itemIndex].EndsWith("\""))
                                    {
                                        if (iterCount == 0)
                                        {
                                            resultItem = resultItem + itemList[itemIndex + 1];
                                            if (itemList[itemIndex + 1].EndsWith("\""))
                                            {
                                                RemoveAt(ref itemList, itemIndex + 1);
                                                break;
                                            }
                                            RemoveAt(ref itemList, itemIndex + 1);
                                        }
                                        else
                                        {
                                            resultItem = resultItem + "," + itemList[itemIndex];
                                            RemoveAt(ref itemList, itemIndex);
                                            if(itemList[itemIndex].EndsWith("\""))
                                            {
                                                resultItem = resultItem + "," + itemList[itemIndex];
                                                RemoveAt(ref itemList, itemIndex);
                                                break;
                                            }
                                            continue;
                                        }
                                        if (itemList[itemIndex].EndsWith("\""))
                                        {
                                            lineEnd = itemList[itemIndex];
                                        }
                                        itemIndex++;
                                        iterCount++;
                                    }
                                    if(iterCount == 0)
                                    {
                                        itemList[itemIndex] = lineStart + "," + resultItem + "," + lineEnd;
                                    }
                                    else
                                    {
                                        itemList[itemIndex - 1] = lineStart + "," + resultItem + "," + lineEnd;
                                    }
                                }
                            }
                            //foreach (var item in itemList)
                            //{
                            //    dataList[i] = item.Replace(".", ",");
                            //    i++;
                            //    if (dataList[dataList.Length - 1] != null)
                            //    {
                            //        break;
                            //    }
                            //}
                            foreach(var item in itemList)
                            {
                                dataList[i] = item.Replace("'", "''");
                                i++;
                                if (dataList[dataList.Length - 1] != null)
                                {
                                    break;
                                }
                            }

                            foreach (var el in dataList)
                            {
                                data[j, k] = el;
                                k++;
                            }
                            if (data[j, columns-1] != null)
                            {
                                break;
                            } 
                        }
                    }
                }
            }
            return data;
        }
    }
}
