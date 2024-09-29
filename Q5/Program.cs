/*
 * Name: Garry Ledwith
 * Date: 27/09/24
 * Description:
 * Lab 2, Q5
 5.	Write a program which takes user input and asks for Name, Student Number, Subjects, Level and Grade 
and displays a tabulated report to screen and writes this to file
with all the all the inputs and the points total.  
Assume 7 subjects. 
 
----------------------------------
# UNDERSTAND THE PROBLEM:
   
    - Input: 
      Name, Student Number, Subjects, Level and Grade from user 

    - Output: 
      displays a tabulated report to screen 

    Rules / Requirements: 
    - Explicit requirements
      take user input and ask for Name, Student Number, Subjects, Level and Grade
      7 subjects 
      display tabulated report 
      wirte tabulated report to a file 
    

    - Implicit requirements
     create a loop that iterates 7 times 
     store higher and orginary level grades for calculations 
 
    Clarifying Questions: 

     - how will I store subjects? 
        - an array and I will use the index positions to indicate 
          which number the the subject is as the user enters the subject names

     - how will I handle subject level and where will I stoe this info? 
       - h for higher 
       - o for ordinary 
       - array 

    - how will I ask for grade and where will I store results? 
     - number between 0 and 100 
     - array

   - do I need a boundries array for calculations?
      - yes 

     - how do I create a tabulated report? 
       - use string formatting 

     - should I create a new file for this question?
       - yes because it will overwrite the existing data in a file 
     - how can I write to a file?
        - StreamWriter 

# CODE: 
*/
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Q5
{
    internal class Program
    {
        // Declare a constant for max number of subjects 
        const int MaxSubjects = 2;
        static void Main(string[] args)
        {

            // declare variables 
            string studentName, studentNumber, subject, level, grade;

            // arrays for storing user data 
            string[] subjects = new string[MaxSubjects];
            string[] subjectLevels = new string[MaxSubjects];
            string[] grades = new string[MaxSubjects];


            // get user input 
            Console.Write(">> Enter your name : ");
            studentName = Console.ReadLine();
            Console.Write(">> Enter your student number : ");
            studentNumber = Console.ReadLine();

            // main loop 
            for(int i = 0; i < MaxSubjects; i++) // iterates 7 times 
            {
                // get more user input 
                Console.Write($">> Enter subject number {i+ 1} : ");
                subject = Console.ReadLine() ;
                // assign the element at the currrent index position of the subjects array to the users input
                // using element assignment 
                subjects[i] = subject;

                Console.Write($">> Enter subject level (h for higher, o for ordinary : ");
                level = Console.ReadLine();
                subjectLevels[i] = level;

                Console.Write($">> Enter your grade (between 0 and 100 : ");
                grade = Console.ReadLine();
                grades[i] = grade;
            }
            
            // display tabular report 
            DisplayResults(studentName, studentNumber, subjects, subjectLevels, grades);

            // write data to a file 
            WriteStudentReportToFile(studentName, studentNumber, subjects, subjectLevels, grades);

        } // end of main method 
        // Methods 
        // calculate total grade points 
       
        static int CalculateTotalPoints(string[] grades, string[] levels)
        {
            // Arrays to store existing data 
            int[] boundaries = { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherLevelPoints = { 100, 88, 77, 66, 56, 46, 37, 0 };
            int[] ordinaryLevelPoints = {56, 46, 37, 28, 20, 12, 0, 0 };

            // declare variables 
            int totalPoints = 0;
            int points = 0;

            for (int i = 0; i < grades.Length; i++) // loop through grades array 
            {
                int.TryParse(grades[i], out points); // validate input and convert valid input to an int
                
                    // loop through boundaries array 
                    for (int j = 0; j < boundaries.Length; j++)
                    {
                        if (points >= boundaries[j]) 
                        {
                            if (levels[i].ToLower().Equals("h")) // (nested if statement) if the current element is equal to 'h' then points are higher level, else ordinary level  
                            {
                                points = higherLevelPoints[j];
                                totalPoints += points;
                                break; // break out of loop after block is executed 
                            }
                            else // ordinary level 
                            {
                                points = ordinaryLevelPoints[j];
                                totalPoints += points;
                                break;
                            }
                        }
                    }
            }
            return totalPoints;
        }

        // write to a file method 
        static void WriteStudentReportToFile(string name, string num, string[] subjects, string[] levels, string[] grades)
        {
            int totalPoints = CalculateTotalPoints(grades, levels);

            FileStream fs = new FileStream("studentResults.txt", FileMode.Create, FileAccess.Write); // create a new txt file called results and use wirte access
            
            // create a streamwriter object and pass in path 
            StreamWriter writer = new StreamWriter(fs);

            // write data to file 
            writer.WriteLine($"Student name: {name}");
            writer.WriteLine($"Student ID: {num}");
            writer.WriteLine($"{"Subjects",-10}{"Level",-10}{"Points",-10}");

            for (int i = 0; i < MaxSubjects; i++) 
            {
                writer.WriteLine($"{subjects[i], -10} {levels[i], -10}  {grades[i],-10}"); // write data to file 
            }

            writer.WriteLine($"\nTotal Points: {totalPoints}"); // write total point 

            writer.Close(); // close the stream

            // display success message 
            Console.WriteLine("\nData has been successfully written to the file ");
        }


        //display report method 
        static void DisplayResults(string name, string num, string[] subjects, string[] levels, string[] grades)
        {
            // calculate total grade points 
            int totalPoints = CalculateTotalPoints(grades, levels);

            // display resuls to console 
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Student Id: {num}");
            Console.WriteLine($"{"Subjects",-10}{"Level",-10}{"Points",-10}");

            for (int i = 0; i < MaxSubjects ; i++) 
            {
                Console.WriteLine($"{subjects[i], -10} {levels[i], -10}  {grades[i],-10}");
            }
            
            // display total points 
            Console.WriteLine($"\nTotal Points: {totalPoints}");
        }      
    }
}