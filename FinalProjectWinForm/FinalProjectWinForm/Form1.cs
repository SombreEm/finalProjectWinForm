using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProjectWinForm.Form1.PlayerCard;

namespace FinalProjectWinForm
{
    public partial class Form1 : Form
    {
        private PlayerCard playerCard;
        private LottoGame lottoGame;
        private int winAttempts = 0;
        private int consecutiveWins = 0;
        private int consecutiveLosses = 0;
        public Form1()
        {
            InitializeComponent();
            lottoGame = new LottoGame();
        }
        private void DisplayPlayerNumbers()
        {
            label9.Text = string.Join(", ", playerCard.Numbers);
        }

        public class PlayerCard
        {
            public List<int> Numbers { get; private set; }

            public PlayerCard(int numberOfNumbers)
            {
                Numbers = GenerateRandomNumbers(numberOfNumbers);
            }

            private List<int> GenerateRandomNumbers(int numberOfNumbers)
            {
                Random random = new Random();
                HashSet<int> numbers = new HashSet<int>();

                while (numbers.Count < numberOfNumbers)
                {
                    int num = random.Next(1, 50);
                    numbers.Add(num);
                }

                return numbers.ToList();
            }
        }

        public class LottoGame
        {
            public List<int> GameNumbers { get; private set; }
            public int Wins { get; private set; }
            public int Losses { get; private set; }

            public LottoGame()
            {
                GameNumbers = new List<int>();
                Wins = 0;
                Losses = 0;
            }

            public void GenerateGameNumbers(List<int> excludedNumbers)
            {
                GameNumbers = GenerateRandomNumbers(excludedNumbers);
            }

            private List<int> GenerateRandomNumbers(List<int> excludedNumbers)
            {
                Random random = new Random();
                HashSet<int> numbers = new HashSet<int>();

                while (numbers.Count < 6)
                {
                    int num = random.Next(1, 50);
                    if (!excludedNumbers.Contains(num))
                    {
                        numbers.Add(num);
                    }
                }

                return numbers.ToList();
            }

            public bool CheckWin(PlayerCard playerCard, ref int winAttempts)
            {
                bool hasWin = playerCard.Numbers.Any(num => GameNumbers.Contains(num));

                if (winAttempts >= 5)
                {
                    hasWin = true;
                    winAttempts = 0; 
                }

                if (hasWin)
                {
                    Wins++;
                }
                else
                {
                    Losses++;
                }

                return hasWin;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOfNumbers;
            if (!int.TryParse(textBox1.Text, out numberOfNumbers) || numberOfNumbers < 1 || numberOfNumbers > 10)
            {
                MessageBox.Show("Введіть коректну кількість чисел (від 1 до 10).");
                return;
            }

            playerCard = new PlayerCard(numberOfNumbers);
            lottoGame.GenerateGameNumbers(playerCard.Numbers);
            bool isWin = lottoGame.CheckWin(playerCard, ref winAttempts);

            if (!isWin) winAttempts++;

            label7.Text =string.Join(", ", lottoGame.GameNumbers);

            if (isWin)
            {
                consecutiveWins++;
                consecutiveLosses = 0;
                if (consecutiveWins == 5)
                {
                    MessageBox.Show("Ви виграли 1000 грн!");
                    consecutiveWins = 0;
                }
                label11.Text = "Ви виграли!";
            }
            else
            {
                consecutiveLosses++;
                consecutiveWins = 0;
                if (consecutiveLosses == 5)
                {
                    MessageBox.Show("Ви програли 1000 грн!");
                    consecutiveLosses = 0;
                }
                label11.Text = "Спробуйте ще раз!";
            }

            label4.Text = lottoGame.Wins.ToString();
            label5.Text = lottoGame.Losses.ToString();

            DisplayPlayerNumbers();
        }
    }
}
