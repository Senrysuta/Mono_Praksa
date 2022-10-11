using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IBookRepositoryCommon
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> FindAsync(int pageNumber, int pageSize);
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> PostBookAsync(Book book);
        Task<bool> DeleteBookByIdAsync(int id);
        Task<bool> UpdateBookAsync(int id, Book book);

    }
}
