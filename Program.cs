using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1_SP21
{
    class Program
    {
        private static void PrintTriangle(int m)
        {
            try
            {
                // defining variable for looping
                int i, j, k;

                // outer loop for line by line
                for (i = 1; i <= m; i++)
                {
                    // inner loop for empty spaces
                    for (j = 1; j < m - i + 1; j++)
                    {
                        Console.Write(" ");
                    }

                    // inner loop for special character
                    for (k = 1; k <= i; k++)
                    {
                        Console.Write("*");
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        private static void PrintPellSeries(int m2)
        {
            try
            {
                // defining local loop variable and printing the first two values in the series
                int tmp = m2 - 2;
                Console.WriteLine("0\n1 ");

                int pre1 = 1;
                int pre2 = 0;

                // pell logic loop
                while (tmp > 0)
                {
                    int x = pre1 * 2 + pre2;

                    // print output and reassign variables
                    Console.WriteLine(x + " ");
                    tmp -= 1;
                    pre2 = pre1;
                    pre1 = x;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool SquareSums(int m3)
        {
            try
            {
                // nested loop for finding square sum
                for (long a = 0; a * a <= m3; a++)
                {
                    for (long b = 0; b * b <= m3; b++)
                    {
                        if (a * a + b * b == m3)

                            // return the boolean value
                            return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        private static int DiffPairs(int[] no, int s)
        {
            try
            {
                int n = no.Length;

                // hashset to store each pair
                HashSet<KeyValuePair<int, int>> setPair = new HashSet<KeyValuePair<int, int>>();

                // select elements one by one
                for (int i = 0; i < n; i++)
                {
                    // check for a pair of the picked element
                    for (int j = i + 1; j < n; j++)
                    {
                        if (no[i] - no[j] == s || no[j] - no[i] == s)
                        {
                            // pair added to the set. Duplicates won't be added
                            setPair.Add(new KeyValuePair<int, int>(no[i], no[j]));
                        }
                    }
                }
                // loop to print unique pairs
                foreach (var pair in setPair)
                {
                    Console.WriteLine(pair);
                }

                // returning total pairs count in set
                return setPair.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }

        private static int UniqueEmails(string[] email)
        {
            try
            {
                // initialize count value
                int count = 0;
                // iterate over array elements
                for (int i = 0; i < email.Length; i++)
                {
                    // get the given names
                    string[] names = email[i].Split('@');
                    //get the local names for processing
                    string localName = names[0];

                    // parse local name
                    for (int j = 0; j < localName.Length; j++)
                    {
                        // replace the '.' character with empty character
                        if (localName[j] == '.')
                        {
                            localName = localName.Replace(@".", string.Empty);
                            // decrement the j position to avoid out of bounds exception
                            j--;
                        }

                        // trim the string after '+' symbol
                        if (localName[j] == '+')
                        {
                            localName = localName.Substring(0, localName.IndexOf("+") + 0);
                        }
                    }

                    // get count of unique mails
                    email[i] = localName + "@" + names[1];

                }

                // get distinct eamils
                count = email.Distinct().Count();

                // return the count
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private static string DestCity(List<List<string>> path)
        {
            try
            {
                var baseCities = new HashSet<string>();

                // building cities set that lead somewhere else
                foreach (var r in path)
                {
                    baseCities.Add(r[0]);
                }

                // find a path that doesn't appear in the list of cities that go somewhere
                foreach (var r in path)
                {
                    if (!baseCities.Contains(r[1]))
                        return r[1];
                }
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());

            PrintTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());

            PrintPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 Example 1: Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());

            bool retVal = SquareSums(n3);
            if (retVal)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of " + retVal + "squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }
            Console.WriteLine();

            //Question 4:
            //Example 1:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4 Example 1: Enter the absolute difference to check");
            int k1 = Convert.ToInt32(Console.ReadLine());

            int n4Ex1 = DiffPairs(arr1, k1);
            Console.WriteLine("There exists {0} pairs with the given difference", n4Ex1);

            //Example 2:
            int[] arr2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("\nQ4 Example 2: Enter the absolute difference to check");
            int k2 = Convert.ToInt32(Console.ReadLine());

            int n4Ex2 = DiffPairs(arr2, k2);
            Console.WriteLine("There exists {0} pairs with the given difference", n4Ex2);

            //Example 3:
            int[] arr3 = { 1, 3, 1, 5, 4 };
            Console.WriteLine("\nQ4 Example 3: Enter the absolute difference to check");
            int k3 = Convert.ToInt32(Console.ReadLine());

            int n4Ex3 = DiffPairs(arr3, k3);
            Console.WriteLine("There exists {0} pairs with the given difference", n4Ex3);

            //Question 5:
            List<string> mails = new List<string>();
            mails.Add("dis.email+bull@usf.com");
            mails.Add("dis.e.mail+bob.cathy@usf.com");
            mails.Add("disemail+david@us.f.com");
            string[] emails = mails.ToArray();

            int ans5 = UniqueEmails(emails);
            Console.WriteLine("\nQ5");
            Console.WriteLine("The number of unique emails is: " + ans5);

            //Quesiton 6:
            //Example 1:
            List<List<string>> paths1 = new List<List<string>>();
            List<string> a1 = new List<string> { "London", "New York" };
            List<string> b1 = new List<string> { "New York", "Tampa" };
            List<string> c1 = new List<string> { "Delhi", "London" };
            paths1.Add(a1);
            paths1.Add(b1);
            paths1.Add(c1);

            string destination1 = DestCity(paths1);
            Console.WriteLine("\nQ6 Example 1");
            Console.WriteLine("Destination city is: " + destination1);

            //Example 2:
            List<List<string>> paths2 = new List<List<string>>();
            List<string> a2 = new List<string> { "B", "C" };
            List<string> b2 = new List<string> { "D", "B" };
            List<string> c2 = new List<string> { "C", "A" };
            paths2.Add(a2);
            paths2.Add(b2);
            paths2.Add(c2);

            string destination2 = DestCity(paths2);
            Console.WriteLine("\nQ6 Example 2");
            Console.WriteLine("Destination city is: " + destination2);

        }
    }
}
