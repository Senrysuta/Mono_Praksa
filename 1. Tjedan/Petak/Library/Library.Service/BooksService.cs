using Library.Common;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class BooksService
    {
        public async Task<List<Books>> GetAllBooksAsync()
        {
            BooksRepository booksRepository = new BooksRepository();
            return await booksRepository.GetAllBooksAsync();
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            var booksRepository = new BooksRepository();
            return await booksRepository.GetBookByIdAsync(id);
        }

        public async Task<bool> PostBookAsync(Books book)
        {
            BooksRepository booksRepository = new BooksRepository();
            return await booksRepository.PostBookAsync(book);

        }

        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            BooksRepository booksRepository = new BooksRepository();
            return await booksRepository.DeleteBookByIdAsync(id);
        }

        public async Task<bool> UpdateBookAsync(int id, Books book)
        {
            BooksRepository booksRepository = new BooksRepository();
            return await booksRepository.UpdateBookAsync(id,book);
        }
    }
}
