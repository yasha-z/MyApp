using System.Collections.Generic;
using System.Linq;

namespace Session1
{
    // TASK 2.2 — Service methods are async; in-memory work uses Task.FromResult / Task.CompletedTask
    public class BookService : IBookService
    {
        public Task<List<Book>> GetAllAsync()
        {
            return Task.FromResult(InMemoryStore.Books);
        }

        public Task<Book> GetByIdAsync(int id)
        {
            var book = InMemoryStore.Books
                .FirstOrDefault(b => b.Id == id);

            // TASK 2.5 — Throw custom exception when book is not found
            if (book is null)
            {
                throw new BookNotFoundException(id);
            }

            return Task.FromResult(book);
        }

        public Task CreateAsync(Book book)
        {
            InMemoryStore.Books.Add(book);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Book updatedBook)
        {
            var book = InMemoryStore.Books
                .FirstOrDefault(b => b.Id == updatedBook.Id);

            if (book is not null)
            {
                book.Title = updatedBook.Title;
                book.Year = updatedBook.Year;
                book.PageCount = updatedBook.PageCount;
                book.AuthorId = updatedBook.AuthorId;
                book.Author = updatedBook.Author;
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var book = InMemoryStore.Books
                .FirstOrDefault(b => b.Id == id);

            if (book is not null)
            {
                InMemoryStore.Books.Remove(book);
            }

            return Task.CompletedTask;
        }
    }
}
