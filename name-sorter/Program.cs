using System;

/*
 * NameSorter.
 * Provide a text file containing a list of full names (given names, last name - space delimetered), each full name being new-line delimetered.
 * Overwrited provided text file with all names sorted.
 * Sorting precedience for a full name: Last name, first given name, second given name, third given name.
 * A full name must contain a last name, at least 1 given name, and at most 3 given names.
 * 
 */

namespace NameSorterNS {

    public class NameSorter {

        static void Main(string[] args) {

            if (args.Length <= 0) {
                Console.WriteLine("Missing input arguments: filepath to names.");
                return;
            }

            string inputFilepath = args[0];
            string outputFilepath = inputFilepath;

            var names = ReadNames(inputFilepath);

            if (!ValidateNames(names)) {
                Console.WriteLine("Error: One or more names is of invalid format.");
                return;
            }

            var nameSorter = new NameSorter();
            var sortedNames = nameSorter.SortNames(names);

            // Log the sorted names
            foreach (string name in sortedNames) {
                Console.WriteLine(name);
            }

            WriteNames(outputFilepath, sortedNames);

        }


        private static string[] ReadNames(string filepath) {
            // Reads unsorted names from file
            
            string[] lines = System.IO.File.ReadAllLines(filepath);

            return lines;

        }


        private static void WriteNames(string filepath, string[] filenames) {
            // Writes sorted named to file

            System.IO.File.WriteAllLines(filepath, filenames);

        }


        static bool ValidateNames(string[] names) {
            // Verify that all names in a list of names are valid

            if (names == null) {
                return false;
            }
            foreach (string name in names) {
                string[] splitNames = name.Split(' ');
                if (splitNames.Length < 2 || splitNames.Length > 4) {
                    return false;
                }
            }

            return true;

        }


        public string ConcatName(string name) {
            /* 
             * Formats a full name into a string such that their
             * full name appears concatenated in order of precedience; highest to lowest.
             * This allows for to name strings to be compared using inequalities.
             */

            if (name == null || name == "") {
                return "";
            }

            string[] nameList = (name.ToLower()).Split(' ');

            string newName = nameList[nameList.Length - 1] + String.Join(null, nameList.Take(nameList.Length - 1));

            return newName;

        }


        public string[] SortNames(string[] nameList) {
            // Sort names using selection sort.

            string[] names = nameList;

            for (int i = 0; i < names.Length; i++) {

                int minIndex = i;
                String minName = ConcatName(names[i]);

                for (int j = i + 1; j < names.Length; j++) {

                    var nameB = ConcatName(names[j]);

                    if (String.Compare(nameB, minName) < 0) {
                        minIndex = j;
                        minName = nameB;
                    }

                }

                if (minIndex == i) {
                    continue;
                }

                // Perform swap
                (names[i], names[minIndex]) = (names[minIndex], names[i]);

            }

            return names;

        }


    }

}


