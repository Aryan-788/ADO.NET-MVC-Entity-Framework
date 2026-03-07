using LibrarySystem_RepositoryPattern.Models;
using LibrarySystem_RepositoryPattern.Models;
using System.Collections.Generic;

namespace LibrarySystem_RepositoryPattern.Repositories
{
    public class BookRepository : IBookRepository
    {
        private Dictionary<int, Book> _books = new Dictionary<int, Book>()
        {
            {1, new Book { Id = 1, BookName = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 100 } },
            { 2, new Book { Id = 2, BookName = "To Kill a Mockingbird", Author= "Harper Lee", Price = 120  } },
            { 3, new Book { Id = 3, BookName = "1984", Author = "George Orwell", Price = 150 } },
             { 4, new Book { Id = 4, BookName = "The Catcher in the Rye", Author = "J.D. Salinger", Price = 80 } },
              { 5, new Book { Id = 5, BookName = "Pride and Prejudice", Author = "Jane Austen", Price = 90 } }
        };

        public void AddBook(Book book)
        {
            _books[book.Id] = book;
            Console.WriteLine($"Book with Name {book.BookName} added to the repository.");
        }

        public List<Book> ListAllBook()
        {
            return _books.Values.ToList();
        }

        public List<Book> ListBookByName(string bookName)
        {
            return _books.Values.Where(b => b.BookName == bookName).ToList();
        }

        public List<Book> ListBookByPrice(int price)
        {
            return _books.Values.Where(b => b.Price >= price).ToList();
        }

        
    }
}
