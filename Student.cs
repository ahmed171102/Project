using System;
using System.Collections.Generic;

class Student : User

{
    public string StudentId { get; }
    public string StudentName { get; set; }
    public int Midterm1 { get; set; }
    public int Midterm2 { get; set; }
    public int Prefinal { get; set; }
    public int Final { get; set; }

    public Student(string studentId, string studentName) : base(studentId, studentName)
    {
        StudentId = studentId;
        StudentName = studentName;
    }

    private static bool IsValidCredentials(string username, string password, Dictionary<string, string> validCredentials)
    {
        if (validCredentials.TryGetValue(username, out string expectedPassword))
        {
            return expectedPassword == password;
        }
        return false;
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

    internal Student Find(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
