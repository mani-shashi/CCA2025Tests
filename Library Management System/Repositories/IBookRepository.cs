using Library_Management_System.Models;

namespace Library_Management_System.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();

        public Book GetBookById(int id);

        public void AddBook(Book book);

        public void DeleteBook(int id);
    }
}
