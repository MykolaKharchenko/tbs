﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.UnitStack;

namespace Sandbox
{
    public class Singleton
    {
        public string Date { get; private set; }
        public static string text = "hello";
        private Singleton()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            return Nested.instance;
        }

        private class Nested
        {
            internal static readonly Singleton instance = new Singleton();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
            //Console.WriteLine(Singleton.text);



            var archy = new Archers();
            var wardy = new Swordmen();

            int i = 1;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===============Turn №" + i + "===========================");
                Console.WriteLine();

                Console.WriteLine("Archi : " + archy.stackSize + " units " + archy.totalHP + " HP");
                Console.WriteLine("sWardi: " + wardy.stackSize + " units " + wardy.totalHP + " HP");


                Console.WriteLine("------------------ archy ATTACK wardy ----------------");
                archy.GetDamage(wardy);
                Console.WriteLine("------------------ wardy ATTACK archy ----------------");
                wardy.GetDamage(archy);


                i++;

                if (archy.stackSize <= 0)
                {
                    Console.WriteLine("Game over.   Wardy is winner!!!");
                    break;
                }

                if (wardy.stackSize <= 0)
                {
                    Console.WriteLine("Game over.   Archy is winner!!!");
                    break;
                }
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}

