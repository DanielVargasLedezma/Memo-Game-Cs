using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Memo_Game
{
    public partial class Memogame : Form
    {
        private readonly TableController controller;

        public Memogame()
        {
            controller = new TableController();

            InitializeComponent();
        }

        private void ChangeState(int k, int l)
        {
            this.tableLayoutPanel1.GetControlFromPosition(k, l).Enabled = false;
        }

        private void ActionPicked(int i, int j)
        {
            if(controller.RevealIfPossible(i, j))
            {
                controller.Num_Movimientos++;
                controller.Consecutive_Moves++;

                ChangeState(i, j);

                UpdateButtonsText();

                controller.Consecutive_Moves++;

                if (controller.Consecutive_Moves == 2)
                {
                    if(controller.CheckIfRevealedAreEquals())
                    {
                        controller.Num_Parejas++;

                        int max_parejas = controller.GetCols() * controller.GetRows() / 2;

                        if(controller.Num_Parejas == max_parejas)
                        {
                            this.tableLayoutPanel1.Enabled = false;
                        }
                    }
                    else
                    {
                        Thread.Sleep(3000);

                        controller.HideRevealed();

                        UpdateButtonsText();
                    }
                }
                else
                {

                }
            }
        }

        private void UpdateButtonsText()
        {
            for (int i = 0; i < controller.GetRows(); i++)
            {
                for (int j = 0; j < controller.GetCols(); j++)
                {
                    if (controller.GetState(i, j) == 2 || controller.GetState(i, j) == 3)
                    {
                        this.tableLayoutPanel1.GetControlFromPosition(i, j).Text = "" + controller.GetValue(i, j);
                    }
                    else
                    {
                        this.tableLayoutPanel1.GetControlFromPosition(i, j).Text = "?";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActionPicked(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActionPicked(1, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
        }
    }
}
