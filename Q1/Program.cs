/*
* Name: Garry Ledwith
* Date: 23/09/24
* Description: Lab 2 
Q1 and Q2
Read a text file which contains 7 grades. Calculate the total points
and append this total to the original file.  
Don’t worry about Higher or Ordinary level here but use the points for Higher.

make use of a foreach loop in the previous exercise
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // file path
            string filePath = "../../../grades.txt";

            try // try catch block for handling exceptions 
            {
                if (!File.Exists(filePath)) // raises an exception if file does not exist 
                {
                    throw new FileNotFoundException($"The file {filePath} could not be found");
                }

                // calculate total pooints  
                int total = CalculateTotalPoints(filePath);

                // display contents of file 
                DisplayFile(filePath);

                // append to a file 
                AppendtotalToFile(filePath, total);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Methods 
        // calculate total points 
        static int CalculateTotalPoints(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath)) // instantitae a new StreamReader object 
            {
                string lineIn = "";
                int runningTotal = 0;

                while ((lineIn = sr.ReadLine()) != null)
                {
                    string[] fields = lineIn.Split(','); // split each element with a ',' 

                    foreach (string field in fields) // foreach loop (Question 2) 
                    {
                       
                        runningTotal += Convert.ToInt32(field); // convert input into an int and add it to runningTotal 
                    }
                }
                return runningTotal;
            }
        }

        // append total to file 
        static void AppendtotalToFile(string filePath, int total)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(total);

            }
        }
        // Display store performance report 

        static void DisplayFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath)) // instantitae a new StreamReader object 
            {
                string lineIn = "";


                while ((lineIn = sr.ReadLine()) != null)
                {
                    string[] fields = lineIn.Split(',');

                    for (int i = 0; i < fields.Length; i++)
                    {
                        Console.WriteLine(fields[i]);
                    }
                }

            }
        }


    }
}