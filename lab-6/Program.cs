using System;
using System.Text.RegularExpressions;

namespace RegexLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №6: РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ\n");

            // ЧАСТЬ 1: ТЕКСТ
            string text = @"Мой дядя самых честных правил,
Когда не в шутку занемог,
Он уважать себя заставил
И лучше выдумать не мог.
Его пример другим наука;
Но, боже мой, какая скука
С больным сидеть и день и ночь,
Не отходя ни шагу прочь!
Какое низкое коварство
Полуживого забавлять,
Ему подушки поправлять,
Печально подносить лекарство,
Вздыхать и думать про себя:
Когда же черт возьмет тебя!";

            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Загружен текст (Евгений Онегин). Строк: {lines.Length}, символов: {text.Length}\n");

            // ЧАСТЬ 2: СЛОВА
            Console.WriteLine("ЧАСТЬ 2: ПОДСЧЁТ СЛОВ");
            MatchCollection words = Regex.Matches(text, @"\b[а-яА-ЯёЁa-zA-Z]+\b");
            Console.WriteLine($"Всего слов: {words.Count}\nПервые 5: {string.Join(", ", GetFirstWords(words, 5))}\n");

            // ЧАСТЬ 3: СЛОВОСОЧЕТАНИЯ
            Console.WriteLine("ЧАСТЬ 3: СЛОВОСОЧЕТАНИЯ");
            ShowMatches(text, @"\bне\s+[а-яА-ЯёЁ]+\b", "с 'не'");
            ShowMatches(text, @"\b[а-яА-ЯёЁ]+\s+и\s+[а-яА-ЯёЁ]+\b", "'слово и слово'");

            // ЧАСТЬ 4: СИМВОЛЫ
            Console.WriteLine("\nЧАСТЬ 4: СИМВОЛЫ");
            Console.WriteLine($"Знаков препинания: {Regex.Matches(text, @"[.,;:!?-]").Count}");
            Console.WriteLine($"Гласных: {Regex.Matches(text, @"[аеёиоуыэюяАЕЁИОУЫЭЮЯ]").Count}");
            Console.WriteLine($"Согласных: {Regex.Matches(text, @"[бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ]").Count}");

            // ЧАСТЬ 5: СТРОКИ НА "Мой"
            Console.WriteLine("\nЧАСТЬ 5: СТРОКИ, НАЧИНАЮЩИЕСЯ С 'Мой'");
            FindLinesStartingWith(lines, "Мой");

            // ЧАСТЬ 6: СТРОКИ НА ";"
            Console.WriteLine("\nЧАСТЬ 6: СТРОКИ, ОКАНЧИВАЮЩИЕСЯ НА ';' ИЛИ ','");
            FindLinesEndingWith(lines, "[;,]");

            // ЧАСТЬ 7: ЗАМЕНА
            Console.WriteLine("\nЧАСТЬ 7: ЗАМЕНА 'не' -> 'НИ'");
            string modified = Regex.Replace(text, @"\bне\b", "НИ", RegexOptions.IgnoreCase);
            Console.WriteLine($"Результат (первые 150 символов):\n{modified.Substring(0, Math.Min(150, modified.Length))}...\n");

            // ЧАСТЬ 8: ДОПОЛНИТЕЛЬНО
            Console.WriteLine("ЧАСТЬ 8: ДОПОЛНИТЕЛЬНО");
            ShowMatches(text, @"\b[А-ЯЁ][а-яё]*\b", "слова с большой буквы", 3);
            ShowMatches(text, @"\b[а-яА-ЯёЁ]{5}\b", "слова из 5 букв");

            // ИТОГИ
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine($"ИТОГИ: строк {lines.Length} | символов {text.Length} | слов {words.Count}");
            Console.WriteLine(new string('=', 50));
        }

        static void ShowMatches(string text, string pattern, string description, int max = 10)
        {
            var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
            Console.WriteLine($"\n{description}: {matches.Count}");
            for (int i = 0; i < Math.Min(matches.Count, max); i++)
                Console.WriteLine($"   {matches[i].Value}");
        }

        static string[] GetFirstWords(MatchCollection matches, int count)
        {
            var result = new string[Math.Min(matches.Count, count)];
            for (int i = 0; i < result.Length; i++) result[i] = matches[i].Value;
            return result;
        }

        static void FindLinesStartingWith(string[] lines, string word)
        {
            int found = 0;
            foreach (var line in lines)
                if (Regex.IsMatch(line, $@"^{word}.*", RegexOptions.IgnoreCase))
                { Console.WriteLine($"   {line}"); found++; }
            if (found == 0) Console.WriteLine("   Не найдено");
        }

        static void FindLinesEndingWith(string[] lines, string chars)
        {
            int found = 0;
            foreach (var line in lines)
                if (Regex.IsMatch(line.Trim(), $@"{chars}$"))
                { Console.WriteLine($"   {line}"); found++; }
            if (found == 0) Console.WriteLine("   Не найдено");
        }
    }
}