/*
* Name: Garry Ledwith
* Date: 23/09/24
* Description: Lab 2 
 Q3 

Create two arrays which hold the grade boundaries and higher level point. 
The grade boundaries are the marks that are on the boundary between two grades
such as 90, 80, 70 etc. 
Amend the program so that it makes use of the arrays in calculating points. 
This program should read 
from a file but should output total points to the screen and not amend the file.

----------------------------------
# UNDERSTAND THE PROBLEM:
- Input:

- Output:

Rules / Requirements:
- Explicit requirements
  - Create two arrays which hold the grade boundaries and higher level point. 
  - Array 1: grade boundries 
  - Array 2: higher level points 
  - This program should read from a file 
  - use the arrays in calculating points. 
  - output total points to the screen 
  - DO NOT amend not the file.


- Implicit requirements
 - create a txt file 
 - use try catch block to handle errors 
 - 

Clarifying Questions:
what are grade boundaries? 
  - The grade boundaries are the marks that are on the boundary between two grades
such as 90, 80, 70 etc. 

  // file path 
    ..\..\..\grades.txt

    
 // Methods 
Calculate Totals method 
- read results from file 
- store results in a varible 
- loop through grade boundries array 
  - if result is greater than 90 then return the index of that element in the array and use the index to#
find and return the element at the same index in higherGraders array 
    and add it to a running total 
    else if result is less than 90 and greater than 80 follow the same logic as above 
   - continue until file is completed 

boundaries array 

// Display results method 
output results running total from calculate totals method above 

*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
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

                // read all contents from file and add them to an array 
                string[] studentGrades = File.ReadAllLines(filePath); 

                // looping through studentGrades for testing 
                foreach (string studentGrade in studentGrades)
                {
                    Console.WriteLine(studentGrade);
                }

                // calculate total points 
                CalculateTotalPoints(studentGrades);


            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        } // end of main 

        // Methods 
        // calculate total points 
        static int CalculateTotalPoints(string[] grades)
        {
            // Arrays to store data 
            int[] boundaries = { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherLevelGrades = { 100, 88, 77, 66, 56, 46, 37, 0 };

            // declare variables 
            int totalPoints = 0;
            int point = 0;

            for (int i = 0; i < grades.Length; i++) // loop through grades array 
            {
                point = Convert.ToInt32(grades[i]); // convert point into an int 

                // loop through boundaries array 
                for (int j = 0; j < boundaries.Length; i++)
                {
                    if (point >= boundaries[j])
                    {
                        point = higherLevelGrades[j];
                    }
                }
                        

            }

            Console.WriteLine($"total points: {totalPoints}");
            return totalPoints;
        }
        

        

    }
}
