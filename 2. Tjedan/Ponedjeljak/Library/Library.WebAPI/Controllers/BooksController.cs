using Library.Common;
using Library.Model;
using Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Library.WebAPI.Controllers
{
    public class BookController : ApiController
    {
        BookService bookService = new BookService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllBooksAsync()
        {

            var bookList = new List<Book>();
            var bookRestList = new List<BookRest>();

            bookList = await bookService.GetAllBooksAsync();
            bookRestList = MapToRestList(bookList);

            if (bookRestList.Count != 0)
                return Request.CreateResponse<List<BookRest>>(HttpStatusCode.OK, bookRestList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }

        // GET: api/Authors/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetBookByIdAsync(int id)
        {
            Book book = await bookService.GetBookByIdAsync(id);
            BookRest bookRest = new BookRest();

            bookRest = MapToRest(book);

            if (bookRest != null)
                return Request.CreateResponse<BookRest>(HttpStatusCode.OK, bookRest);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<HttpResponseMessage> PostAuthorAsync(Book book)
        {

            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book is null");
            }
            else
            {
                if (await bookService.PostBookAsync(book) == true)
                {
                    return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully added.");

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request.");
                }
            }

        }

        // PUT: api/Authors/5
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateAuthorAsync(int id, [FromBody] BookRest bookRest)
        {

            //add logic for null variables

            Book book = new Book();
            book = MapToModel(bookRest);


            if (await bookService.UpdateBookAsync(id, book) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully Edited.");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book doesn't exist.");
            }
        }

        // DELETE api/Authors/5
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAuthorByIdAsync(int id)
        {
            if (await bookService.DeleteBookByIdAsync(id) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully Deleted.");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book doesn't exist.");
            }
        }

        private List<BookRest> MapToRestList(List<Book> bookList)
        {
            List<BookRest> bookRestsList = new List<BookRest>();


            foreach (Book book in bookList)
            {
                bookRestsList.Add(new BookRest(book.BookId, book.AuthorId, book.Title, book.PublishYear, book.OriginalLanguage, book.ISBN));
            }

            return bookRestsList;
        }

        private BookRest MapToRest(Book book)
        {
            return new BookRest(book.BookId, book.AuthorId, book.Title, book.PublishYear, book.OriginalLanguage, book.ISBN);
        }

        private Book MapToModel(BookRest bookRest)
        {
            return new Book(bookRest.BookId, bookRest.AuthorId, bookRest.Title, bookRest.PublishYear, bookRest.OriginalLanguage, bookRest.ISBN);
        }

    }
}
