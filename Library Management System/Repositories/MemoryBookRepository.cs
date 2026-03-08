using Library_Management_System.Models;

namespace Library_Management_System.Repositories{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly List<Book> booksList;

        public MemoryBookRepository()
        {
            booksList = new List<Book>
            {
                new Book{ BookId = 111, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Price = 2199},
                new Book{ BookId = 112, Title = "The Psychopathology of Everyday Life", Author = "Sigmund Freud", Price = 2699},
                new Book{ BookId = 113, Title = "The Metamorphosis ", Author = "Franz Kafka", Price = 1899}
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
          return booksList;   
        }

        public Book GetBookById(int id)
        {
            return booksList.FirstOrDefault(b => b.BookId.equals(id));
        }

        public void AddBook(Book book)
        {
            booksList.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = booksList.FirstOrDefault(b => b.BookId.equals(id));
            if (book != null) booksList.Remove(book);
        }
    }
}