using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Millionaire_GAME
{
    class Game
    {
        public static int NumberQuestion;

        public static int AmountQuestions { get; private set; } = 10;        

        private Question[] question = new Question[Game.AmountQuestions];       

        private void PrepareQuestions()
        {
            for (int i = 0; i < Game.AmountQuestions; i++)
            {
                string savePath = $"C:\\Games\\Millionaire\\Questions\\{i}.txt";

                FileInfo userSave = new FileInfo(savePath);
                if (!userSave.Exists)
                {
                    throw new FileNotFoundException(savePath);
                }
                FileStream saveDataStream = userSave.OpenRead();
                using (StreamReader myStream = new StreamReader(saveDataStream, Encoding.Default))
                {
                    string[] userData = File.ReadAllLines(savePath, Encoding.Default);

                    question[i] = new Question(userData[0]);
                    question[i].Answers = new Answer[4];
                    question[i].Answers[0] = new CorrectAnswer(userData[1]);
                    question[i].Answers[1] = new WrongAnswer(userData[2]);
                    question[i].Answers[2] = new WrongAnswer(userData[3]);
                    question[i].Answers[3] = new WrongAnswer(userData[4]);                   

                }
            }
        }

        private int UserAnswer()
        {
            Console.WriteLine("Введите номер правильного ответа:");
            string userInput = Console.ReadLine();
            int j = 0;

            if (userInput == "1")
            {
                return j;
            }
            else if (userInput == "2")
            {
                j = 1;
                return j;
            }
            else if (userInput == "3")
            {
                j = 2;
                return j;
            }
            else if (userInput == "4")
            {
                j = 3;
                return j;
            }
            else
            {
                Console.WriteLine("!!!Чтобы ответить на вопрос, введите 1, 2, 3 или 4!!!");
                return UserAnswer();
            }
        }

        public void StartQuestions()
        {
            PrepareQuestions();

            for (int i = Game.NumberQuestion; i < Game.AmountQuestions; i++)
            {
                Console.Clear();                               

                Console.WriteLine($"Вопрос № {i + 1}");
                question[i].Print(question[i]);

                int j = UserAnswer();

                Answer UserChoice = question[i].Answers[j];
                UserChoice.Choose();                

                if (Score.UserScore == 0)
                    break;
            }
        }   
      
        private void Rules()
        {
            Console.Clear();
            Console.WriteLine("Ознакомитесь с правилами игры:");
            Console.WriteLine("- Игроку необходимо ответить на серию вопросом.");
            Console.WriteLine("- Первый правильный ответ приносит игроку 100 BYN.");
            Console.WriteLine("- Каждый следующий правильный ответ удваивает количество выигранных денег.");
            Console.WriteLine("- Если игрок ответил неверно, весь выигрыш сгорает.");
            Console.WriteLine("");
        }

        private string GetUserChoice()
        {
            Console.WriteLine("");
            Console.WriteLine("Чтобы начать новую игру, нажмите <Enter>\nЧтобы загрузить сохраннную игру, нажмите <1>");
            string userChoice = Console.ReadLine();

            if (userChoice == "" || userChoice == "1")
            {
                return userChoice;
            }
            else
                return GetUserChoice();
        }

        public void StartGame()
        {
            string userChoice = GetUserChoice();
            if (userChoice == "")
            {
                Rules();
                Score.ZeroScore();
                User.UserNameInput();
                
            }
            else if (userChoice == "1")
            {
                Load.LoadSaveGame();
            }
        }
    }
}
