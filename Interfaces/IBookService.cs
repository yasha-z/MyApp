using System.Collections.Generic;

namespace Session1
{
    // TASK 2.2 — Interface methods are async and return Task<T>
    //in sesson 1 they werent async NOW they are async
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
