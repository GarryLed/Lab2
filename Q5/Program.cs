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
     - should I validate input? 
      - yes 
      - strings: 
        - non empty 

     - Student number must be valid, eg S1234 is valid (shortened for ease of use) 
          - must begin with an s followed by 4 digits 

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

     - should I create a new file for this question?
       - yes because it will overwrite the existing data in a file 
     - how can I write to a file?
        - StreamWriter 

# METHODS: 
store 
   
# CODE: 
*/using System.Globalization;
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
            for(int i = 0; i < MaxSubjects; i++) 
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
            

            WriteStudentReportToFile(studentName, studentNumber, subjects, subjectLevels, grades);

            // display tabular report 
            DisplayResults(studentName, studentNumber, subjects, subjectLevels, grades);



        } // end of main method 
        // Methods 
        // calculate total grade points 
        static int CalculateGrade(string[] grades)
        {
            int total = 0;
            // loop throgh grades array 
            // convert each element to an int and add to total 
            for (int i = 0; i < grades.Length; i++)
            {
                if (int.TryParse(grades[i], out int gradePoint)) // input validation 
                {
                    total += gradePoint; // accumulate total points 
                }
                else 
                { 
                    Console.WriteLine($"{gradePoint} is not a valid input");  // display error message (do I need this here? or was input validation done in the main loop? 
                }
            }
            return total;
        }

        // write to a file method 
        static void WriteStudentReportToFile(string name, string num, string[] subjects, string[] levels, string[] grades)
        {
            FileStream fs = new FileStream("studentResults.txt", FileMode.Create, FileAccess.Write); // create a new txt file called results and use wirte access
            
            // create a streamwriter object and pass in path 
            StreamWriter writer = new StreamWriter(fs);

            //string[] tests = { "Test" }; // contents to be written to txt file 
            /*
            foreach (string test in tests) // loop through array and write to file 
            {
                writer.WriteLine(test);
            }*/
            // write data to file 
            writer.WriteLine($"Student name: {name}");
            writer.WriteLine($"Student ID: {num}");

            for (int i = 0; i < MaxSubjects; i++) 
            {
                writer.WriteLine($"{subjects[i]} {levels[i]}  {grades[i]}"); ;
            }

            writer.Close(); // close the stream 



            

            
        }


        //display report method 
        static void DisplayResults(string name, string num, string[] subjects, string[] levels, string[] grades)
        {
            // calculate total grade points 
            int totalPoints = CalculateGrade(grades);

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Student Id: {num}");
            //Console.WriteLine("Subject     Level     grade");

            for (int i = 0; i < MaxSubjects ; i++) 
            {
                Console.WriteLine($"{subjects[i]} {levels[i]}  {grades[i]}");
            }
            
            // display total points 
            Console.WriteLine($"Total Points: {totalPoints}");
        }
        
    }
}