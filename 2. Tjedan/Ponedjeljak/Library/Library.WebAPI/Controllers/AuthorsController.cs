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
    public class AuthorController : ApiController
    {
        AuthorService authorService = new AuthorService();
        // GET: api/Authors
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAuthorsAsync()
        {

            var authorsList = new List<Author>();
            var authorsRestList = new List<AuthorRest>();

            authorsList =  await authorService.GetAllAuthorsAsync();
            authorsRestList = MapToRestList(authorsList);

            if (authorsRestList.Count != 0)
                return Request.CreateResponse<List<AuthorRest>>(HttpStatusCode.OK, authorsRestList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }

        // GET: api/Authors/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetAuthorByIdAsync(int id)
        {
            Author author = await authorService.GetAuthorByIdAsync(id);
            AuthorRest authorRest = new AuthorRest();

            authorRest = MapToRest(author);

            if (authorRest != null)
                return Request.CreateResponse<AuthorRest>(HttpStatusCode.OK, authorRest);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<HttpResponseMessage> PostAuthorAsync(AuthorRest authorRest)
        {


            if (authorRest == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Author is null");
            }
            else
            {
                Author author = new Author();
                author = MapToModel(authorRest);
                if (await authorService.PostAuthorAsync(author) == true)
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
        public async Task<HttpResponseMessage> UpdateAuthorAsync(int id, [FromBody] AuthorRest authorRest)
        {
            Author author = new Author();
            author = MapToModel(authorRest);


            if (await authorService.UpdateAuthorAsync(id,author) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully Edited.");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Author doesn't exist.");
            }
        }

        // DELETE api/Authors/5
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAuthorByIdAsync(int id)
        {
            if (await authorService.DeleteAuthorByIdAsync(id) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully Deleted.");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Author doesn't exist.");
            }
        }

        private List<AuthorRest> MapToRestList(List<Author> authorsList)
        {
            List<AuthorRest> authorRestsList = new List<AuthorRest>();
            

            foreach (Author author in authorsList)
            {
                authorRestsList.Add(new AuthorRest(author.AuthorId, author.FirstName, author.LastName));
            }

            return authorRestsList;
        }

        private AuthorRest MapToRest(Author author)
        {
            return new AuthorRest(author.AuthorId, author.FirstName, author.LastName);
        }

        private Author MapToModel(AuthorRest authorRest)
        {
            return new Author(authorRest.AuthorId, authorRest.FirstName, authorRest.LastName);
        }
    }
}
