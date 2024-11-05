using System.Collections;
using System.ComponentModel;

namespace StudentAdministration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                StudentRepository.AddStudent();
                Console.WriteLine("Add another student? (Press enter)");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            do
            {
                StudentRepository.AssignSubjects();
                Console.WriteLine("Assign more subjects & grades? (Press enter)");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            StudentRepository.DisplayStudents();
        }
    }

    internal record Subject(string subject, float grade)
    {
        public bool Passed => this.grade >= 2.0f;
    }
    internal static class StudentRepository
    {
        private static Dictionary<string, HashSet<Subject>> _students = new();
        internal static void AddStudent(string? name = null)
        {
            if(name == null)
            {
                Console.WriteLine("Add a student? (Write a name)");
                name = Console.ReadLine()?.ToLower();
            }
            if(String.IsNullOrEmpty(name))
            {
                Console.WriteLine("The Student name cannot be empty!");
                return;
            }
            if(_students.ContainsKey(name)) 
            {
                Console.WriteLine($"The Student {name} already exists!");
                return;
            }
            _students.Add(name, new HashSet<Subject>());
            Console.WriteLine($"The Student {name} was added!");
        }
        internal static void AssignSubjects()
        {
            Console.WriteLine("Assign subjects & grades for a student? (Write a name)");
            string? name = Console.ReadLine()?.ToLower();
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("The Student name cannot be empty!");
                return;
            }
            if (!_students.ContainsKey(name))
            {
                Console.WriteLine($"The Student {name} dosen't exists!");
                Console.WriteLine("Would you like to add the student? (Hit Enter to add)");
                if (Console.ReadKey().Key == ConsoleKey.Enter) AddStudent(name);
                else return;
            }
            Console.WriteLine($"Enter a subject grade for: {name}");
            string[]? subjectGrade = Console.ReadLine()?.ToLower()?.Split(' ');
            if(subjectGrade is null || subjectGrade.Length < 2)
            {
                Console.WriteLine("Missing input Please follow format \"subject grade\"");
                return;
            }
            if (!float.TryParse(subjectGrade[1], out float grade))
            {
                Console.WriteLine("The grade given must be a number!");
                return;
            }
            string subject = subjectGrade[0];
            _students[name].Add(new Subject(subject, grade));
            Console.WriteLine($"{subject} with grade {grade} added {name}");
        }
        internal static void DisplayStudents()
        {
            foreach (var student in _students)
            {
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                Console.WriteLine($"Showing Subjects & Grades for {student.Key}");
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                foreach (var subject in student.Value)
                {
                    Console.WriteLine($"Subject: {subject.subject} Grade: {subject.grade} Passed: {subject.Passed}");
                }
                float sum = student.Value.Sum(subject => subject.grade);
                Console.WriteLine($"Average: {sum} PassedAverage: {sum >= 2.0f}");
            }
        }
    }
}