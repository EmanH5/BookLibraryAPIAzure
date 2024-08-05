using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public static class BookRepository
    {
        private static readonly List<Book> Books = new List<Book>
    {
        new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 }
    };

        public static List<Book> GetBooks() => Books;

        public static Book GetBookById(int id) => Books.FirstOrDefault(b => b.Id == id);

        public static void AddBook(Book book)
        {
            // Determine the new ID (increment the highest existing ID)
            int newId = Books.Any() ? Books.Max(b => b.Id) + 1 : 1;
            book.Id = newId;
            Books.Add(book);
        }

        public static void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Year = book.Year;
            }
        }

        public static void DeleteBook(int id) => Books.RemoveAll(b => b.Id == id);
    }

}
