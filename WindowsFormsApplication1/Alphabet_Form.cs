using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Alphabet_Form : Form
    {
        int[] type = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3 };
        char[] char_arr = { 'X', 'C', 'N', 'M' };
        Random rnd = new Random();
        int rnd_no;
        char ch2;
        int correct = 0;
        int incorrect = 0;
        Stopwatch stopwatch;
        long congrent_avg = 0;
        long incongruent_avg = 0;
        long neutral_avg = 0;
        int clas = 0;
        public Alphabet_Form()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alphabet_Form_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Keep your eyes on the Middle alphabet. Press 'A' for X and C and 'L' for N and M. Your Test will start as soon as you press OK.");
            for (int i = 0; i < 30; i++)
            {
                rnd_no = rnd.Next(0, 30);
                int temp = type[i];
                type[i] = type[rnd_no];
                type[rnd_no] = temp;
            }
            this.KeyDown += form_keydown;
            doit();
        }
        public void Wait(int ms)
        {
            this.KeyDown -= form_keydown;
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
            this.KeyDown += form_keydown;
        }
        void doit()
        {
            label2.Text = "";
            clas = type[0];
            if (type[0] == 1)
            {
                rnd_no = rnd.Next(0, 4);
                ch2 = char_arr[rnd_no];
                char ch = char_arr[rnd_no];
                label1.Text = ch + " " + ch + " " + ch + " " + ch + " " + ch;

            }
            else if (type[0] == 2)
            {
                rnd_no = rnd.Next(0, 2);
                int rnd_no2 = rnd.Next(0, 2);
                char ch;

                if (rnd_no == 0)
                {
                    ch = char_arr[rnd_no];
                    ch2 = char_arr[2 + rnd_no2];
                }
                else
                {
                    ch = char_arr[2 + rnd_no];
                    ch2 = char_arr[rnd_no2];
                }
                label1.Text = ch + " " + ch + " " + ch2 + " " + ch + " " + ch;
            }
            else
            {
                rnd_no = rnd.Next(0, 4);
                ch2 = char_arr[rnd_no];
                label1.Text = "+ + " + ch2 + " + +";
            }
            stopwatch = Stopwatch.StartNew();
            type = type.Skip(1).ToArray();

        }
        void form_keydown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                stopwatch.Stop();
                if (clas == 1)
                    congrent_avg += stopwatch.ElapsedMilliseconds;
                else if (clas == 2)
                    incongruent_avg += stopwatch.ElapsedMilliseconds;
                else
                    neutral_avg += stopwatch.ElapsedMilliseconds;
                if (ch2 == 'X' || ch2 == 'C')
                {
                    //correct
                    correct++;
                    //label2.Text = "correct :" + correct.ToString() + " incorrect : " + incorrect + " time: " + stopwatch.ElapsedMilliseconds;
                    label2.Text = "Correct!";
                    label1.Text = "";
                    Wait(1000);

                    if (type.Length == 0)
                    {
                        //MessageBox.Show("cong " + congrent_avg + " incong " + incongruent_avg + "neutral " + neutral_avg);
                        MessageBox.Show("Correct answers = " + correct + "\nIncorrect answers = " + incorrect + "\nCongruent avg. RT = " + congrent_avg / 10 + " ms\nIncongruent avg. RT = " + incongruent_avg / 10 + " ms\nNeutral avg. RT = " + neutral_avg / 10 + " ms\n\nResponse Conflict (Incongruent RT- Congruent RT) = " + (incongruent_avg - congrent_avg) / 10);
                        this.Close();
                    }
                    else
                        doit();
                }
                else
                {
                    incorrect++;
                    //label2.Text = "correct :" + correct.ToString() + " incorrect : " + incorrect + " time: " + stopwatch.ElapsedMilliseconds;
                    label2.Text = "Incorrect!";
                    label1.Text = "";
                    Wait(1000);

                    if (type.Length == 0)
                    {
                        //MessageBox.Show("cong " + congrent_avg + " incong " + incongruent_avg + "neutral " + neutral_avg);
                        MessageBox.Show("Correct answers = " + correct + "\nIncorrect answers = " + incorrect + "\nCongruent avg. RT = " + congrent_avg / 10 + " ms\nIncongruent avg. RT = " + incongruent_avg / 10 + " ms\nNeutral avg. RT = " + neutral_avg / 10 + " ms\n\nResponse Conflict (Incongruent RT- Congruent RT) = " + (incongruent_avg - congrent_avg) / 10);
                        this.Close();
                    }

                    else
                        doit();
                    //incorrect
                }
            }
            if (e.KeyCode == Keys.L)
            {
                stopwatch.Stop();
                if (clas == 1)
                    congrent_avg += stopwatch.ElapsedMilliseconds;
                else if (clas == 2)
                    incongruent_avg += stopwatch.ElapsedMilliseconds;
                else
                    neutral_avg += stopwatch.ElapsedMilliseconds;
                if (ch2 == 'N' || ch2 == 'M')
                {
                    //correct
                    correct++;
                    //label2.Text = "correct :" + correct.ToString() + " incorrect : " + incorrect + " time: " + stopwatch.ElapsedMilliseconds;
                    label2.Text = "Correct!";
                    label1.Text = "";
                    Wait(1000);

                    if (type.Length == 0)
                    {
                        MessageBox.Show("Correct answers = " + correct + "\nIncorrect answers = " + incorrect + "\nCongruent avg. RT = " + congrent_avg / 10 + " ms\nIncongruent avg. RT = " + incongruent_avg / 10 + " ms\nNeutral avg. RT = " + neutral_avg / 10 + " ms\n\nResponse Conflict (Incongruent RT- Congruent RT) = " + (incongruent_avg - congrent_avg) / 10);
                        this.Close();
                    }

                    else
                        doit();
                }
                else
                {
                    incorrect++;
                    //label2.Text = "correct :" + correct.ToString() + " incorrect : " + incorrect + " time: " + stopwatch.ElapsedMilliseconds;
                    label2.Text = "Incorrect!";
                    label1.Text = "";
                    Wait(1000);

                    if (type.Length == 0)
                    {
                        MessageBox.Show("Correct answers = " + correct + "\nIncorrect answers = " + incorrect + "\nCongruent avg. RT = " + congrent_avg / 10 + " ms\nIncongruent avg. RT = " + incongruent_avg / 10 + " ms\nNeutral avg. RT = " + neutral_avg / 10 + " ms\n\nResponse Conflict (Incongruent RT- Congruent RT) = " + (incongruent_avg - congrent_avg) /10);
                        this.Close();
                    }

                    else
                        doit();

                    //incorrect
                }
            }

        }
    }
}
