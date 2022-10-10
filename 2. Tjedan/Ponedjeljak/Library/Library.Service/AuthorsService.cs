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
    public class AuthorService : IAuthorServiceCommon
    {
        AuthorRepository authorRepository = new AuthorRepository();
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await authorRepository.GetAllAuthorsAsync(); 
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task<bool> PostAuthorAsync(Author author)
        {
            return await authorRepository.PostAuthorAsync(author);
        }

        public async Task<bool> DeleteAuthorByIdAsync(int id)
        {
            return await authorRepository.DeleteAuthorByIdAsync(id);
        }

        public async Task<bool> UpdateAuthorAsync(int id, Author author)
        {
            Author authorTemp = new Author();
            authorTemp = await authorRepository.GetAuthorByIdAsync(id);

            if (author.FirstName == null || author.FirstName == "")
            {
                author.FirstName = authorTemp.FirstName;
            }
            else if(author.LastName == null || author.LastName == "")
            {
                author.LastName = authorTemp.LastName;
            }

            return await authorRepository.UpdateAuthorAsync(id,author);
        }


    }
}
