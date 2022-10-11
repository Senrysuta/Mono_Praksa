using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IAuthorRepositoryCommon
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<bool> PostAuthorAsync(Author author);
        Task<bool> DeleteAuthorByIdAsync(int id);
        Task<bool> UpdateAuthorAsync(int id, Author author);


    }
}
