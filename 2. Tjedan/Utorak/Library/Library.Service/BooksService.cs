using Library.Model;
using Library.Repository;
using Library.Repository.Common;
using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class BookService : IBookServiceCommon
    {
        IBookRepositoryCommon _bookRepository;
        public BookService(IBookRepositoryCommon bookRepository)
        {
            _bookRepository = bookRepository;          
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<List<Book>> FindAsync(int pageNumber, int pageSize)
        {
            return await _bookRepository.FindAsync(pageNumber, pageSize);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<bool> PostBookAsync(Book book)
        {
            return await _bookRepository.PostBookAsync(book);
        }

        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            return await _bookRepository.DeleteBookByIdAsync(id);
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            Book bookTemp = new Book();
            bookTemp = await _bookRepository.GetBookByIdAsync(id);

            if (book.Title == null || book.Title == "")
            {
                book.Title = bookTemp.Title;
            }
            else if(book.PublishYear == 0)
            {
                book.PublishYear = bookTemp.PublishYear;
            }
            else if(book.OriginalLanguage == null || book.OriginalLanguage == "")
            {
                book.OriginalLanguage = bookTemp.OriginalLanguage;
            }
            else if(book.ISBN == null || book.ISBN == "")
            {
                book.ISBN = bookTemp.ISBN;
            }


            return await _bookRepository.UpdateBookAsync(id,book);
        }
    }
}
