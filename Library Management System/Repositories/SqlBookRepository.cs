using Library_Management_System.Models;

namespace Library_Management_System.Repositories{
    public class SqlBookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public SqlBookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(Book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }        
    }
}