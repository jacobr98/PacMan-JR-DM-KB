using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = File.ReadAllLines("../../levelsPen.csv");

            Console.WriteLine(str.Length);

            foreach (string s in str)
            {
                Console.WriteLine(s);
            }


        }
    }
}
