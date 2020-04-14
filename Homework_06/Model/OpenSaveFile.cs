using System;
using System.Windows.Forms;

namespace Homework_06.Model
{
    class OpenSaveFile
    {
        /// <summary>
        /// Полный путь и имя файла
        /// </summary>
        static public string Path { get; private set; }

        /// <summary>
        /// Открывает диалоговое окно для открытия файла
        /// </summary>
        static public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Открыть файл";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Path = openFileDialog.FileName;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Открывает диалоговое окно для закрытия файла
        /// </summary>
        static public bool SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Path = saveFileDialog.FileName;
                return true;
            }

            return false;
        }
    }
}
