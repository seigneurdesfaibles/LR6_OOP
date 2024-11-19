using System;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        // Створення та ініціалізація масиву з 10 цілих чисел у проміжку (100...500)
        int[] array = new int[10];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(101, 501); // числа у діапазоні [100, 500]
        }

        Console.WriteLine("Масив чисел:");
        Console.WriteLine(string.Join(", ", array));

        // Потік Т0: Знаходить кількість чисел більших за 10
        Thread t0 = new Thread(() =>
        {
            int countGreaterThan10 = array.Count(n => n > 10);
            Console.WriteLine($"Кількість чисел більших за 10: {countGreaterThan10}");
        });

        // Потік Т1: Знаходить кількість парних чисел
        Thread t1 = new Thread(() =>
        {
            int evenCount = array.Count(n => n % 2 == 0);
            Console.WriteLine($"Кількість парних чисел: {evenCount}");
        });

        // Запуск потоків
        t0.Start();
        t1.Start();

        // Очікування завершення потоків
        t0.Join();
        t1.Join();
    }
}
