using LibrarySystem_RepositoryPattern.Data;
using LibrarySystem_RepositoryPattern.Models;

namespace LibrarySystem_RepositoryPattern.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public SQLBookRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> ListAllBook()
        {
            return _context.Books.ToList();
        }

        public List<Book> ListBookByName(string bookName)
        {
            return _context.Books.Where(b => b.BookName == bookName).ToList();
        }

        public List<Book> ListBookByPrice(int price)
        {
            return _context.Books.Where(b => b.Price >= price).ToList();
        }
    }
}
