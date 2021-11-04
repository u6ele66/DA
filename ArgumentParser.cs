using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw1
{
    class ArgumentParser : IArgumentParser
    {
        private static int _argsCount = 2;
        static bool _argsNumberIsValid = true;

        public bool CheckNumberOfArgs(string[] args)
        {
            if(args.Length != _argsCount)
            {
                _argsNumberIsValid = false;
                throw new ArgumentException($"Arguments number should be {_argsCount}");
            }

            return _argsNumberIsValid;
        }
    }
}
