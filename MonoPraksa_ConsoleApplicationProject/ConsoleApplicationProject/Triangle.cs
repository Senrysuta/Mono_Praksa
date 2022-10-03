using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationProject
{
    internal class Triangle:Shape
    {
        private float Height { get; set; }
        public Triangle(float height)
        {
            NumberOfSides = 3;
            Height = height;
        }

        public override float CalculateArea()
        {
            return ((SidesList[0] * Height) /2);
        }

    }
}
