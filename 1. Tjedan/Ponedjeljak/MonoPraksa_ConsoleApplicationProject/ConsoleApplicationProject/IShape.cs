using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationProject
{
    internal interface IShape
    {
        List<float> SidesList { get; set; }
        List<float> AnglesList { get; set; }
        int NumberOfSides { get; set; }
        int NumberOfAngles { get; set; }


        float CalculateArea();
        float CalculateVolume();
        void SetValueOfSides(float side);
        void SetValueOfAngles(float angle);
    }
}
