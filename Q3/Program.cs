﻿/*
* Name: Garry Ledwith
* Date: 23/09/24
* Description: Lab 2 
 Q3 and Q4

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

-----------------------------------------
Q4
4.	Methods.  Create a method which accepts an array of grades (assume higher level only) and calculates the points
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // file path
            string filePath = "../../../../grades.txt";


            try // try catch block for handling exceptions 
            {
                if (!File.Exists(filePath)) // raises an exception if file does not exist 
                {
                    throw new FileNotFoundException($"The file {filePath} could not be found");
                }

                // read all contents from file and add them to an array 
                string[] studentGrades = File.ReadAllLines(filePath);

                // calcualte total points 
                int totalPoints = CalculateTotalPoints(studentGrades);

                // display results 
                Console.WriteLine($"Your total points: {totalPoints}");

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        } // end of main 

        // Methods 
        /// <summary>
        /// Calculate total points method 
        /// method taakes one argument (parameter), an input string array 
        /// validates user input using the TryParse method and will output an error message 
        /// if any element is not valid 
        /// calculates running total of points bases on the logic in the if statement
        /// </summary>
        /// <param name="grades"></param>
        /// <returns>an integer (total accumulated points)</returns>
        static int CalculateTotalPoints(string[] grades)
        {

            // Arrays to store data 
            int[] boundaries = { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherLevelGrades = { 100, 88, 77, 66, 56, 46, 37, 0 };

            // declare variables 
            int totalPoints = 0;
            int point;

            for (int i = 0; i < grades.Length; i++) // loop through grades array 
            {
               if (int.TryParse(grades[i], out point)) // validate input and convert valid input to an int, else display an error message 
                {
                    // loop through boundaries array 
                    for (int j = 0; j < boundaries.Length; j++)
                    {
                        if (point >= boundaries[j])
                        {
                            point = higherLevelGrades[j];
                            totalPoints += point;
                            break; // break out of loop after block is executed 
                        }
                    }
                }
               else
                {
                    // display error message 
                    Console.WriteLine($"Oops, {grades[i]} is not a valid input");
                }  
            }
            return totalPoints;
        }
    }
}
