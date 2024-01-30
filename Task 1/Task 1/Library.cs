using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Library
    {
        private List<Book> books;

        private const int MAX_BORROW_DATE = 7;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            bool isAlreadyExist = false;

            foreach(var b in books)
            {
                isAlreadyExist = (b.ISBN != book.ISBN) ? false : true;
            }
            
            if(!isAlreadyExist)
            {
                books.Add(book);
                Console.WriteLine("Book added successfully.");
            }
            else
            {
                Console.WriteLine("Already Exist...");
            }
        }

        public void DisplayAllBooks()
        {
            Console.Clear();
            
            if(books.Count < 1)
            {
                Console.WriteLine("Library doesn't contain any book!");
                return;
            }

            Console.WriteLine("------------------------ All Books ------------------------");

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i] != null)
                {
                    PrintBookInfo(i);
                }
            }

            Console.WriteLine("------------------------ All Books ------------------------");
        }
      
        public void SearchBook(int isbn)
        {
            int index = SearchHelper(books, isbn);

            if(index >= 0)
            {
                PrintBookInfo(index);
            }
            else
            {
                Console.WriteLine("No matching books found.");
            }
        }

        public static int SearchHelper(List<Book> books, int searchingISBN)
        {
            for(int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == searchingISBN)
                {
                    return i;
                }
            }

            return -1;
        }

        public void BorrowBook(int isbn)
        {
            int index = SearchHelper(books, isbn);

            if (books[index] != null && books[index].NumberOfCopies > books[index].BorrowedCopies)
            {
                books[index].BorrowedCopies++;
                books[index].BorrowedDate = DateTime.Now;
                Console.WriteLine($"{books[index].Title} borrowed successfully. Remaining copies: {books[index].NumberOfCopies - books[index].BorrowedCopies}");
            }
            else
            {
                Console.WriteLine("Book could not be borrowed.");
            }
        }

        public void ReturnBook(int isbn)
        {
            int index = SearchHelper(books, isbn);

            if (books[index] != null && books[index].BorrowedCopies > 0)
            {
                books[index].BorrowedCopies--;
                books[index].BorrowedDate = DateTime.MinValue;
                PrintBookInfo(index);
            }
            else
            {
                Console.WriteLine("Book could not be returned.");
            }
        }

        public void DisplayOverdueBooks()
        {
            Console.WriteLine("------------------------ Overdue Books ------------------------");

            for (int i = 0; i < books.Count; i++)
            {
                int day = books[i].BorrowedDate.Day - DateTime.Now.Day;

                if(day > MAX_BORROW_DATE)
                {
                    PrintBookInfo(i);
                }
            }

            Console.WriteLine("------------------------ Overdue Books ------------------------");
        }

        public void PrintBookInfo(int index)
        {
            Console.WriteLine ($"Title: {books[index].Title} - Author: {books[index].Author} - ISBN: {books[index].ISBN} - Copies: {books[index].NumberOfCopies} - Borrowed: {books[index].BorrowedCopies}");

        }
    }
}
