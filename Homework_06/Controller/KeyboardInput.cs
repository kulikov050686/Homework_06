using System;
using Homework_06.Model;

namespace Homework_06.Controller
{
    public class KeyboardInput : MyBaseClass
    {
        /// <summary>
        /// Количество групп чисел
        /// </summary>
        public uint NumberGroups
        {
            get
            {
                return NumberOfGroups;
            }
        }
        
        /// <summary>
        /// Расчёт групп чисел
        /// </summary>
        public bool Run()
        {
            if (NumberOfGroups != 0)
            {
                GroupCalculation();                

                return true;
            }

            return false;
        }

        /// <summary>
        /// Ввод числа
        /// </summary>
        public bool InputNumber()
        {
            Console.Write($"Введите число от 1 до {maxNumber}: ");

            if (RangeMembershipCheck(Console.ReadLine()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Сохранение групп чисел в файл
        /// </summary>
        public void SaveToFile()
        {
            if (OpenSaveFile.SaveFile())
            {
                string path = OpenSaveFile.Path;

                if(SaveGroupsToFile(path))
                {
                    Console.WriteLine("Файл удачно сохранён!!!");
                }                              
            }
        }

        /// <summary>
        /// Выводит группы на консоль
        /// </summary>
        public void Show()
        {
            Print();
        }
    }
}
