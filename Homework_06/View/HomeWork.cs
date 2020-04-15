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
        bool Exit = false;
        
        /// <summary>
        /// Номер пункта меню
        /// </summary>
        int Item = 0;

        /// <summary>
        /// Ввод числа с клавиатуры
        /// </summary>
        KeyboardInput keyboardInput;

        /// <summary>
        /// Ввод числа из файла
        /// </summary>
        FileInput fileInput;

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
                }

                if(Item == 1)
                {
                    Console.Clear();
                    FileInputData();
                }
            }
        }

        /// <summary>
        /// Ввод числа с клавиатуры
        /// </summary>
        private void KeyboardInputData()
        {
            keyboardInput = new KeyboardInput();
            keyboardInput.InputNumber();
            char Enter = 'N';

            Console.WriteLine("Количество групп чисел: " + keyboardInput.NumberGroups);
            Console.WriteLine("ВНИМАНИЕ: Расчёт групп может занять очень много времени!!!");
            Console.WriteLine("Расчитать эти группы (Y / N): ");
            
            if(char.TryParse(Console.ReadLine(), out Enter))
            {
                if (Enter == 'Y' || Enter == 'y')
                {
                    keyboardInput.Run();

                    Console.WriteLine("Сохранить данные в файл (Y / N): ");

                    if (char.TryParse(Console.ReadLine(), out Enter))
                    {
                        if (Enter == 'Y' || Enter == 'y')
                        {
                            keyboardInput.SaveToFile();
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("Некоректно введённые данные!!!");

            

            Console.ReadKey();
        }

        /// <summary>
        /// Ввод числа из файла
        /// </summary>
        private void FileInputData()
        {
            fileInput = new FileInput();
            fileInput.InputNumber();
            char Enter = 'N';

            Console.WriteLine("Количество групп чисел: " + fileInput.NumberGroups);
            Console.WriteLine("ВНИМАНИЕ: Расчёт групп может занять очень много времени!!!");
            Console.WriteLine("Расчитать эти группы (Y / N): ");

            if (char.TryParse(Console.ReadLine(), out Enter))
            {
                if (Enter == 'Y' || Enter == 'y')
                {
                    fileInput.Run();

                    Console.WriteLine("Сохранить данные в файл (Y / N): ");

                    if (char.TryParse(Console.ReadLine(), out Enter))
                    {
                        if (Enter == 'Y' || Enter == 'y')
                        {
                            fileInput.SaveToFile();
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("Некоректно введённые данные!!!");

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

            NewMenu menu = new NewMenu(itensMenu, "Выбирите ввод двнных");

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
    }
}

