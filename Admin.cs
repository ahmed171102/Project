using System.Collections.Generic;
using System;
using System.Linq;

class Admin : User
{

    private readonly List<Student> students = new List<Student>();

    private readonly List<Instructor> instructors = new List<Instructor>();

    private readonly List<Course> courses = new List<Course>();

    public void InitializeTestData()
    {
        students.Add(new Student("211005670", "Ahmed AlSheikh"));
        students.Add(new Student("211007142", "Hamza Momani"));
        students.Add(new Student("211003109", "Ali Younes"));

        instructors.Add(new Instructor("Mohammed", "Ahmed", "mohammed_instructor", "1111"));
        instructors.Add(new Instructor("Hassan", "Khairy", "hassan_instructor", "5678"));

        Course course1 = new Course("Advanced Programming", "CC319", instructors[0]);
        Course course2 = new Course("System Programming", "CC410", instructors[1]);

        instructors[0].Courses.Add(course1);
        instructors[1].Courses.Add(course2);

        course1.SetTimings(course1, "Thursday", "12:00 PM", "2:00 PM");
        course2.SetTimings(course2, "Sunday", "2:00 PM", "4:00 PM");
    }



    public Student GetStudentById(string studentId)
    {
        return students.Find(s => s.StudentId == studentId);
    }

    public Admin(string firstName, string lastName, string username, string password) : base(username, password, firstName, lastName)
    {

    }

    public void InitializeTestData(List<Student> students, List<Instructor> instructors)
    {
        this.students.AddRange(students);
        this.instructors.AddRange(instructors);
    }

    public void AdminActions()
    {
        Console.WriteLine($"Welcome, Admin {FirstName}!");
        Console.WriteLine("Admin-specific actions can be performed here.");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Update Student");
        Console.WriteLine("3. Remove Student");
        Console.WriteLine("4. Manage Instructors");
        Console.WriteLine("5. Display All Students");
        Console.WriteLine("6. Display All Instructors");
        Console.WriteLine("7. Manage Courses");
        Console.WriteLine("8. Exit");

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

                case 7:
                    ManageCourses();
                    break;

                case 8:
                    Console.WriteLine("Exiting Admin Menu.");
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

        if (int.TryParse(updatedFirstName, out _))
        {
            Console.WriteLine("Invalid input for First Name. Please enter a valid string.");
            return;
        }

        instructorToUpdate.FirstName = updatedFirstName;
        instructorToUpdate.LastName = updatedLastName;

        Console.WriteLine($"Instructor updated: Username - {instructorToUpdate.Username}, Updated Name - {instructorToUpdate.FullName}");
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

    private void ManageCourses()
    {
        Console.WriteLine("Manage Courses:");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. View Course Details for Each Instructor");
        Console.WriteLine("2. Display Enrolled Students in Each Course");
        Console.WriteLine("3. Go Back to Admin Menu");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    ViewCourseDetailsForEachInstructor();
                    break;

                case 2:
                    DisplayEnrolledStudentsInEachCourse();
                    break;

                case 3:
                    Console.WriteLine("Going back to Admin Menu.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    private void ViewCourseDetailsForEachInstructor()
    {
        Console.WriteLine("Course details for each instructor:");

        foreach (var currentInstructor in instructors)
        {
            if (currentInstructor != null)
            {
                Console.WriteLine($"Instructor: {currentInstructor.FullName}");

                if (currentInstructor.Courses != null && currentInstructor.Courses.Any())
                {
                    foreach (var course in currentInstructor.Courses)
                    {
                        if (course is Course courseObject && courseObject != null)
                        {
                            Console.WriteLine($"  Course Name: {courseObject.Name}");
                            Console.WriteLine($"  Course Code: {courseObject.Code}");

                            Console.WriteLine("  Timetable:");
                            courseObject.DisplayTimetable();

                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  No courses found for this instructor.");
                }

                Console.WriteLine();
            }
        }
    }


    private void DisplayEnrolledStudentsInEachCourse()
    {
        Console.WriteLine("Enrolled students in each course:");
        foreach (var course in courses)
        {
            Console.WriteLine($"Course: {course.Name}");

            if (course.EnrolledStudents.Any())
            {
                Console.WriteLine("Enrolled Students:");
                foreach (var student in course.EnrolledStudents)
                {
                    Console.WriteLine($"  Student ID: {student.StudentId}, Name: {student.StudentName}");

                    var otherEnrolledStudents = course.EnrolledStudents.Where(s => s.StudentId != student.StudentId);
                    if (otherEnrolledStudents.Any())
                    {
                        Console.WriteLine("  Other Students in the Same Class:");
                        foreach (var otherStudent in otherEnrolledStudents)
                        {
                            Console.WriteLine($"    Student ID: {otherStudent.StudentId}, Name: {otherStudent.StudentName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  No other students in the same class.");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No students enrolled in this course.");
            }

            Console.WriteLine();
        }
    }

    public void ViewStudentInformation(Student student)
    {
        Console.WriteLine($"Choose information to view for Student {student.StudentName}:");
        Console.WriteLine("1. View Marks");
        Console.WriteLine("2. View Timetable");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    ViewStudentMarks(student);
                    break;

                case 2:
                    ViewStudentTimetable(student);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    private void ViewStudentMarks(Student student)
    {
        Console.WriteLine($"Marks for Student {student.StudentName}:");
        Console.WriteLine($"Midterm1: {student.Midterm1}");
        Console.WriteLine($"Midterm2: {student.Midterm2}");
        Console.WriteLine($"Prefinal: {student.Prefinal}");
        Console.WriteLine($"Final: {student.Final}");
        Console.WriteLine($"Total Marks: {student.CalculateTotalMarks()}");
    }

    private void ViewStudentTimetable(Student student)
    {
        Console.WriteLine($"Timetable for Student {student.StudentName}:");
        foreach (var entry in student.CourseTimings)
        {
            Console.WriteLine($"Course: {entry.Key.Name}, Timings: {entry.Value}");
        }
    }
}