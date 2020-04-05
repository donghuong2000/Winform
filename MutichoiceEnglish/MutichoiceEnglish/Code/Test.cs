using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutichoiceEnglish.Code
{
    class Test
    {
        public string Title { get; set; }
        public List<Question> questions { get; set; }

        public Test()
        {
            questions = new List<Question>();
        }
        public Test(string title)
        {
            this.Title = title;
            questions = new List<Question>();
        }
        public Test(string title,List<Question> questions)
        {
            this.Title = title;
            this.questions = questions;
        }
    }
}
