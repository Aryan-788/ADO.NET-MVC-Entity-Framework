using LibrarySystem_RepositoryPattern.Models;

namespace LibrarySystem_RepositoryPattern.Repositories
{
    public interface IBookRepository
    {
        List<Book> ListAllBook();
        List<Book> ListBookByName(string bookName);
        List<Book> ListBookByPrice(int price);
        void AddBook(Book book);
        


    }
}
