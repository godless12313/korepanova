using System;

delegate void Message();
delegate int Operation(int x, int y);
delegate T GenericOperation<T, K>(K val);

class Program
{
    static void Privet() => Console.WriteLine("Бибра 67 приветствует! Жиза!");
    static void KakDela() => Console.WriteLine("Йоц Бибра, как сам? огонь!");
    static void Poka() => Console.WriteLine("Бибра уходит в закат... Но вернётся! Бибра 67!");

    static int Slozhenie(int x, int y) => x + y;
    static int Vychitanie(int x, int y) => x - y;
    static int Umnozhenie(int x, int y) => x * y;

    static decimal Kvadrat(int n) => n * n;
    static int Udvoenie(int n) => n + n;

    static void VypolniOperaciyu(int a, int b, Operation op)
    {
        Console.WriteLine($"Результат бибры: {op(a, b)}");
    }

    static Operation VyborOperacii(string opType)
    {
        switch (opType)
        {
            case "slozh": return Slozhenie;
            case "vichit": return Vychitanie;
            default: return Umnozhenie;
        }
    }

    static void Main()
    {
        Message message = Privet;
        message += KakDela;
        message += Poka;
        message();

        message -= KakDela;
        message?.Invoke();

        Operation op = Slozhenie;
        op += Umnozhenie;
        op += Vychitanie;
        Console.WriteLine($"Последний результат бибры: {op(10, 3)}");

        VypolniOperaciyu(8, 2, Slozhenie);
        VypolniOperaciyu(8, 2, Umnozhenie);

        Operation selected = VyborOperacii("vichit");
        Console.WriteLine($"Бибра выбрала: {selected(20, 5)}");

        Message mes1 = Privet;
        Message mes2 = KakDela;
        Message mes3 = mes1 + mes2;
        mes3();

        GenericOperation<decimal, int> squareOp = Kvadrat;
        Console.WriteLine($"Квадрат бибры: {squareOp(7)}");

        GenericOperation<int, int> doubleOp = Udvoenie;
        Console.WriteLine($"Удвоение бибры: {doubleOp(7)}");

        Operation? nullOp = null;
        int? result = nullOp?.Invoke(5, 3);
        Console.WriteLine($"Пустая бибра: {(result.HasValue ? result.ToString() : "null, бибра спит")}");
    }
}