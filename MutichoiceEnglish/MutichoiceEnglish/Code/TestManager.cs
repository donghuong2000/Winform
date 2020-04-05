using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutichoiceEnglish.Code
{
    static class TestManager
    {
        public static void ReadData(Test bai1)
        { 
            
            StreamReader reader = new StreamReader("data.txt");
            string line;
            bai1.Title = reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                
                Question question1 = new Question();
                question1.Title = line;
                Answer answer1 = new Answer();
                answer1.content = reader.ReadLine();
                Answer answer2 = new Answer();
                answer2.content = reader.ReadLine();
                Answer answer3 = new Answer();
                answer3.content = reader.ReadLine();
                Answer answer4 = new Answer();
                answer4.content = reader.ReadLine();
                question1.RightAnswer = reader.ReadLine();
                question1.Descretion = reader.ReadLine();
                question1.answers.Add(answer1);
                question1.answers.Add(answer2);
                question1.answers.Add(answer3);
                question1.answers.Add(answer4);
                bai1.questions.Add(question1);
            }
            reader.Close(); 
        }

    }
}
