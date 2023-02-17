using App1;
using System;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;
/*Класс описывающий структуру записи студента и хранящий информацию о 1) ФИ0
 * 2) Дата (3 поля)
 * 3) Группа
 * 4) Наименование предмета, оценка
 * Необходимо выдать студентов которые учатся в заданной группе 
 * Выдать оболтусов (должников со всех групп)
 * Выдать гениев (отличников)
 * Выдать студентов моложе 20 лет
 * Меню: Заполнение, выборка.*/
Menu menu = new Menu();
Place place = new Place();
while (true)
{
    try
    {
        menu.MenuOpen();
        int choose = Convert.ToInt32(Console.ReadLine());
        if (choose < 1 || choose > 4)
        {
            Console.Clear();
            Console.WriteLine("Ошибка. Введите номер команды от 1 до 4");
            Console.WriteLine("1-продолжить");
            int choose2 = 0;
            while (choose2 != 1)
            {
                choose2 = Convert.ToInt32(Console.ReadLine());
                if (choose2 != 1)
                {
                    Console.WriteLine("1-продолжить");
                }
            }
            Console.Clear();
        }
        else
        {
            Console.Clear();
            switch (choose)
            {
                case 1:
                    Input();
                    break;
                case 2:
                    Vyborka();
                    break;
                case 3:
                    Console.Clear();
                    menu.Case3();
                    break;
                case 4:
                    Console.WriteLine("Конец работы");
                    Environment.Exit(0);
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error!:\n" + ex.Message + "\n");
    }
}
DateTime inputDoB()
{
    DateTime dob; // date of birth
    string input;

    do
    {
        Console.WriteLine("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
        input = Console.ReadLine();
    }
    while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));
    return dob;
}
void Vyborka()
{
    menu.Case2();
    int choosevyborka = Convert.ToInt32(Console.ReadLine());
    bool breakvyborka = true;
    while (breakvyborka != false)
    {
        switch (choosevyborka)
        {
            case 1:
                groupviborka();
                break;
            case 2:
                dolzhnikvyborka();
                break;
            case 3:
                otlichnikvyborka();
                break;
            case 4:
                var vremyanow = DateTime.Now;
                var viborka = place.Spisok;
                Console.WriteLine("Студенты которым больше 20 лет: ");
                for (int i = 0; i < viborka.Count; i++)
                {
                    if (vremyanow.Year - viborka[i].Item4.Year > 20)
                    {
                        Console.WriteLine($"{viborka[i].Item2} {viborka[i].Item1} {viborka[i].Item3} {viborka[i].Item5}");
                        Console.WriteLine("-----------------------------------------------------------------------------");
                    }
                }
                breakvyborka = false;
                break;
            default:
                throw new Exception("Выберите действие от 1 до 4");
                break;
        }
    }
    void groupviborka()
    {
        Console.Clear();
        Console.WriteLine("Выберите группу студентов");
        string group = Console.ReadLine();
        RegexINTSTRcheck(group);
        Console.Clear();
        Console.WriteLine($"Выборка студентов группы {group}");
        var viborka = place.Spisok;
        for (int i = 0; i < viborka.Count; i++)
        {
            if (viborka[i].Item6 == group)
            {
                Console.WriteLine($"{viborka[i].Item2} {viborka[i].Item1} {viborka[i].Item3} {viborka[i].Item4} {viborka[i].Item6}");
                Console.WriteLine($"Предметы студента {viborka[i].Item1} {viborka[i].Item2} и его оценка");
                Console.WriteLine($"--------------------------------------------------------------");
                var subjoc = viborka[i].Item5;
                for (int j = 0; j < subjoc.Count; j++)
                {
                    Console.WriteLine($"--------------------------------------------------------------");
                    Console.WriteLine($"{subjoc[j].Item1}: {subjoc[j].Item2}");
                    Console.WriteLine($"--------------------------------------------------------------");
                }
            }
        }
        Console.WriteLine("1-продолжить");
        string flag8 = Console.ReadLine();
        if (flag8 == "1")
        {
            breakvyborka = false;
        }
        else
        {
            while (flag8 != "1")
            {
                Console.Clear();
                Console.WriteLine("1-продолжить");
                flag8 = Console.ReadLine();
            }
            breakvyborka = false;
        }
    }
    void dolzhnikvyborka()
    {
        Console.Clear();
        var viborka = place.Spisok;
        var flag4 = false;
        for (int i = 0; i < viborka.Count; i++)
        {
            var subjoc = viborka[i].Item5;
            flag4 = checkdolzhnik(flag4, subjoc);
            if (flag4 == true)
            {
                Console.WriteLine($"Гений {viborka[i].Item2} {viborka[i].Item1} {viborka[i].Item3} {viborka[i].Item4} {viborka[i].Item6}");
                for (int j = 0; j < subjoc.Count; j++)
                {
                    Console.WriteLine($"--------------------------------------------------------------");
                    Console.WriteLine($"{subjoc[j].Item1}, {subjoc[j].Item2}");
                    Console.WriteLine($"--------------------------------------------------------------");
                }
            }
            flag4 = false;
        }
        breakvyborka = false;
        bool checkdolzhnik(bool flag4, List<(string, int)> subjoc)
        {
            for (int j = 0; j < subjoc.Count; j++)
            {
                if (subjoc[j].Item2 == 5)
                {
                    flag4 = true;
                }
            }
            return flag4;
        }
    }
    void otlichnikvyborka()
    {
        Console.Clear();
        var viborka = place.Spisok;
        var flag4 = false;
        for (int i = 0; i < viborka.Count; i++)
        {
            var subjoc = viborka[i].Item5;
            flag4 = checkotlichnik(flag4, subjoc);
            if (flag4 == true)
            {
                Console.WriteLine($"Гений {viborka[i].Item2} {viborka[i].Item1} {viborka[i].Item3} {viborka[i].Item4} {viborka[i].Item6}");
                for (int j = 0; j < subjoc.Count; j++)
                {
                    Console.WriteLine($"--------------------------------------------------------------");
                    Console.WriteLine($"{subjoc[j].Item1}, {subjoc[j].Item2}");
                    Console.WriteLine($"--------------------------------------------------------------");
                }
            }
            flag4 = false;
        }
        breakvyborka = false;
        bool checkotlichnik(bool flag4, List<(string, int)> subjoc)
        {
            for (int j = 0; j < subjoc.Count; j++)
            {
                if (subjoc[j].Item2 == 5)
                {
                    flag4 = true;
                }
            }
            return flag4;
        }
    }
}
string RegexSTRcheck(string input)
{
    bool check = false;
    while (check != true)
    {
        if (Regex.IsMatch(input, @"[а-яА-Я]+") != true)
        {
            Console.WriteLine("Некорректный ввод данных в русском языке.\nПерепишите");
            input = Console.ReadLine();
        }
        else
        {
            check = true;
        }
    }
    return input;
}
string RegexINTSTRcheck(string input)
{
    bool check = false;
    while (check != true)
    {
        if (Regex.IsMatch(input, @"^[a-zA-Z0-9]+$") != true)
        {
            Console.WriteLine("Язык только en, допустимы только цифры и буквы.\nПерепишите");
            input = Console.ReadLine();
        }
        else
        {
            check = true;
        }
    }
    return input;
}
string RegexINTcheck(string input)
{
    bool check = false;
    while (check != true)
    {
        if (Regex.IsMatch(input, @"^[0-9_]+$") != true)
        {
            Console.WriteLine("Введённая вами строка должна содержать только int числа.\nПерепишите");
            input = Console.ReadLine();
        }
        else
        {
            check = true;
        }
    }
    return input;
}
void Input()
{
    menu.Case1();
    int flag = 1;
    while (flag != 0)
    {
        Console.WriteLine("Введите имя");
        string name = Console.ReadLine();
        RegexSTRcheck(name);
        Console.Clear();
        Console.WriteLine("Введите фамилию");
        string surname = Console.ReadLine();
        RegexSTRcheck(surname);
        Console.Clear();
        Console.WriteLine("Введите отчество");
        string otchestvo = Console.ReadLine();
        RegexSTRcheck(otchestvo);
        Console.Clear();
        var dob = inputDoB();
        Console.Clear();
        Console.WriteLine("Введите группу");
        string group = Console.ReadLine();
        RegexINTSTRcheck(group);
        Console.Clear();
        Console.WriteLine("Введите названия предметов и их оценку.");
        int flag3 = 1;
        List<(string, int)> predmocenka = new List<(string, int)>();
        while (flag3 != 0)
        {
            string namesubj = Console.ReadLine();
            RegexSTRcheck(namesubj);
            int mark = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1-продолжить. 0-закончить");
            predmocenka.Add((namesubj, mark));
            while (true)
            {
                flag3 = Convert.ToInt32(Console.ReadLine());
                RegexINTcheck(Convert.ToString(flag3));
                if (flag3 < 0 || flag3 > 1)
                {
                    Console.WriteLine("1-продолжить заполнение списка оценок. 0-закончить");
                }
                else
                {
                    break;
                }
            }
        }
        place.name = name;
        place.surname = surname;
        place.otchestvo = otchestvo;
        place.dob = dob;
        place.group = group;
        place.predmocenka = predmocenka;
        Filllist(place.name, place.surname,place.otchestvo, place.dob, place.group,place.predmocenka);
        Console.WriteLine("1-продолжить заполнение студентов. 0-закончить");
        while (true)
        {
            flag = Convert.ToInt32(Console.ReadLine());
            if (flag < 0 || flag > 1)
            {
                Console.WriteLine("1-продолжить заполнение студентов. 0-закончить");
            }
            else
            {
                break;
            }
        }
        Console.Clear();
    }
    void Filllist(string name, string surname, string otchestvo, DateTime dob, string group, List<(string, int)> predmocenka)
    {
        List<(string, string, string, DateTime, List<(string, int)> predoc, string)> Spisok2 = new List<(string, string, string, DateTime, List<(string, int)> predoc, string)>();
        Spisok2.Add((name, surname, otchestvo, dob, predmocenka, group));
        place.Spisok = Spisok2;
    }
}
