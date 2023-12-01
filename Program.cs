using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {

        Dictionary<string, Dictionary<string, string>> validCredentials = new Dictionary<string, Dictionary<string, string>>
{
   
    {"admin", new Dictionary<string, string> {{"admin1", "1111"}}},

   
    {"instructor", new Dictionary<string, string>
        {
            {"abc1", "1111"},
            {"jane_instructor", "password2"}
        }
    },

   
    {"student", new Dictionary<string, string>
        {
            {"5618", "1111"},
            {"S002", "studentPass2"}
        }
    }
};



        Console.Write("Are you an Admin, Instructor, or Student? ");
        string userType = Console.ReadLine().ToLower();

        if (validCredentials.TryGetValue(userType, out Dictionary<string, string> userCredentials))
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (IsValidCredentials(username, password, userCredentials))
            {

                HandleUserTypeActions(userType, username);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Access denied.");
            }
        }
        else
        {
            Console.WriteLine("Invalid user type.");
        }

        Console.ReadKey();
    }

    private static void HandleUserTypeActions(string userType, string username)
    {
        switch (userType)
        {
            case "admin":
                Admin admin = new Admin(username, ""); 
                admin.InitializeTestData();
                AdminLoop(admin);
                break;

            case "instructor":
                Instructor instructor = new Instructor("Jane", "Doe", username, "");
                Admin adminForInstructor = new Admin("admin", "1111");
                adminForInstructor.InitializeTestData();
                InstructorLoop(instructor, adminForInstructor);
                break;

            case "student":
                Console.WriteLine($"Welcome, Student {username}!");
                break;

            default:
                Console.WriteLine("Unknown user type.");
                break;
        }
    }

    private static void AdminLoop(Admin admin)
    {
        do
        {
            admin.AdminActions();

        } while (ShouldReturnToMenu());
    }

    private static void InstructorLoop(Instructor instructor, Admin Admin)
    {
        do
        {
            instructor.InstructorActions(Admin);

        } while (ShouldReturnToMenu());
    }

    private static bool ShouldReturnToMenu()
    {
        Console.Write("Do you want to return to the main menu? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        return response == "yes";
    }



    static bool IsValidCredentials(string username, string password, Dictionary<string, string> validCredentials)
    {
        if (validCredentials.TryGetValue(username, out string expectedPassword))
        {
            return expectedPassword == password;
        }
        return false;
    }
}
