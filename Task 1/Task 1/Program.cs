using Task_1;

class Program
{
    private static void Main(string[] args) 
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n1. Add New Book");
            Console.WriteLine("2. Display All Books");
            Console.WriteLine("3. Search for a Book");
            Console.WriteLine("4. Borrow a Book");
            Console.WriteLine("5. Return a Book");
            Console.WriteLine("6. Display Overdue Books");
            Console.WriteLine("7. Exit");

            Console.Write("\n-> Select an action (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    Console.Write("Book Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Author: ");
                    string author = Console.ReadLine();

                    Console.Write("ISBN: ");
                    int isbn = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Number of Copies: ");
                    int numberOfCopies = Convert.ToInt32(Console.ReadLine());

                    Book newBook = new Book(title, author, isbn, numberOfCopies);
                    library.AddBook(newBook);

                    break;

                case "2":
                    library.DisplayAllBooks();
                    break;

                case "3":
                    Console.Write("Search with ISBN: ");
                    int searchKeyword = Convert.ToInt32(Console.ReadLine());

                    library.SearchBook(searchKeyword);
                    break;

                case "4":
                    Console.Write("Enter ISBN of the book to borrow: ");
                    int borrowIsbn = Convert.ToInt32(Console.ReadLine());

                    library.BorrowBook(borrowIsbn);
                    break;

                case "5":
                    Console.Write("Enter ISBN of the book to return: ");
                    int returnIsbn = Convert.ToInt32(Console.ReadLine());
                    library.ReturnBook(returnIsbn);
                    break;

                case "6":
                    library.DisplayOverdueBooks();
                    break;

                case "7":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void ClearScene()
    {
        Console.Clear();
    }
}