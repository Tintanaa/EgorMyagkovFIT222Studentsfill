using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Menu
    {
        public void MenuOpen()
        {
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine("Меню программы\n 1) Ввод данных\n 2) Виды выборок\n 3) Об авторe\n 4) Выход из программы");
        }
        public void Case1()
        {
            Console.WriteLine("Введите необходимые данные по очереди (через 3 секунды):");
            Thread.Sleep(3000);
        }
        public void Case2()
        {
            Console.WriteLine("Введите необходимую выборку\n" +
                "1) Необходимо выдать студентов которые учатся в заданной группе \r\n * " +
                "2) Выдать оболтусов (должников со всех групп)\r\n * " +
                "3) Выдать гениев (отличников)\r\n * " +
                "4) Выдать студентов моложе 20 лет");
        }
        public void Case3()
        {
            Console.WriteLine("Автор программы: Мягков Егор ФИТ-222");
        }
    }
}

