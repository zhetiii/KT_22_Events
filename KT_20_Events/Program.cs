using System;

namespace KT_20_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("  КТ №20: События в C# (Вариант 1 - Таймер)       ");
            Console.WriteLine("==================================================\n");

            int initialSeconds = 10;
            CountdownTimer timer = new CountdownTimer();

            EventHandler<int> firstHandler = (sender, remainingSeconds) =>
            {
                Console.WriteLine($"[Обработчик 1]: Осталось секунд: {remainingSeconds}");
            };

            EventHandler<int>? secondHandler = null;

            secondHandler = (sender, remainingSeconds) =>
            {
                Console.WriteLine($"[Обработчик 2] Работает: осталось {remainingSeconds} сек.");

                if (remainingSeconds < initialSeconds / 2)
                {
                    Console.WriteLine("[Обработчик 2] Половина времени прошла. Отписываю сам себя от события Tick!");
                    timer.Tick -= secondHandler;
                }
            };

            timer.Tick += firstHandler;
            timer.Tick += secondHandler;

            timer.Finished += (sender, e) =>
            {
                Console.WriteLine("\n[Событие Finished]: Время вышло! Таймер завершил работу.");
            };

            Console.WriteLine($"Запуск таймера на {initialSeconds} секунд...\n");
            timer.Start(initialSeconds);

            Console.WriteLine("\nПрограмма завершена.");
        }
    }
}