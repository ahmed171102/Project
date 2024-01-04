using System.Collections.Generic;
using System;
using System.Linq;

class Course
{
    public string Name { get; }
    public string Code { get; }
    public Instructor Instructor { get; }
    public LinkedList<Student> Students { get; set; } = new LinkedList<Student>();
    public Dictionary<string, string> Timings { get; set; } = new Dictionary<string, string>();
    public List<Student> EnrolledStudents { get; } = new List<Student>();



    public Course(string name, string code, Instructor instructor)
    {
        Name = name;
        Code = code;
        Instructor = instructor;
    }

    public Course(string name)
    {
        Name = name;
    }

    public Course(string name, Instructor instructor) : this(name)
    {
        Instructor = instructor;
    }

    public void AddEnrolledStudent(Student student)
    {
        EnrolledStudents.Add(student);
        student.SetCourseAndInstructor(this, Instructor);
        Console.WriteLine($"Student {student.StudentName} enrolled in the course {Name}.");
    }


    public void DisplayStudentMarks()
    {
        Console.WriteLine($"Marks for Course: {Name}");
        foreach (var student in Students)
        {
            Console.WriteLine($"Student ID: {student.StudentId}, Total Marks: {student.CalculateTotalMarks()}");
        }
    }

    public void DisplayInstructorDetails()
    {
        Console.WriteLine($"Instructor: {Instructor.FullName}");
    }


    public void DisplayEnrolledStudents()
    {
        Console.WriteLine($"Enrolled Students in Course {Name}:");
        foreach (var student in Students)
        {
            Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.StudentName}");
        }
    }

    public void SetTimings(Course course, string dayOfWeek, string startTime, string endTime)
    {
        try
        {

            course.Timings.Add(dayOfWeek, $"{startTime} - {endTime}");

            foreach (var student in course.Students)
            {
                if (!student.CourseTimings.ContainsKey(course))
                {
                    student.CourseTimings.Add(course, $"{dayOfWeek}: {startTime} - {endTime}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }



    public void DisplayTimetable()
    {
        Console.WriteLine($"Timetable for Course {Name}:");
        if (Timings != null && Timings.Any())
        {
            foreach (var entry in Timings)
            {
                Console.WriteLine($"Day: {entry.Key}, Time: {entry.Value}");
            }
        }
        else
        {
            Console.WriteLine("No timetable available for this course.");
        }
    }

    public void DisplayTimetableForAllStudents()
    {
        Console.WriteLine("Timetable for all students:");

        foreach (var student in Students)
        {
            Console.WriteLine($"Student: {student.StudentName}");
            foreach (var entry in student.CourseTimings)
            {
                Console.WriteLine($"  Course: {entry.Key.Name}");
                entry.Key.DisplayCourseDetails();
                Console.WriteLine($"    Timings: {entry.Value}");
            }
            Console.WriteLine();
        }
    }
    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {Name}");
        Console.WriteLine($"Code: {Code}");
        Console.WriteLine($"Instructor: {Instructor.FullName}");

        Console.WriteLine("Timings:");
        if (Timings != null && Timings.Any())
        {
            foreach (var entry in Timings)
            {
                Console.WriteLine($"  Day: {entry.Key}, Time: {entry.Value}");
            }
        }
        else
        {
            Console.WriteLine("No timetable available for this course.");
        }
        Console.WriteLine();
    }


}