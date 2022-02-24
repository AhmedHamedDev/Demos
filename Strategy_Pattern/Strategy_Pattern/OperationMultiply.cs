using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    internal class OperationMultiply : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
           return num1 * num2;
        }
    }
}
