using Library.Common;
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

        Task<List<Book>> FindAsync(Paging pager, Filtering filter, Sorting sorting);
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> PostBookAsync(Book book);
        Task<bool> DeleteBookByIdAsync(int id);
        Task<bool> UpdateBookAsync(int id, Book book);

    }
}
