using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Millionaire_GAME
{
    class Load
    {
        public static void LoadSaveGame()
        {
            string fileName = LoadFileName();

            string savePath = $"C:\\Games\\Millionaire\\Saves\\{fileName}";

            FileInfo userSave = new FileInfo(savePath);
            if (!userSave.Exists)
            {
                throw new FileNotFoundException(savePath);
            }
            FileStream saveDataStream = userSave.OpenRead();
            using (StreamReader myStream = new StreamReader(saveDataStream, Encoding.Default))
            {
                string[] userData = File.ReadAllLines(savePath, Encoding.Default);

                User.SetUserName(userData[0]);
                Game.NumberQuestion = int.Parse(userData[1]);

            }
        }

        private static string LoadFileName()
        {
            Console.Clear();

            string savePath = "C:\\Games\\Millionaire\\Saves\\";

            DirectoryInfo gameSaveFolder = new DirectoryInfo(savePath);
            FileInfo[] saveFiles = gameSaveFolder.GetFiles();

            string save = "й";
            if (saveFiles.Length == 1)
                save = "е";
            else if (saveFiles.Length > 1 && saveFiles.Length < 5)
                save = "я";

            Console.WriteLine($"Найдено {saveFiles.Length} сохранени{save}.\n");

            for (int i = 0; i < saveFiles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {saveFiles[i].Name}({saveFiles[i].CreationTime})\n");
            }

            Console.WriteLine("Пожалуйста, введите номер сохранения:");
            string j = Console.ReadLine();

            try
            {
                return saveFiles[int.Parse(j) - 1].Name;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"!!!Файл № {j} не найден, выберите из списка!!!\n");
                return LoadFileName();
            }
        }
    }
}
