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
    public partial class Form2 : Form
    {
        private List<int> numbers;
        private Form1 form1;

        public Form2(List<int> numbersInForm1)
        {
            InitializeComponent();
            this.numbers = numbersInForm1;
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (int number in numbers)
            {
                label1.Text = number.ToString();
            }
        }
    }
}