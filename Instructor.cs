using System.Collections.Generic;
using System;

class Instructor : User
{
    private readonly List<Course> courses = new List<Course>();

    public new string FirstName { get; set; }
    public new string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public Instructor(string firstName, string lastName, string username, string password)
        : base(username, password)
    {
        FirstName = firstName;
        LastName = lastName;

    }

    public void InstructorActions(Admin admin)
    {
        Console.WriteLine($"Welcome, Instructor {Username}!");
        Console.WriteLine("Instructor-specific actions can be performed here.");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Add Marks for Student");
        Console.WriteLine("2. Update Marks for Student");
        Console.WriteLine("3. Remove Marks for Student");
        Console.WriteLine("4. Display All Students with Marks");


        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    AddMarksForStudent(admin);
                    break;

                case 2:
                    UpdateMarksForStudent(admin);
                    break;

                case 3:
                    RemoveMarksForStudent(admin);
                    break;

                case 4:
                    DisplayAllStudentsWithMarks(admin);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void DisplayAllStudentsWithMarks(Admin admin)
    {
        admin.DisplayAllStudentsWithMarks();
    }

    private static void RemoveMarksForStudent(Admin admin)
    {
        Console.Write("Enter Student ID to remove marks: ");
        string studentIdToRemove = Console.ReadLine();

        Student studentToRemoveMarks = admin.GetStudentById(studentIdToRemove);

        if (studentToRemoveMarks == null)
        {
            Console.WriteLine($"Student with ID {studentIdToRemove} not found.");
            return;
        }

        // Assuming you have properties like Midterm1, Midterm2, Prefinal, and Final in your Student class
        studentToRemoveMarks.Midterm1 = 0;
        studentToRemoveMarks.Midterm2 = 0;
        studentToRemoveMarks.Prefinal = 0;
        studentToRemoveMarks.Final = 0;

        Console.WriteLine($"Marks removed for Student ID {studentToRemoveMarks.StudentId}. Total Marks: {studentToRemoveMarks.CalculateTotalMarks()}");
    }

    private static void UpdateMarksForStudent(Admin admin)
    {
        Console.Write("Enter Student ID to update marks: ");
        string studentIdToUpdate = Console.ReadLine();

        Student studentToUpdate = admin.GetStudentById(studentIdToUpdate);

        if (studentToUpdate == null)
        {
            Console.WriteLine($"Student with ID {studentIdToUpdate} not found.");
            return;
        }

        Console.Write("Enter updated Marks for Midterm1: ");
        int updatedMidterm1 = int.Parse(Console.ReadLine());

        Console.Write("Enter updated Marks for Midterm2: ");
        int updatedMidterm2 = int.Parse(Console.ReadLine());

        Console.Write("Enter updated Marks for Prefinal: ");
        int updatedPrefinal = int.Parse(Console.ReadLine());

        Console.Write("Enter updated Marks for Final: ");
        int updatedFinal = int.Parse(Console.ReadLine());

        // Assuming you have properties like Midterm1, Midterm2, Prefinal, and Final in your Student class
        studentToUpdate.Midterm1 = updatedMidterm1;
        studentToUpdate.Midterm2 = updatedMidterm2;
        studentToUpdate.Prefinal = updatedPrefinal;
        studentToUpdate.Final = updatedFinal;

        Console.WriteLine($"Marks updated for Student ID {studentToUpdate.StudentId}. Total Marks: {studentToUpdate.CalculateTotalMarks()}");
    }

    private static void AddMarksForStudent(Admin admin)
    {
        Console.Write("Enter Student ID to add marks: ");
        string studentId = Console.ReadLine();

        Student student = admin.GetStudentById(studentId);

        if (student == null)
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
            return;
        }

        Console.Write("Choose which marks to add:");
        Console.WriteLine("1. Midterm1");
        Console.WriteLine("2. Midterm2");
        Console.WriteLine("3. Prefinal");
        Console.WriteLine("4. Final");

        if (int.TryParse(Console.ReadLine(), out int markChoice))
        {
            AddSelectedMark(student, markChoice);
        }
        else
        {
            Console.WriteLine("Invalid input. Marks not added.");
        }
    }
    private static void AddSelectedMark(Student student, int markChoice)
    {
        switch (markChoice)
        {
            case 1:
                Console.Write("Enter Marks for Midterm1: ");
                student.Midterm1 += int.Parse(Console.ReadLine());
                break;

            case 2:
                Console.Write("Enter Marks for Midterm2: ");
                student.Midterm2 += int.Parse(Console.ReadLine());
                break;

            case 3:
                Console.Write("Enter Marks for Prefinal: ");
                student.Prefinal += int.Parse(Console.ReadLine());
                break;

            case 4:
                Console.Write("Enter Marks for Final: ");
                student.Final += int.Parse(Console.ReadLine());
                break;

            default:
                Console.WriteLine("Invalid choice. Marks not added.");
                break;
        }

        Console.WriteLine($"Marks added for Student ID {student.StudentId}. Total Marks: {student.CalculateTotalMarks()}");
    }
}