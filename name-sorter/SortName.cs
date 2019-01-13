using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/***
 * This code is written to set of sort names by the last name.
 * The full names can have upto 3 names, and the least of 1 name.
 * Names are read using a file called "unsorted-names-list.txt"
 * 
 * And the soreted names written back to a file named "sorted-names-list.txt" 
*/

namespace name_sorter
{
    /***
     * Abstract class for the FullName with three variables naming 
     * First Name, Second Name and the Third Name
     ***/
    public class FullName
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class SortName
    {
        /***
         * Creating a list of names of the type FullName
         * @param names in the full name 
         * @return list of names of type FullName  
         */
        public static List<FullName> GetListofFullNames(String[] names)
        {
            // Create a List of type FullName called NameList
            List<FullName> NameList = new List<FullName>();

            // Split the names according to the number of word in the full name 
            foreach (string name in names)
            {
                // Create an object of a FullName type
                FullName nameobject = new FullName();

                // Get the number of words in the full name
                int NumberOfWordsInTheFullName = name.Split(' ').ToList().Count;

                switch (NumberOfWordsInTheFullName)
                {
                    case 1:
                        nameobject.LastName = name.Split(' ').First();
                        break;
                    case 2:
                        nameobject.FirstName = name.Split(' ').First();
                        nameobject.LastName = name.Split(' ').Last();
                        break;
                    case 3:
                        nameobject.FirstName = name.Split(' ')[0];
                        nameobject.MiddleName = name.Split(' ')[1];
                        nameobject.LastName = name.Split(' ')[2];
                        break;
                }

                // Add the nameobjects to a list
                NameList.Add(nameobject);
            }

            // return the created list
            return NameList;

        }

        /***
         * Get the names List and Writes the sorted names to a file 
        */
        public static void WriteToFile(String[] names)
        {
            // Get the created the full name list
            List<FullName> nameList = GetListofFullNames(names);

            // Sort the nameList according to the LastName
            IEnumerable<FullName> query = nameList.OrderBy(fullname => fullname.LastName);

            using (StreamWriter file = new StreamWriter(@"sorted-names-list.txt"))
            {
                foreach (FullName fullName in query)
                {
                    string Firstname = fullName.FirstName;
                    string Lastname = fullName.LastName;
                    string Middlename = fullName.MiddleName;
                    string fullsortedname = Firstname + " " + Middlename + " " + Lastname;
                    // If the full name doesnt consist of a MiddleName write only the 
                    // FirstName and the LastName
                    // And write it to the Console
                    if (Middlename == null)
                    {
                        fullsortedname = Firstname + " " + Lastname;
                        file.WriteLine(fullsortedname);
                        Console.WriteLine(fullsortedname);
                    }
                    // else write the full name with the MiddleName
                    // and trim the extra white spaces.
                    // Write the name in to the Cnsole
                    else
                    {
                        string TrimedFullname = fullsortedname.Trim();
                        file.WriteLine(TrimedFullname);
                        Console.WriteLine(TrimedFullname);
                    }

                }
            }
        }

        static void Main(string[] args)
        {

            // If the file "sorted-names-list.txt" exists delete
            if (File.Exists(@"sorted-names-list.txt"))
            {
                File.Delete(@"sorted-name-list.txt");
            }

            // Read the File
            string[] names = File.ReadAllLines(@"unsorted-names-list.txt");

            // Write to files 
            WriteToFile(names);
                   
            }
        }
    }