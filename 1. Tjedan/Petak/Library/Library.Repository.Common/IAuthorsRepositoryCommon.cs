using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IAuthorsRepositoryCommon
    {
        Task<List<Authors>> GetAllAuthorsAsync();
        Task<Authors> GetAuthorByIdAsync(int id);
        Task<bool> PostAuthorAsync(Authors author);
        Task<bool> DeleteAuthorByIdAsync(int id);
        Task<bool> UpdateAuthorAsync(int id, Authors author);


    }
}
