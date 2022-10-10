using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Common
{
    public interface IAuthorServiceCommon
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<bool> PostAuthorAsync(Author author);
        Task<bool> DeleteAuthorByIdAsync(int id);
        Task<bool> UpdateAuthorAsync(int id, Author author);

    }
}
