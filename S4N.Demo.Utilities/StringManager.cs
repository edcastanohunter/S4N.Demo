using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4N.Demo.Utilities
{
    public class StringManager
    {
        private static StringManager _instance;

        public static StringManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StringManager();
                return _instance;
            }
        }

        public int ExtraerNumero(string str)
        {
            int length = str.Length;
            string empty = string.Empty;
            int num = 0;
            for (int index = 0; index < length; ++index)
            {
                if (char.IsDigit(str[index]))
                    empty += str[index].ToString();
            }
            if (empty.Length > 0)
                num = int.Parse(empty);
            return num;
        }
    }
}
