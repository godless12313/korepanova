using System;

class Program
{
    static unsafe void Main()
    {
        // Небезопасный блок кода для работы с указателями
        unsafe
        {
            // Объявление нескольких переменных
            int a = 10;
            int b = 20;
            double c = 3.14;
            char d = 'A';

            // Указатели на переменные
            int* ptrA = &a;
            int* ptrB = &b;
            double* ptrC = &c;
            char* ptrD = &d;

            // Вывод исходных значений и адресов переменных
            Console.WriteLine("Исходные значения:");
            Console.WriteLine($"a = {a}, адрес: {(ulong)ptrA}");
            Console.WriteLine($"b = {b}, адрес: {(ulong)ptrB}");
            Console.WriteLine($"c = {c}, адрес: {(ulong)ptrC}");
            Console.WriteLine($"d = {d}, адрес: {(ulong)ptrD}");

            // Изменение значений через указатели
            *ptrA = 100;
            *ptrB = 200;
            *ptrC = 6.28;
            *ptrD = 'Z';

            // Вывод новых значений (переменные изменились)
            Console.WriteLine("\nПосле изменения через указатели:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"c = {c}");
            Console.WriteLine($"d = {d}");
        }
    }
}