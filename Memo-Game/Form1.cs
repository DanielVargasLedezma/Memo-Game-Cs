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

        private int past_i;

        private int past_j;

        public Memogame()
        {
            controller = new TableController();

            past_i = 0;
            
            past_j = 0;

            InitializeComponent();

            //ProbarJuego();
        }

        private void ChangeState(int k, int l)
        {
            this.tableLayoutPanel1.GetControlFromPosition(k, l).Enabled = false;
        }

        private int ActionPicked(int i, int j)
        {
            if(controller.RevealIfPossible(i, j))
            {
                controller.Num_Movimientos++;
                this.label4.Text = "" + controller.Num_Movimientos;
                controller.Consecutive_Moves = controller.Consecutive_Moves + 1;

                ChangeState(i, j);

                UpdateButtonsText();

                if (controller.Consecutive_Moves == 2)
                {
                    if (controller.CheckIfRevealedAreEquals())
                    {
                        int[] posiciones = {i, j, past_i, past_j};

                        controller.DiscoverIn(posiciones);

                        controller.Num_Parejas++;
                        this.label5.Text = "" + controller.Num_Parejas;

                        int max_parejas = controller.GetCols() * controller.GetRows() / 2;

                        if(controller.Num_Parejas == max_parejas)
                        {
                            this.tableLayoutPanel1.Enabled = false;

                            label9.Visible = true;

                            button18.Enabled = false;

                            past_i = i;

                            past_j = j;

                            return 420;
                        }

                        controller.Consecutive_Moves = 0;

                        past_i = i;

                        past_j = j;

                        return 1;
                    }
                    else
                    {
                        this.tableLayoutPanel1.GetControlFromPosition(past_i, past_j).Enabled = true;
                        
                        this.tableLayoutPanel1.GetControlFromPosition(i, j).Enabled = true;

                        controller.Consecutive_Moves = 0;

                        past_i = i;

                        past_j = j;

                        return -1;
                    }
                }
            }

            past_i = i;

            past_j = j;

            return 420;
        }

        private void ProbarJuego()
        {
            for (int i = 0; i < controller.GetRows(); i++)
            {
                for (int j = 0; j < controller.GetCols(); j++)
                {
                    this.tableLayoutPanel1.GetControlFromPosition(i, j).Text = "" + controller.GetValue(i, j);
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
            if(ActionPicked(0, 0) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ActionPicked(1, 0) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ActionPicked(2, 0) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ActionPicked(3, 0) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ActionPicked(0, 1) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ActionPicked(1, 1) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ActionPicked(2, 1) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ActionPicked(3, 1) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ActionPicked(0, 2) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ActionPicked(1, 2) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ActionPicked(2, 2) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (ActionPicked(3, 2) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ActionPicked(0, 3) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (ActionPicked(1, 3) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (ActionPicked(2, 3) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (ActionPicked(3, 3) == -1)
            {
                Thread.Sleep(3000);
                controller.HideRevealed();
                UpdateButtonsText();
            }
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
