using System.Collections.Generic;

namespace Session1
{
    // TASK 2.2 — Interface methods are async and return Task<T>
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
