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

                // hashset to store unique pair
                HashSet<KeyValuePair<int, int>> setPair = new HashSet<KeyValuePair<int, int>>();

                // Pick all elements one by one
                for (int i = 0; i < n; i++)
                {
                    // check if there is a pair of this picked element
                    for (int j = i + 1; j < n; j++)
                    {
                        if (no[i] - no[j] == s || no[j] - no[i] == s)
                        {
                            // adding pair to set. Duplicate pair will not be added
                            setPair.Add(new KeyValuePair<int, int>(no[i], no[j]));
                        }
                    }
                }
                // loop to print unique pairs
                foreach (var pair in setPair)
                {
                    Console.WriteLine(pair);
                }

                // returning the count of total pairs in set
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
                // iterate array elements
                for (int i = 0; i < email.Length; i++)
                {
                    // get names
                    string[] names = email[i].Split('@');
                    //get local name for processing
                    string localName = names[0];

                    // parse the local name
                    for (int j = 0; j < localName.Length; j++)
                    {
                        // replace the . character with emplty character
                        if (localName[j] == '.')
                        {
                            localName = localName.Replace(@".", string.Empty);
                            // decrement the j position to avoid out of bounds exception
                            j--;
                        }

                        //trim the string after + symbol
                        if (localName[j] == '+')
                        {
                            localName = localName.Substring(0, localName.IndexOf("+") + 0);
                        }
                    }

                    // get unique mails count
                    email[i] = localName + "@" + names[1];

                }

                // get the distinct eamils
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

                //Build set of cities that lead somewhere else
                foreach (var r in path)
                {
                    baseCities.Add(r[0]);
                }

                //Find a path that doesn't appear in the list of cities that go somewhere
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
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
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
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());

            int n4 = DiffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

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
            List<List<string>> paths = new List<List<string>>();
            List<string> a = new List<string> { "B", "C" };
            List<string> b = new List<string> { "D", "B" };
            List<string> c = new List<string> { "C", "A" };
            paths.Add(a);
            paths.Add(b);
            paths.Add(c);

            string destination = DestCity(paths);
            Console.WriteLine("\nQ6");
            Console.WriteLine("Destination city is: " + destination);

        }
    }
}
