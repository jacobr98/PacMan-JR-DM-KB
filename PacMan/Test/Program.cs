﻿using PacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState g = GameState.Parse("../../levelsPen.csv");

            Console.WriteLine(g);
        }
    }
}
