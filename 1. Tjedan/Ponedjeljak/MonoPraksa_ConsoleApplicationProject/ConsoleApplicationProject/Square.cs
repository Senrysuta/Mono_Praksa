using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationProject
{
    internal class Square:Shape
    {
        public Square()
        {
            NumberOfSides = 4;
        }

        public override float CalculateArea()
        {
            return SidesList[0] * SidesList[1];
        }

    }
}
