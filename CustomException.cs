using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasword_Manager
{
    class CustomException : Exception
    {
       
        public string exceptionText;

        public CustomException(string text)
        {
            exceptionText = text;
        }
    }
}
