using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Millionaire_GAME
{
    class Save
    {
        public static void GameSave()
        {
            Console.WriteLine("Введите название, чтобы сохранить Ваш прогресс.");
            string fileName = Console.ReadLine();

            string savePath = $"C:\\Games\\Millionaire\\Saves\\{fileName}.saved";

            FileInfo userSave = new FileInfo(savePath);
            if (userSave.Exists)
            {
                userSave.Delete();
            }
            FileStream myFileStream = userSave.OpenWrite();
            using (StreamWriter myStream = new StreamWriter(myFileStream, Encoding.UTF8))
            {
                myStream.WriteLine(User.UserName);
                myStream.WriteLine(Game.NumberQuestion);
            }
        }
    }
}
