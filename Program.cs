using System.Collections.Generic;
using System;

class Program
{
    static void Main()
    {
        bool validUserTypeEntered = false;
        do
        {
            Console.Write("Are you an Admin, Instructor, or Student? ");
            string userType = Console.ReadLine().ToLower();


            Dictionary<string, Dictionary<string, string>> validCredentials = new Dictionary<string, Dictionary<string, string>>
        {
            {"admin", new Dictionary<string, string> {{"admin1", "1111"}}},
            {"instructor", new Dictionary<string, string>
                {
                    {"sabry", "1111"},
                    {"medhat", "1111"}
                }
            },
            {"student", new Dictionary<string, string>
                {
                    {"5618", "1111"},
                    {"4050", "1111"}
                }
            }
        };

            if (validCredentials.TryGetValue(userType, out Dictionary<string, string> userCredentials))
            {
                bool isAuthenticated;
                do
                {
                    Console.Write("Enter your username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    isAuthenticated = IsValidCredentials(username, password, userCredentials);

                    if (!isAuthenticated)
                    {
                        Console.WriteLine("Invalid username or password. Access denied.");
                        Console.Write("Do you want to try again? (yes/no): ");
                        string tryAgain = Console.ReadLine().ToLower();

                        if (tryAgain != "yes")
                        {
                            Console.WriteLine("Exiting program.");
                            return;
                        }
                    }

                } while (!isAuthenticated);

                HandleUserTypeActions(userType);
                validUserTypeEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid user type.");
                Console.Write("Do you want to try again? (yes/no): ");
                string tryAgain = Console.ReadLine().ToLower();

                if (tryAgain != "yes")
                {
                    Console.WriteLine("Exiting program.");
                    return;
                }
            }

        } while (!validUserTypeEntered);

        Console.ReadKey();
    }
    private static void HandleUserTypeActions(string userType)
    {
        switch (userType)
        {
            case "admin":
                Admin admin = new Admin("Karim", "Maghawary", "admin", "1111");
                admin.InitializeTestData();
                AdminLoop(admin);
                break;

            case "instructor":
                Instructor instructor = new Instructor("Sabry", "Medhat", "Sabry_instructor", "Sabry_instructor");
                Admin adminForInstructor = new Admin("Karim", "Maghawary", "admin", "1111");
                adminForInstructor.InitializeTestData();
                InstructorLoop(instructor, adminForInstructor);
                break;

            case "student":
                Student student = new Student("5618", "Ahmed", "ahmed171102", "1111");
                StudentLoop(student);
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

    private static void StudentLoop(Student student)
    {
        bool returnToMainMenu;

        do
        {
            student.StudentActions(out returnToMainMenu);

        } while (ShouldReturnToMenu() && returnToMainMenu);
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
