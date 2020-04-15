using System;
using Homework_06.Controller;
using MyLibraryMenu;

namespace Homework_06.View
{
    public class HomeWork
    {
        /// <summary>
        /// Завершение программы
        /// </summary>
        bool Exit;
        
        /// <summary>
        /// Номер пункта меню
        /// </summary>
        int Item;

        /// <summary>
        /// Выбор пункта меню
        /// </summary>
        string[] Selection;

        /// <summary>
        /// Ввод данных
        /// </summary>
        InputData inputData;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public HomeWork()
        {
            Exit = false;
            Item = 0;
            Selection = new string[] { "Да", "Нет"};
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        public void Run()
        {
            while (!Exit)
            {
                StartMenu();

                if(Item == 0)
                {
                    Console.Clear();
                    KeyboardInputData();
                    WorkWithData();
                }

                if(Item == 1)
                {
                    Console.Clear();
                    FileInputData();
                    WorkWithData();
                }
            }
        }

        /// <summary>
        /// Ввод числа с клавиатуры
        /// </summary>
        private void KeyboardInputData()
        {
            inputData = new InputData();
            inputData.InputNumberKeyboard();

            Console.WriteLine("Количество групп чисел: " + inputData.NumberGroups);
            Console.ReadKey();
        }

        /// <summary>
        /// Ввод числа из файла
        /// </summary>
        private void FileInputData()
        {
            inputData = new InputData();
            inputData.InputNumberFile();

            Console.WriteLine("Количество групп чисел: " + inputData.NumberGroups);
            Console.ReadKey();
        }

        /// <summary>
        /// Стартовое меню
        /// </summary>
        private void StartMenu()
        {
            string[] itensMenu = new string[] { "С клавиатуры",
                                                "Из файла",                                                
                                                "Выход" };

            NewMenu menu = new NewMenu(itensMenu, "Выбирите ввод данных");

            switch (menu.selectedMenuItem())
            {
                case 0:
                    Item = 0;
                    break;
                case 1:
                    Item = 1;
                    break;
                case 2:
                    Item = 2;
                    Exit = true;
                    break;
            }
        }

        /// <summary>
        /// Меню выбора
        /// </summary>
        /// <param name="text"> Текст заголовка </param>
        private bool SelectionMenu(string text)
        {
            NewMenu menu = new NewMenu(Selection, text);

            if (menu.selectedMenuItem() == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Расчёт количества групп чисел
        /// </summary>
        private void Сalculation() 
        {
            DateTime date = DateTime.Now;

            inputData.Run();

            TimeSpan timeSpan = DateTime.Now.Subtract(date);

            Console.WriteLine($"Время рачёта групп чисел составило (мс): {timeSpan.TotalSeconds: 0.000}");

            Console.ReadKey();
        }

        /// <summary>
        /// Сохранить группы чисел в файле
        /// </summary>
        private void WriteToFile()
        {
            inputData.SaveToFile();
            Console.ReadKey();
        }

        /// <summary>
        /// Сжатие данных
        /// </summary>
        private void Compression()
        {
            inputData.Compression();
            Console.ReadKey();
        }

        /// <summary>
        /// Работа с данными
        /// </summary>
        private void WorkWithData()
        {
            if (SelectionMenu("Расчитать группы чисел?"))
            {
                Console.Clear();
                Сalculation();

                if (SelectionMenu("Сохранить данные в файл?"))
                {
                    Console.Clear();
                    WriteToFile();
                }

                if(SelectionMenu("Архивировать данные?"))
                {
                    Console.Clear();
                    Compression();
                }
            }
        }
    }
}

