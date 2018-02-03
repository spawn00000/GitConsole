using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //inits 
           
            //the file is txt and is in debug folder
            //separated by comma and space
            string fileName = "AddressBook.txt";
            string[] separators = new string[1];
            separators[0] = ", ";

            List<string> firstName = new List<string>();


            //read from file 
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {                    

                    string[] el = sr.ReadLine().Split(separators,StringSplitOptions.None);
                    //el[1] = name
                    //el[2] = sex
                    //el[3] = date of birth?

                    string[] name = el[0].Split(' ');
                    string first = name[0]; firstName.Add(first);
                    string last = name[1];

                }
                sr.Close();
            }


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
