using Library.Common;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class BookService
    {
        BookRepository bookRepository = new BookRepository();
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await bookRepository.GetBookByIdAsync(id);
        }

        public async Task<bool> PostBookAsync(Book book)
        {
            return await bookRepository.PostBookAsync(book);
        }

        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            return await bookRepository.DeleteBookByIdAsync(id);
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            return await bookRepository.UpdateBookAsync(id,book);
        }
    }
}
