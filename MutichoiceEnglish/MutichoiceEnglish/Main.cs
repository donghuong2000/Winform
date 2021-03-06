﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MutichoiceEnglish.Code;

namespace MutichoiceEnglish
{
    public partial class Main : Form
    {
        // tạo 1 bài test tiếng anh
        private Test ts = new Test();
        private int id;
        public Main()
        {
            InitializeComponent();
            TestManager.ReadData(ts);
            //dấu nút why đi
            btnWhy.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // đọc dữ liệu trong file data.txt ở trong file debug rồi ném vào bài test tiếng anh( gồm các câu hỏi và câu trả lời
            TestManager.ReadData(ts);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = ts.questions[0].Title;
            for (int i = 0; i < ts.questions[0].answers.Count; i++)
            {
                listbox.Items.Add(ts.questions[0].answers[i].content, false);
            }
            
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            //tạo ra danh sách cái button câu hỏi
            CreateButtonQuestion(ts.questions.Count);
        }
        private void CreateButtonQuestion(int n)
        {// tại kích thước của button 
            int Width = 39;
            int Height = 36;
            //vị trí bắt đầu
            Point stpoint = new Point(3, 3);
            for (int i = 1; i < n+1; i++)
            {
                Button button = new Button();
                button.Width = Width;
                button.Height = Height;
                button.Location = stpoint;
                // vị trí sau cách vị trí trước 1 khoản rộng bằng width
                stpoint.X += Width;
                button.Text = i.ToString();
                //tạo sự kiện nhấn
                button.Click += Button_Click;
                // add vô panel 
                panel1.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            // khi nhấn vào thì nó sẽ chuyển sang câu hỏi số  i
            SwitchQuestion(int.Parse(button.Text));
            id = int.Parse(button.Text);
        }
        private void SwitchQuestion(int n)
        {
            Status.Text = "";
            listbox.Items.Clear();
            label1.Text = ts.questions[n-1].Title;
            for (int i = 0; i < ts.questions[n-1].answers.Count; i++)
            {
                listbox.Items.Add(ts.questions[n-1].answers[i].content, false);
            }
            if(ts.questions[n - 1].isSubmit)
            {
                btnWhy.Show();
                btnSubmit.Enabled = false;
            } 
            else
            {
                btnWhy.Hide();
                btnSubmit.Enabled = true;
            }    
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (listbox.CheckedItems.Count == 1)
            {
                if (listbox.CheckedItems[0].ToString() == ts.questions[id - 1].RightAnswer)
                {
                    panel1.Controls[id - 1].BackColor = Color.DarkGreen;
                    Status.ForeColor = Color.DarkGreen;
                    Status.Text = "Right anwser";

                }
                else
                {
                    Status.ForeColor = Color.Red;
                    Status.Text = "Wrong anwser";
                    panel1.Controls[id - 1].BackColor = Color.DarkRed;
                }
                ts.questions[id - 1].isSubmit = true;
                btnSubmit.Enabled = false;
                btnWhy.Show();
            }
            else
            {
                MessageBox.Show("choose Maximun one answer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWhy_Click(object sender, EventArgs e)
        {
            var a= MessageBox.Show("bạn có muốn đi đến trang web có lời giải thích "+ts.questions[id - 1].Descretion, "Lời giải thích", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(a == DialogResult.Yes)
                Process.Start(ts.questions[id - 1].Descretion);
        }
    }
}
