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
    public class AuthorsController : ApiController
    {
        AuthorsService authorsService = new AuthorsService();
        // GET: api/Authors
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAuthorsAsync()
        {

            //dodati rest model
            
            var authorsList = new List<Authors>();
            var authorsRestList = new List<AuthorsRest>();

            authorsList =  await authorsService.GetAllAuthorsAsync();

            if (authorsList.Count != 0)
                return Request.CreateResponse<List<AuthorsRest>>(HttpStatusCode.OK, authorsRestList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }

        // GET: api/Authors/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetAuthorByIdAsync(int id)
        {
            if (authorsService.GetAuthorByIdAsync(id) != null)
                return Request.CreateResponse<Authors>(HttpStatusCode.OK, await authorsService.GetAuthorByIdAsync(id));
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<HttpResponseMessage> PostAuthorAsync(/*AuthorsRest authorRest*/ Authors author)
        {

            /*var author = new Authors(authorRest.AuthorId, "",authorRest.LastName);*/

            if (author == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Author is null");
            }
            else
            {
                if (await authorsService.PostAuthorAsync(author) == true)
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
        public async Task<HttpResponseMessage> UpdateAuthorAsync(int id, [FromBody] Authors author)
        {
            if (await authorsService.UpdateAuthorAsync(id,author) == true)
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
            if (await authorsService.DeleteAuthorByIdAsync(id) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Successfully Deleted.");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Author doesn't exist.");
            }
        }
    }
}
