using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace GitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //inits 

            //the file is txt and is in debug folder
            //separated by comma and space
            //cultureinfo chosen en-US
            string fileName = "AddressBook.txt";
            string[] separators = new string[1];
            separators[0] = ", ";
            CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
            DateTime dt_init = new DateTime();


            string[] answers = new string[3];

            List<string> firstName = new List<string>();
            List<string> lastName = new List<string>();
            List<string> sex = new List<string>();
            List<DateTime> birthDate = new List<DateTime>();

            //read from file 
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {

                    string[] el = sr.ReadLine().Split(separators, StringSplitOptions.None); // StringSplitOptions.None will leave the indexes ok if some data is missing from the file
                    //el[1] = name
                    //el[2] = sex
                    //el[3] = date of birth?

                    string[] name = el[0].Split(' ');
                    string first = name[0]; firstName.Add(first);
                    string last = name[1]; lastName.Add(last);

                    sex.Add(el[1]);
                    if (el[2].Equals("")) //we have no date for this person
                    {
                        // problem for the Lists indexes - so we add a value that nobody can have
                        birthDate.Add(dt_init);
                    }
                    else birthDate.Add(DateTime.ParseExact(el[2], "dd/MM/yy", ci));

                }
                sr.Close();
            }


            //q1 - number of males
            int countMales = 0;
            for (int i = 0; i < sex.Count; i++)
            {
                if (sex[i].ToLower().Equals("male")) //case sensitive in file? - just to be sure - added toLower()
                {
                    countMales += 1;
                }
            }
            answers[0] = countMales.ToString();


            //q2 - oldest person
            DateTime lowestDate = DateTime.Now;
            string oldestPerson = "";
            for (int i = 0; i < birthDate.Count; i++)
            {
                if ((lowestDate > birthDate[i]) && (birthDate[i] != dt_init))
                {
                    lowestDate = birthDate[i];
                    oldestPerson = firstName[i] + " " + lastName[i]; //for now we assume the indexes are the same (so the file was in correct format)
                }
            }
            answers[1] = oldestPerson;


            //q3 - days older B > P
            int Bill_index = -1;
            int Paul_index = -1;
            for (int i = 0; i < firstName.Count; i++) //for now we assume the indexes are the same (so the file was in correct format)
            {
                if (firstName[i].ToLower().Equals("paul"))//case sensitive in file?
                {
                    Paul_index = i;
                }
                if (firstName[i].ToLower().Equals("bill"))//case sensitive in file?
                {
                    Bill_index = i;
                }
            }
            if ((Bill_index < 0) || (Paul_index < 0)) answers[2] = "Bill or Paul not found, so we cannot know who is older";
            else
            {
                TimeSpan dif = birthDate[Paul_index] - birthDate[Bill_index]; // If Bill is younger than Paul thre result is negative
                answers[2] = dif.TotalDays.ToString();
            }


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
