using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace lw1
{
    class Program
    {
        static void Main(string[] args)
        {
            //проверка на корректное кол-во аргументов программы
            IArgumentParser argsValidation = new ArgumentParser();
            argsValidation.CheckNumberOfArgs(args);

            for(int i = 0; i < args.Length; i++) //цикл для обхода всех директорий с файлами
            {
                string[] fileArr = Directory.GetFiles($@"{args[i]}", "*.csv"); //инициализация массива файлов в определенной дериктории

                IFileIO file = new FileIO();

                var dataArr = file.ReadFile(fileArr[0]);

                int height = dataArr.GetLength(0);
                int width = dataArr.GetLength(1);


                //проверка корректности данных в двумерном массиве 
                for(int y = 0; y < height; y++)
                {
                    for(int x = 0; x < width; x++)
                    {
                        Console.Write(dataArr[y, x] + "|");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
