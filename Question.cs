using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaire_GAME
{
    class Question
    {
        public Question(string questionText)
        {
            this.QuestionText = questionText;
        }

        public string QuestionText;
        public Answer[] Answers;

        public void Print(Question question)
        {
            Console.WriteLine(question.QuestionText);

            Random random = new Random();
            for (int i = question.Answers.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                Answer temp = question.Answers[j];
                question.Answers[j] = question.Answers[i];
                question.Answers[i] = temp;
            }

            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i].AnswerText}");
            }
        }       
    }
}
