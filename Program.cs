using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsSelected = false;

            Console.WriteLine("1 - Задание на сортировку; \n" +
                "2 - Задание на проверку букв латинского алфавита;");

            while (!IsSelected)
            {
                Console.Write("Ввод номера задания: ");

                string select = Console.ReadLine();
                Console.WriteLine();

                if (select == "1")
                {
                    Test1();
                    IsSelected = true;
                }
                else if (select == "2")
                {
                    Test2();
                    IsSelected = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            Console.ReadKey();
        }

        static void Test1()
        {
            Random random = new Random();

            //Инициализируем 2 стартовых массива и 1 финальный
            int count = random.Next(10, 20);
            int[] massive1 = new int[count];

            count = random.Next(10, 20);
            int[] massive2 = new int[count];

            int[] final_massive = new int[massive1.Length + massive2.Length];

            for (int i = 0; i < massive1.Length; i++)
            {
                massive1[i] = random.Next(-50, 50);
            }

            for (int i = 0; i < massive2.Length; i++)
            {
                massive2[i] = random.Next(-50, 50);
            }

            //
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Массив_1:");
            for (int i = 0; i < massive1.Length; i++)
            {
                Console.Write(massive1[i] + " ");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Массив_2:");
            for (int i = 0; i < massive2.Length; i++)
            {
                Console.Write(massive2[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //

            int temp;
            //Самая медленная и простая сортировка "пузырьком"
            for (int i = 0; i < massive1.Length; i++)
            {
                for (int j = i + 1; j < massive1.Length; j++)
                {
                    if (massive1[i] > massive1[j])
                    {
                        temp = massive1[i];
                        massive1[i] = massive1[j];
                        massive1[j] = temp;
                    }
                }
            }

            for (int i = 0; i < massive2.Length; i++)
            {
                for (int j = i + 1; j < massive2.Length; j++)
                {
                    if (massive2[i] > massive2[j])
                    {
                        temp = massive2[i];
                        massive2[i] = massive2[j];
                        massive2[j] = temp;
                    }
                }
            }

            //
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Отсортированный Массив_1:");
            for (int i = 0; i < massive1.Length; i++)
            {
                Console.Write(massive1[i] + " ");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Отсортированный Массив_2:");
            for (int i = 0; i < massive2.Length; i++)
            {
                Console.Write(massive2[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //

            for (int i = 0; i < massive2.Length; i++)
            {
                for (int j = i + 1; j < massive2.Length; j++)
                {
                    if (massive2[i] > massive2[j])
                    {
                        temp = massive2[i];
                        massive2[i] = massive2[j];
                        massive2[j] = temp;
                    }
                }
            }

            massive1.CopyTo(final_massive, 0);
            massive2.CopyTo(final_massive, massive1.Length);

            for (int i = 0; i < final_massive.Length; i++)
            {
                for (int j = i + 1; j < final_massive.Length; j++)
                {
                    if (final_massive[i] > final_massive[j])
                    {
                        temp = final_massive[i];
                        final_massive[i] = final_massive[j];
                        final_massive[j] = temp;
                    }
                }
            }

            //
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Отсортированный финльный массив:");
            for (int i = 0; i < final_massive.Length; i++)
            {
                Console.Write(final_massive[i] + " ");
            }
            Console.WriteLine();
            //
        }

        static void Test2()
        {
            Console.WriteLine("Ввод строки:");

            string s = Console.ReadLine();

            bool all_latin = CheckAlphabet(s);

            if (all_latin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("В строку включены все буквы латинского алфавита");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Строка не содержит все буквы латинского алфавита");
            }
        }

        static bool CheckAlphabet(string s)
        {
            List<int> Symbols = new List<int>();
            int sum_symbols = 0;//Количество неповторяющихся символов латинского алфавита

            s = s.ToLower();

            int symbol_code;//Для фильтрации нужных нам символов

            foreach (char symbol in s)
            {
                symbol_code = Convert.ToInt32(symbol);

                if (symbol_code > 60 && symbol_code < 123)//60-123 - промежуток кодов латинских букв в нижнем регистре
                {
                    Symbols.Add(symbol_code);
                }
            }

            for (int i = 0; i < Symbols.Count; i++)
            {
                for (int j = 0; j < Symbols.Count; j++)
                {
                    //Проверяем и отфильтровываем повторяющиеся буквы латинского алфавита
                    if (Symbols[i] == Symbols[j] && i != j)
                    {
                        Symbols[i] = 0;
                    }
                }

                if (Symbols[i] != 0 && i != Symbols.Count-1)
                    sum_symbols++;//Считаем количество неповторяющихся символов латинского алфавита
            }

            if (sum_symbols == 26) //26 - общее количество букв латинского алфавита
                return true;
            else
                return false;
        }
    }
}
