using System;
using System.Collections.Generic;

class Course
{
    public string Name { get; }
    public Instructor Instructor { get;}
    public LinkedList<Student> Students { get; } = new LinkedList<Student>();

    public Course(string name, Instructor instructor)
    {
        Name = name;
        Instructor = instructor;
    }

    public void AddStudent(Student student)
    {
        Students.AddLast(student);
    }

    public void DisplayStudentMarks()
    {
        Console.WriteLine($"Marks for Course: {Name}");
        foreach (var student in Students)
        {
            Console.WriteLine($"Student ID: {student.StudentId}, Total Marks: {student.CalculateTotalMarks()}");
        }
    }
}