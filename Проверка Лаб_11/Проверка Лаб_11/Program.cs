using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаб_11;

namespace Проверка_Лаб_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Arr A = new Arr(5);
            Arr B = new Arr(10);
            A.RndInput(50);
            B.RndInput(-30, 30);

            A.Print();
            B.Print();
            Arr S = A + B;
            Arr R = A - B;
            S.Print();
            R.Print();
        }
    }
}
