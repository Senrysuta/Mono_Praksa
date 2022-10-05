using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationProject
{
    internal abstract class Shape : IShape
    {
        public List<float> SidesList { get; set; }
        public List<float> AnglesList { get; set; }
        public int NumberOfSides { get; set; }
        public int NumberOfAngles { get; set; }

        public virtual float CalculateArea()
        {
            return SidesList[0] * SidesList[1];
        }

        public float CalculateVolume()
        {
            float volumeTemp = 0;
            foreach (float side in SidesList)
            {
                volumeTemp += side;
            }
            return volumeTemp;
        }

        public void SetValueOfSides(float side)
        {
            SidesList.Add(side);
        }
        public void SetValueOfAngles(float angle)
        {
            AnglesList.Add(angle);
        }
    }
}
