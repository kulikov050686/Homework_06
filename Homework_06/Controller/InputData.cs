using System;
using System.IO;
using Homework_06.Model;

namespace Homework_06.Controller
{
    class InputData : MyBaseClass
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
        /// Ввод данных из файла
        /// </summary>        
        public bool InputNumberFile()
        {
            if (OpenSaveFile.OpenFile())
            {
                string path = OpenSaveFile.Path;
                string line = File.ReadAllText(path);

                if (RangeMembershipCheck(line))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Ввод числа
        /// </summary>
        public bool InputNumberKeyboard()
        {
            Console.Write($"Введите число от 1 до {maxNumber}: ");

            if (RangeMembershipCheck(Console.ReadLine()))
            {
                return true;
            }

            return false;
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
        /// Сохранение групп чисел в файл
        /// </summary>        
        public void SaveToFile()
        {
            if (OpenSaveFile.SaveFile())
            {
                string path = OpenSaveFile.Path;

                if (SaveGroupsToFile(path))
                {
                    Console.WriteLine("Файл удачно сохранён!!!");
                }
            }
        }

        /// <summary>
        /// Сжатие данных
        /// </summary>
        public void Compression()
        {
            if (OpenSaveFile.ArchiveFile())
            {
                string sourceFile = OpenSaveFile.Path;
                string compressedFile = sourceFile + ".rar";

                if (DataArchiving(sourceFile, compressedFile))
                {
                    Console.WriteLine("Файл сжат удачно !!!");
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
