using System;

namespace Millionaire_GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Добро пожаловать в игру «КТО ХОЧЕТ СТАТЬ МИЛЛИОНЕРОМ?»!");        

            Game game = new Game();            

            game.StartGame();

            game.StartQuestions();
            
        }
    }
}
