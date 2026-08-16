using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_methods_library
{
    public static class LibraryOperations
    {
        public static Dictionary<string, bool> libraryStorage = new Dictionary<string, bool>();

        public static void WelcomeToApp()
        {
            Console.WriteLine("Welcome to Library Manager Pro");
            Console.WriteLine("*******************************");
        }

        public static bool ValidInput(string? input)
        {
            if (String.IsNullOrEmpty(input) == true)
            {
                Console.WriteLine("Please enter valid data.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void AddBook(string? bookTitle)
        {
            if (ValidInput(bookTitle) == true)
            {
                libraryStorage.Add(bookTitle, true);
                Console.WriteLine($"Added book {bookTitle} to library");
            }
            else
            {
                Console.WriteLine("Book failed to be added to library system.");
            }
        }

        public static bool FindBook(string? bookTitle)
        {
            if (ValidInput(bookTitle) == true)
            {
                if (libraryStorage.TryGetValue(bookTitle, out bool status))
                {
                    //Console.WriteLine($"Book {bookTitle} found, it is currently {BookStatusNaturalLang(status)}");
                    return true;
                }
                else
                {
                    //Console.WriteLine("Book cannot be found.");
                    return false;
                }
            }
            else
            {
                //Console.WriteLine("failed to find book due to invalid data entered.");
                return false;
            }
        }

        public static void CheckOutBook(string? bookTitle)
        {
            if (ValidInput(bookTitle) == true)
            {
                if (FindBook(bookTitle) == true)
                {
                    if (libraryStorage[bookTitle] == false)
                    {
                        Console.WriteLine("Book has already been checked out.");
                    }
                    else
                    {
                        libraryStorage[bookTitle] = false;
                        Console.WriteLine($"Book {bookTitle} has been checked out.");
                    }
                }
                else
                {
                    Console.WriteLine("Book cannot be found.");
                }
            }
            else
            {
                Console.WriteLine("Book failed to be checked out.");
            }
        }

        public static void ReturnBook(string? bookTitle)
        {
            if (ValidInput(bookTitle) == true)
            {
                if (FindBook(bookTitle) == true)
                {
                    if (libraryStorage[bookTitle] == true)
                    {
                        Console.WriteLine("Book is already in library.");
                    }
                    else
                    {
                        libraryStorage[bookTitle] = true;
                        Console.WriteLine($"Book {bookTitle} has been returned.");
                    }
                }
                else
                {
                    Console.WriteLine("Book cannot be found.");
                }
            }
            else
            {
                Console.WriteLine("Book failed to be returned.");
            }
        }

        public static void GetAvailableBooks()
        {
            Console.WriteLine("Available books: ");
            foreach (var book in libraryStorage)
            {
                if (book.Value == true)
                {
                    Console.WriteLine($"{book.Key}");
                }
            }
        }

        public static void GetCheckedOutBooks()
        {
            Console.WriteLine("Checked out books: ");
            foreach (var book in libraryStorage)
            {
                if (book.Value == false)
                {
                    Console.WriteLine($"{book.Key}");
                }
            }
        }

        public static string BookStatusNaturalLang(bool status)
        {
            return (status == true ? "in library" : "checked out");
        }

        public static void DisplayLibraryStatus()
        {
            Console.WriteLine("Books in Library: ");
            foreach (var book in libraryStorage)
            {
                Console.WriteLine($"Book \"{book.Key}\" is {BookStatusNaturalLang(book.Value)}");
            }
        }

        public static void DisplayOperations()
        {
            Console.WriteLine("1 - Add Book");
            Console.WriteLine("2 - Find Book");
            Console.WriteLine("3 - Check out Book");
            Console.WriteLine("4 - Return Book");
            Console.WriteLine("5 - Get Available Books");
            Console.WriteLine("6 - Get Checked out Books");
            Console.WriteLine("7 - Display Library Status");
            Console.WriteLine("Enter \"quit\" to quit application");
        }

        public static int GetOperation()
        {
            DisplayOperations();

            Console.Write("Enter operation to perform (1 to 7): ");
            string? input = Console.ReadLine();

            if (ValidInput(input) == true)
            {
                if (input.ToLower() != "quit")
                {
                    if (int.TryParse(input, out int choice) == true)
                    {
                        return choice;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static string? GetBookTitle()
        {
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();

            if (ValidInput(title) == true)
            {
                return title;
            }
            else
            {
                return null;
            }
        }

        public static void PerformOperation()
        {
            int choice = -1;
            do
            {
                choice = GetOperation();

                switch (choice)
                {
                    case -1:
                        break;
                    case 1:
                        AddBook(GetBookTitle());
                        break;
                    case 2:
                        FindBook(GetBookTitle());
                        break;
                    case 3:
                        CheckOutBook(GetBookTitle());
                        break;
                    case 4:
                        ReturnBook(GetBookTitle());
                        break;
                    case 5:
                        GetAvailableBooks();
                        break;
                    case 6:
                        GetCheckedOutBooks();
                        break;
                    case 7:
                        DisplayLibraryStatus();
                        break;
                    default:
                        Console.WriteLine("Invalid choice chosen.");
                        break;
                }

                Console.WriteLine();
            } while (choice != -1);
        }
    }
}
