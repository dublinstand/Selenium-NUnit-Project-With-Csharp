using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount(3333);
            Console.WriteLine(acc.Amount);
        }
    }
}
