using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaire_GAME
{
    abstract class Answer
    {
        public Answer(string answerText)
        {
            this.AnswerText = answerText;
        }

        public string AnswerText;

        public abstract void Choose();
    }
}
