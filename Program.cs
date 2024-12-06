using System;

interface IShape
{
    void SetCoordinates();
    void DisplayCoordinates();
}

class Triangle : IShape
{
    protected double x1, y1, x2, y2, x3, y3;

    public void SetCoordinates()
    {
        Console.WriteLine("Введіть координати першої точки трикутника (x1, y1): ");
        x1 = Convert.ToDouble(Console.ReadLine());
        y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати другої точки трикутника (x2, y2): ");
        x2 = Convert.ToDouble(Console.ReadLine());
        y2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати третьої точки трикутника (x3, y3): ");
        x3 = Convert.ToDouble(Console.ReadLine());
        y3 = Convert.ToDouble(Console.ReadLine());
    }

    public void DisplayCoordinates()
    {
        Console.WriteLine($"Координати трикутника: A({x1}, {y1}), B({x2}, {y2}), C({x3}, {y3})");
    }

    public double CalculateArea()
    {
        double area = Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        return area;
    }
}

class Tetrahedron : IShape
{
    protected double x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4;

    public void SetCoordinates()
    {
        Console.WriteLine("Введіть координати першої вершини тетраедра (x1, y1, z1): ");
        x1 = Convert.ToDouble(Console.ReadLine());
        y1 = Convert.ToDouble(Console.ReadLine());
        z1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати другої вершини тетраедра (x2, y2, z2): ");
        x2 = Convert.ToDouble(Console.ReadLine());
        y2 = Convert.ToDouble(Console.ReadLine());
        z2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати третьої вершини тетраедра (x3, y3, z3): ");
        x3 = Convert.ToDouble(Console.ReadLine());
        y3 = Convert.ToDouble(Console.ReadLine());
        z3 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати четвертої вершини тетраедра (x4, y4, z4): ");
        x4 = Convert.ToDouble(Console.ReadLine());
        y4 = Convert.ToDouble(Console.ReadLine());
        z4 = Convert.ToDouble(Console.ReadLine());
    }

    public void DisplayCoordinates()
    {
        Console.WriteLine($"Координати тетраедра: A({x1}, {y1}, {z1}), B({x2}, {y2}, {z2}), C({x3}, {y3}, {z3}), D({x4}, {y4}, {z4})");
    }

    public double CalculateVolume()
    {
        double volume = Math.Abs(
            (x1 - x4) * ((y2 - y4) * (z3 - z4) - (y3 - y4) * (z2 - z4)) -
            (y1 - y4) * ((x2 - x4) * (z3 - z4) - (x3 - x4) * (z2 - z4)) +
            (z1 - z4) * ((x2 - x4) * (y3 - y4) - (x3 - x4) * (y2 - y4))
        ) / 6.0;
        return volume;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Оберіть фігуру: 1 - Трикутник, 2 - Тетраедр");
            Console.WriteLine("0 - Вихід");

            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2 && choice != 0))
            {
                Console.WriteLine("Невірне значення. Виберіть 1, 2 або 0 для виходу.");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Вихід з програми.");
                break;
            }

            if (choice == 1)
            {
                Triangle triangle = new Triangle();
                triangle.SetCoordinates();
                triangle.DisplayCoordinates();
                double area = triangle.CalculateArea();
                Console.WriteLine($"Площа трикутника: {area}");
            }
            else if (choice == 2)
            {
                Tetrahedron tetrahedron = new Tetrahedron();
                tetrahedron.SetCoordinates();
                tetrahedron.DisplayCoordinates();
                double volume = tetrahedron.CalculateVolume();
                Console.WriteLine($"Об'єм тетраедра: {volume}");
            }
        }
    }
}