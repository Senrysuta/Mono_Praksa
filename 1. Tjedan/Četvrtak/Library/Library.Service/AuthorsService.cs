using Library.Common;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class AuthorsService
    {
        public List<Authors> GetAllAuthors()
        {
            AuthorsRepository authorsRepository = new AuthorsRepository();
            return authorsRepository.GetAllAuthors(); 
        }

        public Authors GetAuthorById(int id)
        {
            var authorsRepository = new AuthorsRepository();
            return authorsRepository.GetAuthorById(id);
        }

        public bool PostAuthor(Authors author)
        {
            AuthorsRepository authorsRepository = new AuthorsRepository();

            return authorsRepository.PostAuthor(author);

        }


    }
}
