using System.Collections.Generic;
using System;
using System.Xml.Linq;

class Student : User
{
    private readonly List<Course> enrolledCourses = new List<Course>();
    private readonly Dictionary<string, string> validCredentials;
    public Dictionary<Course, string> CourseTimings { get; set; } = new Dictionary<Course, string>();


    public string StudentId { get; }
    public string StudentName { get; set; }
    public int Midterm1 { get; set; }
    public int Midterm2 { get; set; }
    public int Prefinal { get; set; }
    public int Final { get; set; }
    public Course EnrolledCourse { get; private set; }
    public Instructor CourseInstructor { get; private set; }
    public List<Course> EnrolledCourses { get; } = new List<Course>();
    public Instructor AssignedInstructor { get; private set; }
    public Dictionary<Course, Instructor> CourseInstructorMap { get; } = new Dictionary<Course, Instructor>();


    public Student(string studentId, string studentName, Dictionary<string, string> credentials)
    : base(studentId, studentName)
    {
        StudentId = studentId;
        StudentName = studentName;
        validCredentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
    }

    public Student(string studentId, string studentName)
         : base(studentId, studentName)
    {
        StudentId = studentId;
        StudentName = studentName;
        validCredentials = new Dictionary<string, string>();
    }

    public Student(string studentId, string studentName, string username, string password)
    : base(username, password)
    {
        StudentId = studentId;
        StudentName = studentName;
        validCredentials = new Dictionary<string, string>
    {
        { username, password },
    };
    }


    public void SetCourseAndInstructor(Course course, Instructor instructor)
    {
        EnrolledCourse = course;
        CourseInstructor = instructor;
        EnrolledCourses.Add(course);
    }



    public void ViewMarks()
    {
        if (IsValidCredentials(Username, Password))
        {
            Console.WriteLine($"Welcome, {StudentName}!");
            Console.WriteLine("Your Marks:");
            Console.WriteLine($"Midterm1: {Midterm1}");
            Console.WriteLine($"Midterm2: {Midterm2}");
            Console.WriteLine($"Prefinal: {Prefinal}");
            Console.WriteLine($"Final: {Final}");
            Console.WriteLine($"Total Marks: {CalculateTotalMarks()}");
        }
        else
        {
            Console.WriteLine("Invalid credentials. Access denied.");
        }
    }





    private bool IsValidCredentials(string enteredUsername, string enteredPassword)
    {
        if (validCredentials.TryGetValue(enteredUsername, out string expectedPassword))
        {
            return expectedPassword == enteredPassword;
        }
        return false;
    }

    public void SetTimings(Course course, string dayOfWeek, string startTime, string endTime)
    {

        course.Timings.Add(dayOfWeek, $"{startTime} - {endTime}");


        foreach (var student in course.EnrolledStudents)
        {
            if (!student.CourseTimings.ContainsKey(course))
            {
                student.CourseTimings.Add(course, $"{dayOfWeek}: {startTime} - {endTime}");
            }
        }
    }

    public void AssignInstructor(Instructor instructor)
    {
        AssignedInstructor = instructor;
    }

    public void ViewEnrolledCourses()
    {
        Console.WriteLine($"Courses Enrolled by Student {FirstName}{LastName}:");
        foreach (var course in enrolledCourses)
        {
            Console.WriteLine($"Course Name: {course.Name}");
        }
    }

    public void ViewCourseDetails(Course course)
    {
        Console.WriteLine($"Course Details for {course.Name}:");
        Console.WriteLine($"Instructor: {course.Instructor.FullName}");
    }

    public void DisplayTimetable()
    {
        Console.WriteLine($"Timetables for Student {StudentName}:");

        foreach (var course in enrolledCourses)
        {
            Console.WriteLine($"Timetable for Course {course.Name}:");

            if (CourseTimings.TryGetValue(course, out string timetable))
            {
                Console.WriteLine($"Day: {timetable}");
            }
            else
            {
                Console.WriteLine("No timetable available for this course.");
            }

            Console.WriteLine();
        }
    }

    public void ViewEnrolledCoursesDetails()
    {
        Console.WriteLine($"Enrolled Courses Details for Student {StudentName}:");
        foreach (var course in enrolledCourses)
        {
            Console.WriteLine($"Course Name: {course.Name}");
            course.DisplayInstructorDetails();
        }
    }

    public void ViewTimetable()
    {
        Console.WriteLine($"Timetable for Student {StudentName}:");
        foreach (var course in EnrolledCourses)
        {
            if (CourseTimings.TryGetValue(course, out string timetable))
            {
                Console.WriteLine($"Course: {course.Name} ({course.Code}), Timings: {timetable}");
            }
            else
            {
                Console.WriteLine($"No timetable available for Course: {course.Name} ({course.Code})");
            }
        }
    }

    public void StudentActions(out bool returnToMainMenu)
    {
        returnToMainMenu = true;

        Console.WriteLine($"Welcome, Student {StudentName}!");
        Console.WriteLine("Student-specific actions can be performed here.");
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. View Marks");
        Console.WriteLine("2. View Timetable");
        Console.WriteLine("3. Exit");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            switch (choice)
            {
                case 1:
                    ViewMarks();
                    break;

                case 2:
                    ViewTimetable();
                    break;

                case 3:
                    Console.WriteLine("Returning to Main Menu.");
                    returnToMainMenu = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }


    public int CalculateTotalMarks()
    {
        return Midterm1 + Midterm2 + Prefinal + Final;
    }


    public override string ToString()
    {
        return base.ToString();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}