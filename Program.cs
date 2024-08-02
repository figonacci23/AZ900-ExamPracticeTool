using System;
using System.Diagnostics;

namespace ExamTopicsExamGenerator
{
    internal class Program
    {
        static void Question(int number)
        {
            string query = "Microsoft AZ-900 Exam Question#" + number;
            string encodedQuery = Uri.EscapeDataString(query);
            string url = $"https://www.google.com/search?q={encodedQuery}";

            var psi = new ProcessStartInfo
            {
                FileName = "iexplore.exe",
                Arguments = url
            };

            // Start the browser process
            Process.Start(psi);
        }

        static int Answers(int numQuestions)
        {
            int correctAnswers = 0;
            Random rnd = new Random();

            for (int i = 0; i < numQuestions; i++)
            {
                int questionNumber = rnd.Next(1, 400);
                Question(questionNumber);

                Console.WriteLine("Did you get question " + questionNumber + " correct? (Y/N): ");
                string userResponse = Console.ReadLine()?.Trim().ToUpper();

                while (userResponse != "Y" && userResponse != "N")
                {
                    Console.WriteLine("Invalid input. Please enter Y or N: ");
                    userResponse = Console.ReadLine()?.Trim().ToUpper();
                }

                if (userResponse == "Y")
                {
                    correctAnswers++;
                }
            }

            return correctAnswers;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the number of questions you want to answer: ");
            if (int.TryParse(Console.ReadLine(), out int numQuestions))
            {
                int correctAnswers = Answers(numQuestions);
                Console.WriteLine($"You got {correctAnswers} out of {numQuestions} questions correct.");
            }
            else
            {
                Console.WriteLine("Invalid number of questions. Please enter a valid integer.");
            }

            // Keep the console window open
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}