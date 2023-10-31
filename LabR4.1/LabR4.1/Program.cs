
public class TSMatrix
{
    public double[,] matrix;
    public int size;

    public TSMatrix()
    {
        size = 0;
        matrix = new double[size, size];
    }

    public TSMatrix(int size)
    {
        this.size = size;
        matrix = new double[size, size];
    }

    public TSMatrix(TSMatrix other)
    {
        size = other.size;
        matrix = (double[,])other.matrix.Clone();
    }

    public double MaxElement()
    {
        double max = matrix[0, 0];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i, j] > max)
                    max = matrix[i, j];
        return max;
    }

    public double MinElement()
    {
        double min = matrix[0, 0];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];
        return min;
    }

    public double SumElements()
    {
        double sum = 0;
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                sum += matrix[i, j];
        return sum;
    }

    public static TSMatrix operator +(TSMatrix a, TSMatrix b)
    {
        TSMatrix result = new TSMatrix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
        return result;
    }

    public static TSMatrix operator -(TSMatrix a, TSMatrix b)
    {
        TSMatrix result = new TSMatrix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
        return result;
    }

}

public class TMSMareix : TSMatrix
{
    public TMSMareix() : base() { }

    public TMSMareix(int size) : base(size) { }

    public TMSMareix(TMSMareix other) : base(other) { }
 public void Transpose()
 {
   for (int i = 0; i < size; i++)
   for (int j = i + 1; j < size; j++)
     {
      double temp = matrix[i, j];
      matrix[i, j] = matrix[j, i];
      matrix[j, i] = temp;
     }
 }

    public static TMSMareix operator *(TMSMareix a, TMSMareix b)
    {
        TMSMareix result = new TMSMareix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                for (int k = 0; k < a.size; k++)
                    result.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
        return result;
    }

    public static TMSMareix operator *(TMSMareix a, double b)
    {
        TMSMareix result = new TMSMareix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] += a.matrix[i, j] * b;
        return result;
    }

    // Метод для обчислення визначника матриці
    public double Determinant()
    {
        if (size == 1)
            return matrix[0, 0];

        if (size == 2)
            return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];

        double det = 0;

        for (int p = 0; p < size; p++)
        {
            TMSMareix smaller = new TMSMareix(size - 1);
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j < p)
                        smaller.matrix[i - 1, j] = matrix[i, j];
                    else if (j > p)
                        smaller.matrix[i - 1, j - 1] = matrix[i, j];
                }
            }
            det += matrix[0, p] * Math.Pow(-1, p) * smaller.Determinant();
        }
        return det;
    }
    public static TMSMareix operator +(TMSMareix a, TMSMareix b)
    {
        TMSMareix result = new TMSMareix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
        return result;
    }

    public static TMSMareix operator -(TMSMareix a, TMSMareix b)
    {
        TMSMareix result = new TMSMareix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Створення матриць
        TMSMareix matrix1 = new TMSMareix(3);
        TMSMareix matrix2 = new TMSMareix(3);

        // Заповнення матриць даними
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                matrix1.matrix[i, j] = i + j;
                matrix2.matrix[i, j] = i - j;
            }

        // Виведення результатів
        Console.WriteLine("Максимальний елемент матриці 1: " + matrix1.MaxElement());
        Console.WriteLine("Мінімальний елемент матриці 1: " + matrix1.MinElement());
        Console.WriteLine("Сума елементів матриці 1: " + matrix1.SumElements());

        TMSMareix result = matrix1 + matrix2;
        Console.WriteLine("Сума елементів результуючої матриці після додавання: " + result.SumElements());

        result = matrix1 - matrix2;
        Console.WriteLine("Сума елементів результуючої матриці після віднімання: " + result.SumElements());

        result = matrix1 * matrix2;
        Console.WriteLine("Сума елементів результуючої матриці після множення: " + result.SumElements());

        result = matrix1 * 2;
        Console.WriteLine("Сума елементів результуючої матриці після множення на число: " + result.SumElements());

        Console.WriteLine("Визначник матриці 1: " + matrix1.Determinant());
    }
}