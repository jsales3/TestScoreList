using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadScores(List<int> scoresList)
        {
            try
            {

                StreamReader inputFile = File.OpenText("TestScores.txt");

                while (!inputFile.EndOfStream)
                {
                    scoresList.Add(int.Parse(inputFile.ReadLine()));
                }

                inputFile.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayScores(List<int> scoresList)
        {

            foreach(int score in scoresList)
            {
                testScoresListBox.Items.Add(score);
            }
        }

        private double Average(List<int> scoresList)
        {
            int total = 0;
            double average;

            foreach(int score in scoresList)
            {
                total += score;
            }

            average = (double)total / scoresList.Count;

            return average;
        }

        private int AboveAverage(List<int> scoresList)
        {
            int numAbove = 0;

            double avg = Average(scoresList);

            foreach(int score in scoresList)
            {
                if(score > avg)
                {
                    numAbove++;
                }
            }

            return numAbove;
        }

        private int BelowAverage(List<int> scoresList)
        {
            int numBelow = 0;

            double avg = Average(scoresList);

            foreach(int score in scoresList)
            {
                if(score < avg)
                {
                    numBelow++;
                }
            }

            return numBelow;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            double averageScore;
            int numAboveAverage;
            int numBelowAverage;

            List<int> scoresList = new List<int>();

            ReadScores(scoresList);

            DisplayScores(scoresList);

            averageScore = Average(scoresList);
            AverageLabel.Text = averageScore.ToString("n1");

            numAboveAverage = AboveAverage(scoresList);
            aboveAverageLabel.Text = numAboveAverage.ToString();

            numBelowAverage = BelowAverage(scoresList);
            belowAverageLabel.Text = numBelowAverage.ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
