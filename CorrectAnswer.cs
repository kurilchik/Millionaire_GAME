using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaire_GAME
{
    class CorrectAnswer : Answer
    {
        public CorrectAnswer(string answerText) : base(answerText)
        {

        }

        public override void Choose()
        {
            Score.SetScore();

            Game.NumberQuestion++;

            if (Game.NumberQuestion < Game.AmountQuestions)
            {
                Console.Clear();
                Console.WriteLine($"Ответ верный! Ваш выигрыш составляет {Score.UserScore} BYN.");
                string userChoice = UserChoice();
                if (userChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"{User.UserName}, игра окончена! Ваш выигрыш составляет {Score.UserScore} BYN.");
                    Score.ZeroScore();
                }
                else if (userChoice == "2")
                {
                    Save.GameSave();
                    Console.WriteLine("Игра успешно сохранена!");
                    Score.ZeroScore();
                }

            }
            else
                Console.WriteLine($"{User.UserName}, Вы победили, ответив на все вопросы. Ваш выигрыш составляет {Score.UserScore} BYN");
        }

        private string UserChoice()
        {
            Console.WriteLine("");
            Console.WriteLine("Чтобы продолжить игру, нажмите <Enter>");
            Console.WriteLine("Чтобы забрать деньги и выйти, введите <1>");
            Console.WriteLine("Чтобы сохранить игру и выйти, введите <2>");

            string userChoice = Console.ReadLine();

            if (userChoice == "" || userChoice == "1" || userChoice == "2")
            {
                return userChoice;
            }
            else
                return UserChoice();

        }
    }
}
