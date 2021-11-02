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
                            foreach (var item in dataLine.Split(','))
                            {
                                dataList[i] = item;
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
