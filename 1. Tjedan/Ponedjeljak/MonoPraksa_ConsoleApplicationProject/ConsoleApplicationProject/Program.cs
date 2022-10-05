using ConsoleApplicationProject;

Square square = new Square();

List<float> squareSideList = new List<float>();
List<float> triangleSideList = new List<float>();
Triangle triangle = new Triangle(5);

Console.WriteLine($"Write down lenght of all sides in a square:\n");

for (int i = 0; i < square.NumberOfSides; i++)
{
    squareSideList.Add((float)Convert.ToDecimal(Console.ReadLine()));
}

Console.WriteLine($"\nWrite down lenght of all sides in a triangle");

for (int i = 0; i < triangle.NumberOfSides; i++)
{
    triangleSideList.Add((float)Convert.ToDecimal(Console.ReadLine()));
}

square.SidesList = squareSideList;
triangle.SidesList = triangleSideList;


Console.WriteLine($"\nArea of a square is: {square.CalculateArea()}\n" +
    $"Volume of a square is: {square.CalculateVolume()}\n" +
    $"\nArea of a triangle is: {triangle.CalculateArea()}\n" +
    $"Volume of a triangle is: {triangle.CalculateVolume()}");
