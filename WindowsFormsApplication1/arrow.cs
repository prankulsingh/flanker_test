using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class arrow : Form
    {
        ArrayList arr = new ArrayList() { 0, 0, 0, 0, 0, 0, 0, 0,0,0,1,1,1,2,2,2, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2 };
        int correct = 0, incorrect = 0, popped, dir;
        long congruentTime = 0, incongruentTime = 0, neutralTime = 0;
        int statusFlag = 0;
        Stopwatch stopwatch;

        public arrow()
        {
            InitializeComponent();
        }

        void addTime(long time)
        {
            if(statusFlag == 0)
            {
                congruentTime += time;
            }
            else if(statusFlag == 1)
            {
                incongruentTime += time;
            }
            else
            {
                neutralTime += time;
            }
        }
        
        int setLables(int a)
        {
            statusFlag = a;
            label6.Text = "";
            Random random = new Random();
            int rn = random.Next(0, 2);
            if (a == 0)
            { // congruent
                if (rn == 0)
                {
                    label1.Text = "►";
                    label2.Text = "►";
                    label3.Text = "►";
                    label4.Text = "►";
                    label5.Text = "►";
                }
                else
                {
                    label1.Text = "◄";
                    label2.Text = "◄";
                    label3.Text = "◄";
                    label4.Text = "◄";
                    label5.Text = "◄";
                }
            }
            else if (a == 1)
            { // incongruent
                if (rn == 0)
                {
                    label1.Text = "◄";
                    label2.Text = "◄";
                    label3.Text = "►";
                    label4.Text = "◄";
                    label5.Text = "◄";
                }
                else
                {
                    label1.Text = "►";
                    label2.Text = "►";
                    label3.Text = "◄";
                    label4.Text = "►";
                    label5.Text = "►";
                }
            }
            else
            { // neutral

                label1.Text = "■";
                label2.Text = "■";
                label4.Text = "■";
                label5.Text = "■";

                if (rn == 0)
                {
                    label3.Text = "►";
                }
                else
                {
                    label3.Text = "◄";
                }
            }
            stopwatch = Stopwatch.StartNew();
            return rn;
        }

        public void Wait(int ms)
        {
            this.KeyPreview = false;
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
            this.KeyPreview = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void reset(string s)
        {
            label6.Text = s;
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void arrow_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Keep your eyes on the Middle arrow. Press 'A' for Left and 'L' for Right. Your Test will start as soon as you press OK.");

            Random random = new Random();
            int randomNumber = random.Next(0, arr.Count);
            popped = (int) arr[randomNumber];
            arr.RemoveAt(randomNumber);

            dir = setLables(popped);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            

        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                stopwatch.Stop();
                addTime(stopwatch.ElapsedMilliseconds);
                if (dir == 0)
                {
                    incorrect++;
                    reset("Incorrect!");
                    Wait(1000);
                }
                else
                {
                    correct++;
                    reset("Correct!");
                    Wait(1000);
                }

                if (arr.Count == 0)
                {
                    MessageBox.Show("Correct answers = " + correct + "\nIncorrect answers = " + incorrect + "\nCongruent avg. RT = " + congruentTime / 10 + " ms\nIncongruent avg. RT = " + incongruentTime / 10 + " ms\nNeutral avg. RT = " + neutralTime / 10 + " ms\n\nResponse Conflict (Incongruent RT- Congruent RT) = " + (incongruentTime - congruentTime) / 10);
                    this.Close();
                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(0, arr.Count);
                    popped = (int)arr[randomNumber];
                    arr.RemoveAt(randomNumber);
                   dir = setLables(popped);
                }

            }
            if (e.KeyCode == Keys.L)
            {
                stopwatch.Stop();
                addTime(stopwatch.ElapsedMilliseconds);
                if (dir == 0)
                {
                    correct++;
                    reset("Correct!");

                    Wait(1000);
                }
                else
                {
                    incorrect++;
                    reset("Incorrect!");
                    Wait(1000);
                }

                if (arr.Count == 0)
                {
                    MessageBox.Show("Correct answers = " + correct + "\nIncorrect answers = " + incorrect + "\nCongruent avg. RT = " + congruentTime / 10 + " ms\nIncongruent avg. RT = " + incongruentTime / 10 + " ms\nNeutral avg. RT = " + neutralTime / 10 + " ms\n\nResponse Conflict (Incongruent RT- Congruent RT) = " + (incongruentTime - congruentTime)/10);
                    this.Close();
                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(0, arr.Count);
                    popped = (int)arr[randomNumber];
                    arr.RemoveAt(randomNumber);
                    dir = setLables(popped);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
