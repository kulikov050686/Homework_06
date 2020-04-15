using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_06.Controller
{
    public class MyBaseClass
    {
        /// <summary>
        /// Максимальное вводимое число
        /// </summary>
        protected const uint maxNumber = 1_000_000_000;

        /// <summary>
        /// Вводимое число
        /// </summary>
        uint Number;

        /// <summary>
        /// Группы чисел
        /// </summary>
        List<uint>[] Groups;

        /// <summary>
        /// Число групп чисел
        /// </summary>
        protected uint NumberOfGroups = 0;

        /// <summary>
        /// Расчёт групп чисел
        /// </summary>
        protected void GroupCalculation()
        {
            InitGroup();
            FillingGroups();
        }

        /// <summary>
        /// Инициализация групп
        /// </summary>
        private void InitGroup()
        {
            if(NumberOfGroups > 0)
            {
                Groups = new List<uint>[NumberOfGroups];

                for (int i = 0; i < NumberOfGroups; i++)
                {
                    Groups[i] = new List<uint>();
                }
            }            
        }

        /// <summary>
        /// Заполнение групп числами
        /// </summary>
        private void FillingGroups()
        {
            Groups[0].Add(1);

            if (NumberOfGroups > 1)
            {                
                Algorithm();                
            }
        }

        /// <summary>
        /// Суммарная кратность вхождения простых чисел в составное число
        /// </summary>
        /// <param name="CompositeNumber"> Составное число </param>        
        private uint TotalDegree(uint CompositeNumber)
        {
            uint k = 2;
            uint sum = 1;

            while(k*k < CompositeNumber + 1)
            {
                if(CompositeNumber % k != 0)
                {
                    k++;
                }
                else
                {
                    CompositeNumber = CompositeNumber / k;
                    sum++;
                }
            }

            return sum;
        }

        /// <summary>
        /// Алгоритм заполнения групп числами
        /// </summary>
        private void Algorithm()
        {
            for (uint i = 2; i < Number; i++)
            {
                Groups[TotalDegree(i)].Add(i);
            }
        }

        /// <summary>
        /// Проверка ввода данных
        /// </summary>
        /// <param name="str"> Вводимое число в виде строки </param>
        protected bool RangeMembershipCheck(string str)
        {
            if (uint.TryParse(str, out Number))
            {
                if (1 <= Number && Number <= maxNumber)
                {
                    if (Number == 1)
                    {
                        NumberOfGroups = 1;
                    }
                    else
                    {
                        if (Number < 4)
                        {
                            NumberOfGroups = 2;
                            Number++;
                        }
                        else
                        {
                            NumberOfGroups = (uint)(Math.Log(Number) / Math.Log(2)) + 1;
                            Number++;
                        }
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("Число не соответсвует диапазону!!!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных!!!");
            }

            return false;
        }

        /// <summary>
        /// Сохранение групп чисел в текстовый файл
        /// </summary>        
        protected bool SaveGroupsToFile(string path)
        {
            if(NumberOfGroups > 0)
            {
                if(path != null)
                {
                    bool append = false;
                    string line;

                    for (int i = 0; i < NumberOfGroups; i++)
                    {
                        line = $"ГРУППА {i + 1}:  ";

                        if (i != 0)
                        {
                            append = true;
                        }

                        using (StreamWriter streamWriter = new StreamWriter(path, append))
                        {
                            streamWriter.Write(line);

                            foreach (uint temp in Groups[i])
                            {
                                line = Convert.ToString(temp) + " ";
                                streamWriter.Write(line);
                            }

                            streamWriter.Write("\n");
                        }
                    }
                    
                    return true;
                }
                else
                {
                    Console.WriteLine("Имя файла не может быть пустым!!!");
                }
            }

            return false;
        }

        /// <summary>
        /// Выводит группы на печать в консоль
        /// </summary>
        protected void Print()
        {
            for(uint i = 0; i < NumberOfGroups; i++)
            {
                Console.Write($"Группа {i + 1}: ");

                foreach(uint temp in Groups[i])
                {
                    Console.Write(temp + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
