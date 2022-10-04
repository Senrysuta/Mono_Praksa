using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace Cars.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        static List<string> cars = new List<string>();
        
        

        // GET api/values
        [HttpGet]
        public HttpResponseMessage GetAllCars()
        {
            if (cars != null)
                return Request.CreateResponse<List<string>>(HttpStatusCode.OK,cars);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }


        // POST api/values
        [HttpPost]
        public HttpResponseMessage PostCar([FromBody] string model)
        {
            cars.Add(model);

            if (cars.Contains(model))
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Post successful");
            else
                return Request.CreateResponse<string>(HttpStatusCode.NoContent, "No content found");

        }

        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage PutCar(int id, [FromBody] string model)
        {
            cars[id] = model;

            if (id == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No id.");
            }

            return Request.CreateResponse<string>(HttpStatusCode.OK, "Content updated");
        }

        // DELETE api/values/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            cars.RemoveAt(id);

            if (id == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No id.");
            }

            return Request.CreateResponse<string>(HttpStatusCode.OK, "Content updated");


        }
    }
}
