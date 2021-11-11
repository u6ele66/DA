using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Data.SqlClient;

namespace lw1
{
    class Program
    {
        static void Main(string[] args)
        {
            //проверка подключения к бд
            ISqlConn db = new SqlConn();
            db.openConnection();
            if((db.getConnection()).State == System.Data.ConnectionState.Closed)
            {
                Console.WriteLine("ошибка, нет подключения к бд");
            }
            else
            {
                Console.WriteLine("все норм");
            }

            IDBTable table = new DBTable();

            table.CreateTable();

            //проверка на корректное кол-во аргументов программы
            IArgumentParser argsValidation = new ArgumentParser();
            argsValidation.CheckNumberOfArgs(args);

            string[] fileArr = Directory.GetFiles($@"{args[0]}", "*.csv"); //инициализация массива файлов в определенной дериктории

            IDataDB data = new DataDB();

            data.InsertDataInTable(fileArr[0]);

            IFileIO file = new FileIO();

            var dataArr = file.ReadFile(fileArr[0]);

            //int height = dataArr.GetLength(0);
            //int width = dataArr.GetLength(1);


            ////проверка корректности данных в двумерном массиве 
            //for (int y = 0; y < height; y++)
            //{
            //    for (int x = 0; x < width; x++)
            //    {
            //        Console.Write(dataArr[y, x] + "|");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
