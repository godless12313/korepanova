using System;

struct Person
{
    public string name;
    public int age;
    public string city;

    public Person(string name, int age, string city)
    {
        this.name = name;
        this.age = age;
        this.city = city;
    }

    public Person(string name, int age) : this(name, age, "Неизвестно") { }

    public Person(string name) : this(name, 18, "Неизвестно") { }

    public void Print()
    {
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Город: {city}");
    }

    public static Person Default() => new Person("AnonymousEmber", 0, "0");
}

class Program
{
    static void PrintPerson(Person p)
    {
        Console.WriteLine($"{p.name} | {p.age} | {p.city}");
    }

    static void Main()
    {
        Person alexandra = new Person("Александра", 28, "Москва");
        alexandra.Print();

        Person dmitry = new Person("Дмитрий", 35, "Санкт-Петербург");
        PrintPerson(dmitry);

        Person sergey = new Person { name = "Сергей", age = 22, city = "Казань" };
        PrintPerson(sergey);

        Person andrey = sergey with { name = "Андрей", age = 24 };
        PrintPerson(andrey);

        Console.WriteLine("Anonymous Ember");
    }
}