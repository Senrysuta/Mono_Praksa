using AutoMapper;
using Library.Common;
using Library.Common.Common;
using Library.Model;
using Library.Service;
using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.WebAPI.Controllers
{
    public class BookController : ApiController
    {

        IBookServiceCommon _bookService;
        IMapper _mapper;
        
        public BookController(IBookServiceCommon bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }


        /*[HttpGet]
        public async Task<HttpResponseMessage> GetAllBooksAsync()
        {


            var bookList = new List<Book>();
            var bookRestList = new List<BookRest>();

            bookList = await _bookService.GetAllBooksAsync();
            bookRestList = _mapper.Map<List<BookRest>>(bookList);

            if (bookRestList.Count != 0)
                return Request.CreateResponse<List<BookRest>>(HttpStatusCode.OK, bookRestList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }*/

        [HttpGet]
        public async Task<HttpResponseMessage> FindAsync(int pageNumber = 1, int pageSize = 2)
        {
            var bookList = new List<Book>();
            var bookRestList = new List<BookRest>();

            bookList = await _bookService.FindAsync(pageNumber,pageSize);
            bookRestList = _mapper.Map<List<BookRest>>(bookList);

            if (bookRestList.Count != 0)
                return Request.CreateResponse<List<BookRest>>(HttpStatusCode.OK, bookRestList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // GET: api/Authors/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetBookByIdAsync(int id)
        {
            Book book = await _bookService.GetBookByIdAsync(id);
            BookRest bookRest = _mapper.Map<BookRest>(book);

            if (bookRest != null)
                return Request.CreateResponse<BookRest>(HttpStatusCode.OK, bookRest);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<HttpResponseMessage> PostAuthorAsync(BookRest bookRest)
        {

            if (bookRest == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book is null");
            }
            else
            {
                Book book = new Book();
                book = _mapper.Map<Book>(bookRest);
                if (await _bookService.PostBookAsync(book) == true)
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


            Book book = new Book();
            book = _mapper.Map<Book>(bookRest);


            if (await _bookService.UpdateBookAsync(id, book) == true)
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
            if (await _bookService.DeleteBookByIdAsync(id) == true)
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
                bookRestsList.Add(_mapper.Map<BookRest>(book));
            }

            return bookRestsList;
        }

    }
}
