// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    class Program
    {

        static void Main(string[] args)
        {
            var book = new Book("Haleys Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;

            var done = false;

            while (!done)
            {
                Console.WriteLine("enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }

                try
                {

                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
            book.AddGrade(89.1);
            book.AddGrade(39.4);
            book.AddGrade(45.6);
            book.GetStats();
            var stats = book.GetStats();
            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine(book.Name);
            Console.WriteLine($"the lowest grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade Added");
        }
    }
}
