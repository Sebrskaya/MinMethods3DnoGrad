using System;

class Program
{
    static double Function(double x, double y)
    {
        return Math.Sqrt(x * x + y * y + 1) + x / 2 - y / 2;
    }

    static void Main(string[] args)
    {
        double x = 1.0; // Начальное значение x
        double y = 2.0; // Начальное значение y
        double step = 1.0; // Шаг для начальной аппроксимации
        double epsilon = 1e-6; // Погрешность ответа
        int iterations = 0; // Счетчик итераций

        do
        {
            double currentMin = Function(x, y);
            double xTemp = x;
            double yTemp = y;

            // Поиск в окрестности текущей точки
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    double newX = xTemp + step * dx;
                    double newY = yTemp + step * dy;
                    double newValue = Function(newX, newY);

                    if (newValue < currentMin)
                    {
                        x = newX;
                        y = newY;
                        currentMin = newValue;
                    }
                }
            }

            // Уменьшение шага
            step /= 2;
            iterations++;

        } while (Math.Abs(Function(x, y) - Function(x + step, y + step)) > epsilon);

        Console.WriteLine("Минимум функции: " + Function(x, y));
        Console.WriteLine("x: " + x);
        Console.WriteLine("y: " + y);
        Console.WriteLine("Количество итераций: " + iterations);
    }
}
