﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    interface IFileIO
    {
        public string[,] ReadFile(string path);
    }
}
