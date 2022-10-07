using Library.Common;
using Library.Repository;
using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class AuthorsService : IAuthorsServiceCommon
    {
        AuthorsRepository authorsRepository = new AuthorsRepository();
        public async Task<List<Authors>> GetAllAuthorsAsync()
        {
            return await authorsRepository.GetAllAuthorsAsync(); 
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            return await authorsRepository.GetAuthorByIdAsync(id);
        }

        public async Task<bool> PostAuthorAsync(Authors author)
        {
            return await authorsRepository.PostAuthorAsync(author);
        }

        public async Task<bool> DeleteAuthorByIdAsync(int id)
        {
            return await authorsRepository.DeleteAuthorByIdAsync(id);
        }

        public async Task<bool> UpdateAuthorAsync(int id, Authors author)
        {
            return await authorsRepository.UpdateAuthorAsync(id,author);
        }


    }
}
