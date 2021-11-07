using System;
using System.Text.RegularExpressions;

namespace Z_Tata_GC_Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doContinue = true;
            string userInput = "";
            string message = "";

            Console.WriteLine("Z Tata GC AHBC Lab 7");

            do
            {
                Console.Clear();
                UserChoice userNumber = (UserChoice)ValidateNumber();

                switch (userNumber)
                {
                    case UserChoice.Name:
                        goto Name;
                        break;
                    case UserChoice.Email:
                        goto Email;
                        break;
                    case UserChoice.PhoneNumber:
                        goto PhoneNumber;
                        break;
                    case UserChoice.Dates:
                        goto Date;
                        break;
                    case UserChoice.HTMLElement:
                        goto HTMLElement;
                        break;
                }

            Name:
                Console.WriteLine("Please enter the name you would like to validate: ");
                userInput = Console.ReadLine();
                message = ValidateName(userInput);
                Console.WriteLine(message);
                goto TryAgain;

            Email:
                Console.WriteLine("Please enter the email address you would like to validate: ");
                userInput = Console.ReadLine();
                message = ValidateEmail(userInput);
                Console.WriteLine(message);
                goto TryAgain;


            PhoneNumber:
                Console.WriteLine("Please enter the phone number you would like to validate: ");
                userInput = Console.ReadLine();
                message = ValidatePhoneNumber(userInput);
                Console.WriteLine(message);
                goto TryAgain;

            Date:
                Console.WriteLine("Please enter the date you would like to validate: ");
                userInput = Console.ReadLine();
                message = ValidateDate(userInput);
                Console.WriteLine(message);
                goto TryAgain;

            HTMLElement:
                Console.WriteLine("Please enter the HTML element you would like to validate: ");
                userInput = Console.ReadLine();
                message = ValidateHTML(userInput);
                Console.WriteLine(message);
                goto TryAgain;

            TryAgain:
                doContinue = DoContinue();

            } while (doContinue);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static bool DoContinue()
        {
            string userInput = "";
            Console.WriteLine("Would you like to continue? Enter yes to continue or anything else to exit.");
            userInput = Console.ReadLine();
            if (userInput.Trim().ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static UserChoice ValidateNumber()
        {
            bool isValidNumber = false;
            string userInput = "";
            int userNumber = 0;
            while (isValidNumber == false)
            {
                Console.WriteLine("Please enter the number following the type of input you would like to validate: ");
                Console.WriteLine("Name = 1");
                Console.WriteLine("Email = 2");
                Console.WriteLine("Phone Number = 3");
                Console.WriteLine("Date = 4");
                Console.WriteLine("HTML Element = 5");
                userInput = Console.ReadLine();
                isValidNumber = int.TryParse(userInput, out userNumber);

                if (isValidNumber == false)
                {
                    Console.WriteLine("Sorry, that is not a valid input.");
                    isValidNumber = false;
                }
                else if (userNumber > 5 || userNumber < 1)
                {
                    Console.WriteLine("Sorry, your selection have to be 1, 2, 3, or 4.");
                    isValidNumber = false;
                }
                else
                {
                    Console.WriteLine("Thanks!");
                    isValidNumber = true;
                }
            }

            UserChoice userChoice = (UserChoice)userNumber;
            return userChoice;
        }

        public static string ValidateName(string userInput)
        {
            string message = "";
            string pattern = "^[A-Z][A-Za-z ]{0,29}$";
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(userInput);
            if (isMatch == true)
            {
                message = "That is a valid name";
            }
            else
            {
                message = "Sorry, that is not a valid input for name";
            }
            return message;
        }

        public static string ValidateEmail(string userInput)
        {
            string message = "";
            string pattern = "^[A-Za-z0-9]{5,30}@[A-Za-z0-9]{5,10}.[A-Za-z0-9]{2,3}$";
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(userInput);
            if (isMatch == true)
            {
                message = "That is a valid email address";
            }
            else
            {
                message = "Sorry, that is not a valid input for an email address";
            }
            return message;
        }

        public static string ValidatePhoneNumber(string userInput)
        {
            string message = "";
            string pattern = "^[0-9]{3}-[0-9]{3}-[0-9]{4}$";
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(userInput);
            if (isMatch == true)
            {
                message = "That is a valid phone number";
            }
            else
            {
                message = "Sorry, that is not a valid input for a phone number";
            }
            return message;
        }

        public static string ValidateDate(string userInput)
        {
            string message = "";
            string pattern = @"^[0-3][0-9]\/[0-1][0-9]\/[0-9]{4}";
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(userInput);
            if (isMatch == true)
            {
                message = "That is a valid date";
            }
            else
            {
                message = "Sorry, that is not a valid input for a date";
            }
            return message;
        }

        public static string ValidateHTML(string userInput)
        {
            string message = "";
            string pattern = @"^<[a-z][0-9]><\/[a-z][0-9]>$";
            Regex regex = new Regex(pattern);
            bool isMatch = regex.IsMatch(userInput);
            if (isMatch == true)
            {
                message = "That is a valid HTML element";
            }
            else
            {
                message = "Sorry, that is not a valid input for an HTML element";
            }
            return message;
        }


    }
}
