public class TSquare
{
    public double side;

    public TSquare()
    {
        side = 0;
    }

    public TSquare(double side)
    {
        this.side = side;
    }

    public TSquare(TSquare other)
    {
        side = other.side;
    }

    public double Area()
    {
        return side * side;
    }

    public double Perimeter()
    {
        return 4 * side;
    }

    public bool Compare(TSquare other)
    {
        return side == other.side;
    }

    public static TSquare operator +(TSquare a, TSquare b)
    {
        return new TSquare(a.side + b.side);
    }

    public static TSquare operator -(TSquare a, TSquare b)
    {
        return new TSquare(a.side - b.side);
    }

    public static TSquare operator *(TSquare a, double b)
    {
        return new TSquare(a.side * b);
    }
}

public class TCube : TSquare
{
    public TCube() : base() { }

    public TCube(double side) : base(side) { }

    public TCube(TCube other) : base(other.side) { }

    public double Volume()
    {
        return side * side * side;
    }

    public new double Area()
    {
        return 6 * base.Area();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Тестування класів
        TSquare square1 = new TSquare(10);
        TSquare square2 = new TSquare(5);
        TCube cube = new TCube(3);
        Console.WriteLine("Довжина: першого квадрата - 10; другого - 5; куба - 3.");
        Console.WriteLine("Площа квадрата 1: " + square1.Area());
        Console.WriteLine("Периметр квадрата 1: " + square1.Perimeter());
        Console.WriteLine("Порівняння квадратів на рівність : " + square1.Compare(square2));

        square1 = square1 + square2;
        Console.WriteLine("Додавання довжин сторін квадратів: " + square1.side);

        square1 = square1 - square2;
        Console.WriteLine("Віднімання довжин сторін квадратів: " + square1.side);

        square1 = square1 * 2;
        Console.WriteLine("Множення сторони квадрата на число(2): " + square1.side);

        Console.WriteLine("Площа поверхні куба: " + cube.Area());
        Console.WriteLine("Об'єм куба: " + cube.Volume());
    }
}
