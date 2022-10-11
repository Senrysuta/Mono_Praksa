using Library.Model;
using Library.Repository;
using Library.Repository.Common;
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

        IAuthorRepositoryCommon _authorRepository;
        public AuthorService(IAuthorRepositoryCommon authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthorsAsync(); 
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task<bool> PostAuthorAsync(Author author)
        {
            return await _authorRepository.PostAuthorAsync(author);
        }

        public async Task<bool> DeleteAuthorByIdAsync(int id)
        {
            return await _authorRepository.DeleteAuthorByIdAsync(id);
        }

        public async Task<bool> UpdateAuthorAsync(int id, Author author)
        {
            Author authorTemp = new Author();
            authorTemp = await _authorRepository.GetAuthorByIdAsync(id);

            if (author.FirstName == null || author.FirstName == "")
            {
                author.FirstName = authorTemp.FirstName;
            }
            else if(author.LastName == null || author.LastName == "")
            {
                author.LastName = authorTemp.LastName;
            }

            return await _authorRepository.UpdateAuthorAsync(id,author);
        }


    }
}
