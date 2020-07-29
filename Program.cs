using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;        //basic io.
using System.Threading; //required for threading.

namespace ProxyDupeRemover
{
    class Program
    {
        /* ProxyDupeRemover v0.1 -- added delegated threading to the functions. */
        static void Main(string[] args)
        {
            string myPath = System.IO.Directory.GetCurrentDirectory(); //gets our current directory

            string[] emp_names = File.ReadAllLines(myPath + "/proxies.txt"); //reads proxies.txt to process for duplicate entries.
                List<string> newemp1 = new List<string>();

            new Thread(delegate ()
            {
                for (int i = 0; i < emp_names.Length; i++)
                {
                    newemp1.Add(emp_names[i]);  //passing data to newemp1 from emp_names

                }
            }).Start();
 
            new Thread(delegate ()
            {
                for (int i = 0; i < emp_names.Length; i++)
                {
                    List<string> temp = new List<string>();
                    int duplicate_count = 0;

                    for (int j = newemp1.Count - 1; j >= 0; j--)
                    {
                        
                        if (emp_names[i] != newemp1[j])  //checking for duplicate records
                            temp.Add(newemp1[j]);
                        else
                        {
                            duplicate_count++;
                            if (duplicate_count == 1)
                                temp.Add(emp_names[i]);
                            
                        }
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);   // - Move cursor
                    Console.Write($"Processing dupe lists... please wait - {emp_names.Length} out of {i}");
                    newemp1 = temp;
                }
                Console.SetCursorPosition(0, Console.CursorTop);   // - Move cursor
                Console.Clear();


                string[] newemp = newemp1.ToArray();  //assigning into a string array
                Array.Sort(newemp);
                File.WriteAllLines(myPath + "/proxies-fixed.txt", newemp); //now writing the data to a text file
                Console.SetCursorPosition(0, Console.CursorTop);   // - Move cursor

                Console.Write("Finished and saved as proxies-fixed.txt");
                Console.ReadLine();
            }).Start();
        }
    }
}