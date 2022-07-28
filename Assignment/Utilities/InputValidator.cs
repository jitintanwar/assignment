using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Utilities
{
    public class InputValidator
    {
        public bool Validate(string arg1, string arg2)
        {
            if (string.IsNullOrEmpty(arg1) || string.IsNullOrEmpty(arg2)) 
                return false;
            
            return true;
        }
    }
}
