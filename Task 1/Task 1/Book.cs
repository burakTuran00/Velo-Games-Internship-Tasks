using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public int NumberOfCopies { get; set; }
        public int BorrowedCopies { get; set; }
        public DateTime BorrowedDate { get; set; }

        public Book(string title, string author, int isbn, int numberOfCopies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            NumberOfCopies = numberOfCopies;
            BorrowedCopies = 0;
        }
    }
}
