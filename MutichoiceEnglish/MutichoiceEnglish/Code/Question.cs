using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutichoiceEnglish.Code
{
    class Question
    {
        public string Title { get; set; }
        public List<Answer> answers { get; set; }

        public string RightAnswer { get; set; }
        public string Descretion { get; set; }
        public bool isRightAnswer { get; set; }
        public bool isSubmit { get; set; }

        public Question()
        {
            answers = new List<Answer>();
            isRightAnswer = false;
            isSubmit = false;
        }
        public Question(string title)
        {
            answers = new List<Answer>();
            this.Title = title;
            isRightAnswer = false;
            isSubmit = false;
        }
        public Question(string title,List<Answer> answers)
        {
            
            this.Title = title;
            this.answers = answers;
            isRightAnswer = false;
            isSubmit = false;
        }
        

    }
}
