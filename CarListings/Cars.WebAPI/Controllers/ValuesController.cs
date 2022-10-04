using Cars.WebAPI.Models;
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

        static List<Vehicle> vehicles = new List<Vehicle>() 
        {
            new Vehicle(){ Id=1, Type="Car", Mark="BMW", Model="X6"},
            new Vehicle(){ Id=2, Type="Car", Mark="Tesla", Model="S"},
            new Vehicle(){ Id=3, Type="Truck", Mark="Mercedes", Model="Actros"},
            new Vehicle(){ Id=4, Type="Car", Mark="Audi", Model="A6"},
        };
        
        

        // GET api/values
        [HttpGet]
        public HttpResponseMessage GetAllCars()
        {
            if (vehicles.Count != 0)
                return Request.CreateResponse<List<Vehicle>>(HttpStatusCode.OK,vehicles);
            else
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No content");

        }
        [HttpGet]
        public HttpResponseMessage GetCarsById(int id)
        {
            var carTemp = vehicles.SingleOrDefault(x=>x.Id == id);

            if (carTemp == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request");
            else
                return Request.CreateResponse<Vehicle>(HttpStatusCode.OK, carTemp);

        }


        // POST api/values
        [HttpPost]
        public HttpResponseMessage PostCar([FromBody] Vehicle car)
        {
            if (car == null)
            {
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Vehicle is null");
            }

            vehicles.Add(car);

            if (vehicles.Count == 0)
                return Request.CreateResponse<string>(HttpStatusCode.Conflict, "Vehicle not added to list");
            else
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Post successful");

        }

        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage PutCar(int id, [FromBody] Vehicle car)
        {
            var carTemp = vehicles.FindIndex(x => x.Id == id);


            if (car == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Object not found");
            }

            vehicles[carTemp] = car;
            

            if (vehicles.Count == 0)
            {
                Request.CreateErrorResponse(HttpStatusCode.Gone, "List not found");
            }

            return Request.CreateResponse<string>(HttpStatusCode.OK, "Content updated");
        }

        // DELETE api/values/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var carTemp = vehicles.SingleOrDefault(x => x.Id == id);

            if (carTemp == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.NotFound, "Vehilce not found");
            }

            vehicles.Remove(carTemp);

            if (vehicles.Count == 0)
            {
                Request.CreateErrorResponse(HttpStatusCode.Gone, "List not found");
            }



            return Request.CreateResponse<string>(HttpStatusCode.OK, "Content updated");
        }
    }
}
