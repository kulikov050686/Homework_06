using System;
using System.IO;
using Homework_06.Model;

namespace Homework_06.Controller
{
    public class FileInput : MyBaseClass
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
        /// Ввод данных из файла
        /// </summary>        
        public bool InputNumber()
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
        /// Выводит группы на консоль
        /// </summary>
        public void Show()
        {
            Print();
        }
    }
}
