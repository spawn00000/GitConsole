using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] answers = new string[3];

            //print results
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + answers[i]);
            }


            //keep console open.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
