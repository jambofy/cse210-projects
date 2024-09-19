using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        
        // Converting the input to an integer
        int grade = int.Parse(input);

        // Determining the letter grade
        string letterGrade = "";
        string sign = "";

        
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

       
        if (letterGrade != "A" && letterGrade != "F")
        {
            int lastDigit = grade % 10; // Get the last digit of the percentage

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

 
        if (letterGrade == "A")
        {
            int lastDigit = grade % 10; // Recalculate last digit for A
            if (lastDigit < 3)
            {
                sign = "-"; 
            }
        }

        // Special case: There is no F+ or F-, just F
        if (letterGrade == "F")
        {
            sign = ""; // F+ and F- don't exist
        }

        // Display the letter grade and sign
        Console.WriteLine($"Your letter grade is: {letterGrade}{sign}");

        // Determine if the user passed or failed the course
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. Keep working hard and you'll do better next time!");
        }
    }
}
