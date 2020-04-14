using System;
using Homework_06.Controller;

namespace Homework_06.View
{
    public class HomeWork
    {
        /// <summary>
        /// Запуск программы
        /// </summary>
        public void Run()
        {
            KeyboardInput keyboardInput = new KeyboardInput();

            keyboardInput.InputNumber();
            //Console.WriteLine("Количество групп чисел: " + keyboardInput.NumberGroups);
            //Console.ReadKey();
            keyboardInput.Run();
            //keyboardInput.Show();
            keyboardInput.SaveToFile();

            Console.ReadKey();

            //keyboardInput.Run();
        }
    }
}
