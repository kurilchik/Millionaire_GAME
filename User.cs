using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaire_GAME
{
    class User
    {
        public static string UserName { get; private set; }

        public static void UserNameInput()
        {
            Console.WriteLine("Введите ваше имя:");
            User.UserName = Console.ReadLine();
        }

        public static void SetUserName(string userName)
        {            
            User.UserName = userName;
        }
    }
}
