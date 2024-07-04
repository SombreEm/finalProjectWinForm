using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectWinForm
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        List<int> numbers = new List<int>();
        Form2 f;
        public Button[] buttons;
        private int redButtonCount = 0;
        private bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            InitializeButtonTexts();
            buttons = new Button[] {
                button2, button3, button4, button5, button6, button7, button8, button9,
                button10, button11, button12, button13, button14, button15, button16, button17,
                button18, button19, button20, button21, button22
            };
            foreach (var button in buttons)
            {
                button.MouseDown += Button_MouseDown;
            }
        }

        private void InitializeButtonTexts()
        {
            button2.Text = "2";
            button3.Text = "12";
            button4.Text = "16";
            button5.Text = "52";
            button6.Text = "3";
            button7.Text = "10";
            button8.Text = "43";
            button9.Text = "23";
            button10.Text = "71";
            button11.Text = "66";
            button12.Text = "18";
            button13.Text = "27";
            button14.Text = "33";
            button15.Text = "99";
            button16.Text = "6";
            button17.Text = "51";
            button18.Text = "39";
            button19.Text = "77";
            button20.Text = "81";
            button21.Text = "92";
            button22.Text = "84";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int randomNumber;
            do
            {
                randomNumber = rand.Next(0, 101);
            } while (numbers.Contains(randomNumber));

            numbers.Add(randomNumber);

            if (numbers.Count >= 100)
            {
                timer1.Stop();
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.BackColor = Color.Red;
                clickedButton.Enabled = false;
                redButtonCount++;

                if (redButtonCount == buttons.Length)
                {
                    label2.Text = "Бінго";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                timer1.Start();
                InitializeButtonTexts();
                f = new Form2(numbers);
                f.Show();
                gameStarted = true;
            }
        }
    }
}
