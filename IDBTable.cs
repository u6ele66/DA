using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    interface IDBTable
    {
        public void CreateTable(string path);
        public void DeleteTable(string tableName);
    }
}
