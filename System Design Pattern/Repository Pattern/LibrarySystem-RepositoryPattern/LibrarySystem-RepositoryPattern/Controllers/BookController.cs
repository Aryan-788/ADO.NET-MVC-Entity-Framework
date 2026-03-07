using LibrarySystem_RepositoryPattern.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem_RepositoryPattern.Models;

namespace LibrarySystem_RepositoryPattern.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.ListAllBook();

            List<string> bookDetails = books.Select(b => $"Id: {b.Id}, Name: {b.BookName}, Author: {b.Author}, Price: {b.Price}").ToList();
            return Content(string.Join("\n", bookDetails));

        }
        public IActionResult Add()
        {
            var newBook = new Book
            {
                //Id = 6,
                BookName = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                Price = 20
            };
            _bookRepository.AddBook(newBook);
            return Content($"Book '{newBook.BookName}' added successfully.");

        }

        public IActionResult GetBookByName()
        {
            string bookName = "The Great Gatsby";
            var books = _bookRepository.ListBookByName(bookName);
            if (books.Count == 0)
            {
                return Content($"No books found with the name '{bookName}'.");
            }
            List<string> bookDetails = books.Select(b => $"Id: {b.Id}, Name: {b.BookName}, Author: {b.Author}, Price: {b.Price}").ToList();
            return Content(string.Join("\n", bookDetails));

        }

        public IActionResult GetBooksByPrice()
        {
            int price = 100;
            var books = _bookRepository.ListBookByPrice(price);
            if (books.Count == 0)
            {
                return Content($"No books found with a price greater than or equal to {price}.");
            }
            List<string> bookDetails = books.Select(b => $"Id: {b.Id}, Name: {b.BookName}, Author: {b.Author}, Price: {b.Price}").ToList();
            return Content(string.Join("\n", bookDetails));
        }
    }
}
