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
            //подключение к бд
            ISqlConn db = new SqlConn();
            db.openConnection();

            IDBTable table = new DBTable();

            for (int i = 0; i < args.Length; i++)
            {
                table.CreateTable(args[i]);
                //проверка на корректное кол-во аргументов программы
                IArgumentParser argsValidation = new ArgumentParser();
                argsValidation.CheckNumberOfArgs(args);

                string[] fileArr = Directory.GetFiles($@"{args[i]}", "*.csv"); //инициализация массива файлов в определенной дериктории
            
                IDataDB data = new DataDB();

                foreach (var file in fileArr)
                {
                    data.InsertDataInTable(file, args[i]);
                }
            }
        }
    }
}
