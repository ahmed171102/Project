using System.Collections.Generic;
using System;

class Admin : User
{
    private readonly List<Student> students = new List<Student>();
    private readonly List<Instructor> instructors = new List<Instructor>();

    public void InitializeTestData()
    {
        students.Add(new Student("S001", "John Doe"));
        students.Add(new Student("S002", "Jane Smith"));
        students.Add(new Student("S003", "Bob Johnson"));

        instructors.Add(new Instructor("John", "Smith", "john_instructor", "1234"));
        instructors.Add(new Instructor("Jane", "Doe", "jane_instructor", "5678"));
    }
    public Student GetStudentById(string studentId)
    {
        return students.Find(s => s.StudentId == studentId);
    }

    public Admin(string username, string password) : base(username, password)
    {

    }


    public void AdminActions()
    {
        Console.WriteLine($"Welcome, Admin {Username}!");
        Console.WriteLine("Admin-specific actions can be performed here.");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Update Student");
        Console.WriteLine("3. Remove Student");
        Console.WriteLine("4. Manage Instructors");
        Console.WriteLine("5. Display All Students");
        Console.WriteLine("6. Display All Instructors");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    UpdateStudent();
                    break;

                case 3:
                    RemoveStudent();
                    break;

                case 4:
                    ManageInstructors();
                    break;

                case 5:
                    DisplayAllStudentsWithMarks();
                    break;

                case 6:
                    DisplayAllInstructors();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }


    private void AddStudent()
    {
        Console.Write("Enter Student ID: ");
        string studentId = Console.ReadLine();


        if (students.Exists(s => s.StudentId == studentId))
        {
            Console.WriteLine($"Student with ID {studentId} already exists.");
            return;
        }

        Console.Write("Enter Student Name: ");
        string studentName = Console.ReadLine();

        Student newStudent = new Student(studentId, studentName);
        students.Add(newStudent);

        Console.WriteLine($"Student added: ID - {newStudent.StudentId}, Name - {newStudent.StudentName}");
    }

    private void UpdateStudent()
    {
        Console.Write("Enter Student ID to update: ");
        string studentIdToUpdate = Console.ReadLine();


        Student studentToUpdate = students.Find(s => s.StudentId == studentIdToUpdate);

        if (studentToUpdate == null)
        {
            Console.WriteLine($"Student with ID {studentIdToUpdate} not found.");
            return;
        }

        Console.Write("Enter updated Student Name: ");
        string updatedStudentName = Console.ReadLine();

       
        studentToUpdate.StudentName = updatedStudentName;

        Console.WriteLine($"Student updated: ID - {studentToUpdate.StudentId}, Updated Name - {studentToUpdate.StudentName}");
    }

    private void RemoveStudent()
    {
        Console.Write("Enter Student ID to remove: ");
        string studentIdToRemove = Console.ReadLine();

       
        Student studentToRemove = students.Find(s => s.StudentId == studentIdToRemove);

        if (studentToRemove == null)
        {
            Console.WriteLine($"Student with ID {studentIdToRemove} not found.");
            return;
        }

        students.Remove(studentToRemove);
        Console.WriteLine($"Student removed: ID - {studentToRemove.StudentId}, Name - {studentToRemove.StudentName}");
    }
    private void ManageInstructors()
    {
        Console.WriteLine("Instructor Management Menu:");
        Console.WriteLine("1. Add Instructor");
        Console.WriteLine("2. Update Instructor");
        Console.WriteLine("3. Remove Instructor");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    AddInstructor();
                    break;

                case 2:
                    UpdateInstructor();
                    break;

                case 3:
                    RemoveInstructor();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
    private void AddInstructor()
    {

        Console.WriteLine("Enter Instructor First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Instructor Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Instructor Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Instructor Password: ");
        string password = Console.ReadLine();

        Instructor newInstructor = new Instructor(firstName, lastName, username, password);
        instructors.Add(newInstructor);

        Console.WriteLine($"Instructor added: Username - {newInstructor.Username}, Name - {newInstructor.FullName}");
    }

    private void UpdateInstructor()
    {
        Console.Write("Enter Instructor Username to update: ");
        string usernameToUpdate = Console.ReadLine();

        Instructor instructorToUpdate = instructors.Find(i => i.Username == usernameToUpdate);

        if (instructorToUpdate == null)
        {
            Console.WriteLine($"Instructor with Username {usernameToUpdate} not found.");
            return;
        }

        Console.Write("Enter updated Instructor First Name: ");
        string updatedFirstName = Console.ReadLine();

        Console.Write("Enter updated Instructor Last Name: ");
        string updatedLastName = Console.ReadLine();

        instructorToUpdate.FirstName = GetUpdatedFirstName(updatedFirstName);
        instructorToUpdate.LastName = updatedLastName;

        Console.WriteLine($"Instructor updated: Username - {instructorToUpdate.Username}, Updated Name - {instructorToUpdate.FullName}");
    }

    private static string GetUpdatedFirstName(string updatedFirstName)
    {
        return updatedFirstName;
    }

    private void RemoveInstructor()
    {
        Console.Write("Enter Instructor Username to remove: ");
        string usernameToRemove = Console.ReadLine();

        Instructor instructorToRemove = instructors.Find(i => i.Username == usernameToRemove);

        if (instructorToRemove == null)
        {
            Console.WriteLine($"Instructor with Username {usernameToRemove} not found.");
            return;
        }

        instructors.Remove(instructorToRemove);
        Console.WriteLine($"Instructor removed: Username - {instructorToRemove.Username}, Name - {instructorToRemove.FullName}");
    }
    public void DisplayAllStudentsWithMarks()
    {
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.StudentId}, Name: {student.StudentName}");
            Console.WriteLine($"  Marks: Midterm1 - {student.Midterm1}, Midterm2 - {student.Midterm2}, Prefinal - {student.Prefinal}, Final - {student.Final}");
        }
    }

    private void DisplayAllInstructors()
    {
        Console.WriteLine("All Current Instructors:");
        foreach (var instructor in instructors)
        {
            Console.WriteLine($"Username: {instructor.Username}, Name: {instructor.FullName}");
        }


    }
}
    
