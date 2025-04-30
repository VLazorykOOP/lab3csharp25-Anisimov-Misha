using System;

class Point
{
    protected int x, y;  
    protected int c;    

    public Point()
    {
        x = 0;
        y = 0;
        c = 0;
    }

    public Point(int x, int y, int c)
    {
        this.x = x;
        this.y = y;
        this.c = c;
    }

    // Метод для виведення координат точки на екран
    public void PrintCoordinates()
    {
        Console.WriteLine($"Point coordinates: ({x}, {y})");
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Move(int x1, int y1)
    {
        x += x1;
        y += y1;
    }

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }
  
    public int Color
    {
        get { return c; }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Point[] points = new Point[]
            {
                new Point(1, 2, 1),
                new Point(3, 4, 2),
                new Point(5, 6, 3),
                new Point(7, 8, 4)
            };

            double totalDistance = 0;
            foreach (var point in points)
            {
                totalDistance += point.DistanceFromOrigin();
            }
            double averageDistance = totalDistance / points.Length;

            // Виведення інформації про точки та переміщення точок, відстань до яких більша за середню
            Console.WriteLine("Points information:");
            foreach (var point in points)
            {
                point.PrintCoordinates();
                double distance = point.DistanceFromOrigin();
                Console.WriteLine($"Distance from origin: {distance}");
                if (distance > averageDistance)
                {
                    Console.WriteLine("Moving point...");
                    point.Move(2, 3); 
                    point.PrintCoordinates();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
