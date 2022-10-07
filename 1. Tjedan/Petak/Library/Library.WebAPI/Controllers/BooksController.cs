using Library.Common;
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
    public class BooksController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllBooksAsync()
        {

            //dodati rest model
            var booksService = new BooksService();
            var booksList = new List<Books>();

            booksList = await booksService.GetAllBooksAsync();
            
            if (booksList.Count != 0)
                return Request.CreateResponse<List<Books>>(HttpStatusCode.OK, booksList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }

        // GET: api/Authors/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetBookByIdAsync(int id)
        {
            var booksService = new BooksService();


            if (booksService.GetBookByIdAsync(id) != null)
                return Request.CreateResponse<Books>(HttpStatusCode.OK, await booksService.GetBookByIdAsync(id));
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<HttpResponseMessage> PostAuthorAsync(Books book)
        {

            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book is null");
            }
            else
            {
                BooksService booksService = new BooksService();
                if (await booksService.PostBookAsync(book) == true)
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
        public async Task<HttpResponseMessage> UpdateAuthorAsync(int id, [FromBody] Books book)
        {
            BooksService booksService = new BooksService();
            if (await booksService.UpdateBookAsync(id, book) == true)
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
            BooksService booksService = new BooksService();
            if (await booksService.DeleteBookByIdAsync(id) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully Deleted.");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book doesn't exist.");
            }
        }
    }
}
