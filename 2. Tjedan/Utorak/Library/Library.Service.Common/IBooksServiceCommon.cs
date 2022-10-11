using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
    public interface IBookServiceCommon
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<List<Book>> FindAsync(int PageNumber, int PageSize);
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> PostBookAsync(Book book);
        Task<bool> DeleteBookByIdAsync(int id);
        Task<bool> UpdateBookAsync(int id, Book book);

    }
}
