using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.WebAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; } = 0;
        public string Type { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
    }
}