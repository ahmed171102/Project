using System;
using System.Collections.Generic;

class Instructor : User
{
    public List<Course> CoursesTaught { get; } = new List<Course>();
    public List<Course> Courses { get; } = new List<Course>();
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

        while (true)
        {
            Console.WriteLine("Choose which marks to remove:");
            Console.WriteLine("1. Midterm1");
            Console.WriteLine("2. Midterm2");
            Console.WriteLine("3. Prefinal");
            Console.WriteLine("4. Final");
            Console.WriteLine("5. Done removing");

            if (int.TryParse(Console.ReadLine(), out int markChoice))
            {
                if (markChoice == 5)
                {
                    break;
                }

                RemoveSelectedMark(studentToRemoveMarks, markChoice);
            }
            else
            {
                Console.WriteLine("Invalid input. Marks not removed.");
            }
        }

        Console.WriteLine($"Marks removed for Student ID {studentToRemoveMarks.StudentId}. Total Marks: {studentToRemoveMarks.CalculateTotalMarks()}");
    }

    private static void RemoveSelectedMark(Student student, int markChoice)
    {
        switch (markChoice)
        {
            case 1:
                student.Midterm1 = 0;
                break;

            case 2:
                student.Midterm2 = 0;
                break;

            case 3:
                student.Prefinal = 0;
                break;

            case 4:
                student.Final = 0;
                break;

            default:
                Console.WriteLine("Invalid choice. Marks not removed.");
                break;
        }
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

        while (true)
        {
            Console.WriteLine("Choose which marks to update:");
            Console.WriteLine("1. Midterm1");
            Console.WriteLine("2. Midterm2");
            Console.WriteLine("3. Prefinal");
            Console.WriteLine("4. Final");
            Console.WriteLine("5. Done updating");

            if (int.TryParse(Console.ReadLine(), out int markChoice))
            {
                if (markChoice == 5)
                {
                    break;
                }

                UpdateSelectedMark(studentToUpdate, markChoice);
            }
            else
            {
                Console.WriteLine("Invalid input. Marks not updated.");
            }
        }

        Console.WriteLine($"Marks updated for Student ID {studentToUpdate.StudentId}. Total Marks: {studentToUpdate.CalculateTotalMarks()}");
    }

    private static void UpdateSelectedMark(Student student, int markChoice)
    {
        switch (markChoice)
        {
            case 1:
                Console.Write("Enter updated Marks for Midterm1: ");
                int updatedMidterm1 = int.Parse(Console.ReadLine());
                if (updatedMidterm1 > 30)
                {
                    Console.WriteLine("Warning: Midterm1 marks should not exceed 30. Marks not updated.");
                }
                else
                {
                    student.Midterm1 = Math.Min(updatedMidterm1, 30);
                }
                break;

            case 2:
                Console.Write("Enter updated Marks for Midterm2: ");
                int updatedMidterm2 = int.Parse(Console.ReadLine());
                if (updatedMidterm2 > 20)
                {
                    Console.WriteLine("Warning: Midterm2 marks should not exceed 20. Marks not updated.");
                }
                else
                {
                    student.Midterm2 = Math.Min(updatedMidterm2, 20);
                }
                break;

            case 3:
                Console.Write("Enter updated Marks for Prefinal: ");
                int updatedPrefinal = int.Parse(Console.ReadLine());
                if (updatedPrefinal > 10)
                {
                    Console.WriteLine("Warning: Prefinal marks should not exceed 10. Marks not updated.");
                }
                else
                {
                    student.Prefinal = Math.Min(updatedPrefinal, 10);
                }
                break;

            case 4:
                Console.Write("Enter updated Marks for Final: ");
                int updatedFinal = int.Parse(Console.ReadLine());
                if (updatedFinal > 40)
                {
                    Console.WriteLine("Warning: Final marks should not exceed 40. Marks not updated.");
                }
                else
                {
                    student.Final = Math.Min(updatedFinal, 40);
                }
                break;

            default:
                Console.WriteLine("Invalid choice. Marks not updated.");
                break;
        }

        Console.WriteLine($"Marks updated for Student ID {student.StudentId}. Total Marks: {student.CalculateTotalMarks()}");

        if (student.CalculateTotalMarks() > 100)
        {
            Console.WriteLine("Warning: Total marks cannot exceed 100. Marks not updated.");
            student.Midterm1 = Math.Min(student.Midterm1, 30);
            student.Midterm2 = Math.Min(student.Midterm2, 20);
            student.Prefinal = Math.Min(student.Prefinal, 10);
            student.Final = Math.Min(student.Final, 40);
        }
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

        while (true)
        {
            Console.WriteLine("Choose which marks to add:");
            Console.WriteLine("1. Midterm1");
            Console.WriteLine("2. Midterm2");
            Console.WriteLine("3. Prefinal");
            Console.WriteLine("4. Final");
            Console.WriteLine("5. Done adding");

            if (int.TryParse(Console.ReadLine(), out int markChoice))
            {
                if (markChoice == 5)
                {
                    break;
                }

                AddSelectedMark(student, markChoice);
            }
            else
            {
                Console.WriteLine("Invalid input. Marks not added.");
            }
        }

        Console.WriteLine($"Marks added for Student ID {student.StudentId}. Total Marks: {student.CalculateTotalMarks()}");
    }

    private static void AddSelectedMark(Student student, int markChoice)
    {
        switch (markChoice)
        {
            case 1:
                Console.Write("Enter Marks for Midterm1: ");
                int midterm1 = int.Parse(Console.ReadLine());
                if (midterm1 > 30)
                {
                    Console.WriteLine("Warning: Midterm1 marks should not exceed 30. Marks not added.");
                }
                else
                {
                    student.Midterm1 = Math.Min(student.Midterm1 + midterm1, 30);
                }
                break;

            case 2:
                Console.Write("Enter Marks for Midterm2: ");
                int midterm2 = int.Parse(Console.ReadLine());
                if (midterm2 > 20)
                {
                    Console.WriteLine("Warning: Midterm2 marks should not exceed 20. Marks not added.");
                }
                else
                {
                    student.Midterm2 = Math.Min(student.Midterm2 + midterm2, 20);
                }
                break;

            case 3:
                Console.Write("Enter Marks for Prefinal: ");
                int prefinal = int.Parse(Console.ReadLine());
                if (prefinal > 10)
                {
                    Console.WriteLine("Warning: Prefinal marks should not exceed 10. Marks not added.");
                }
                else
                {
                    student.Prefinal = Math.Min(student.Prefinal + prefinal, 10);
                }
                break;

            case 4:
                Console.Write("Enter Marks for Final: ");
                int final = int.Parse(Console.ReadLine());
                if (final > 40)
                {
                    Console.WriteLine("Warning: Final marks should not exceed 40. Marks not added.");
                }
                else
                {
                    student.Final = Math.Min(student.Final + final, 40);
                }
                break;

            default:
                Console.WriteLine("Invalid choice. Marks not added.");
                break;
        }

        Console.WriteLine($"Marks added for Student ID {student.StudentId}. Total Marks: {student.CalculateTotalMarks()}");
    }

    private static void ViewCourseDetailsForEachInstructor(Instructor instructor)
    {
        Console.WriteLine("Course details for each instructor:");

        foreach (var course in instructor.CoursesTaught)
        {
            Console.WriteLine($"  Course Name: {course.Name}");
        }
    }

    private static void DisplayTimetableForAllInstructors(IEnumerable<Instructor> instructors)
    {
        Console.WriteLine("Timetable for all instructors:");

        foreach (var instructor in instructors)
        {
            Console.WriteLine($"Instructor: {instructor.FullName}");
            foreach (var course in instructor.CoursesTaught)
            {
                Console.WriteLine($"  Course: {course.Name}");
                course.DisplayTimetable();
                Console.WriteLine();
            }
        }
    }
}