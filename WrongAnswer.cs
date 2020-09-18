using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaire_GAME
{
    class WrongAnswer : Answer
    {
        public WrongAnswer(string answerText) : base(answerText)
        {

        }

        public override void Choose()
        {
            Console.Clear();
            Console.WriteLine($"Ответ неверный! {User.UserName}, ты проиграл, и уходишь домой без денег :(");
            Score.ZeroScore();
        }
    }
}
