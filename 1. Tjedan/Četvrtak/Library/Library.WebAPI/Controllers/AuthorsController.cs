using Library.Common;
using Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.WebAPI.Controllers
{
    public class AuthorsController : ApiController
    {
        // GET: api/Authors
        [HttpGet]
        public HttpResponseMessage GetAllAuthors()
        {

            //dodati rest model
            var authorsService = new AuthorsService();
            var authorsList = new List<Authors>();

            authorsList = authorsService.GetAllAuthors();

            if (authorsList.Count != 0)
                return Request.CreateResponse<List<Authors>>(HttpStatusCode.OK, authorsList);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }

        // GET: api/Authors/5
        [HttpGet]
        public HttpResponseMessage GetAuthorById(int id)
        {
            /*var authorsService = new AuthorsService();
            var author = new Authors();

            author = authorsService.GetAuthorById(author.AuthorId);

            if (author != null)
                return Request.CreateResponse<Authors>(HttpStatusCode.OK, author);
            else*/
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");
        }

        // POST: api/Authors
        [HttpPost]
        public HttpResponseMessage PostAuthor(Authors author)
        {
 


            if (author == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Author is null");
            }
            else
            {
                AuthorsService authorService = new AuthorsService();
                if (authorService.PostAuthor(author) == true)
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
        public HttpResponseMessage PutCar(int id, [FromBody] string a)
        {
            /* var carTemp = vehicles.FindIndex(x => x.Id == id);


             if (car == null)
             {
                 Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Object not found");
             }

             vehicles[carTemp] = car;


             if (vehicles.Count == 0)
             {
                 Request.CreateErrorResponse(HttpStatusCode.Gone, "List not found");
             }*/

            return Request.CreateResponse<string>(HttpStatusCode.OK, "Content updated");
        }

        // DELETE api/Authors/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            /* var carTemp = vehicles.SingleOrDefault(x => x.Id == id);

             if (carTemp == null)
             {
                 Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vehilce not found");
             }

             vehicles.Remove(carTemp);

             if (vehicles.Count == 0)
             {
                 Request.CreateErrorResponse(HttpStatusCode.Gone, "List not found");
             }*/



            return Request.CreateResponse<string>(HttpStatusCode.OK, "Content updated");
        }
    }
}
