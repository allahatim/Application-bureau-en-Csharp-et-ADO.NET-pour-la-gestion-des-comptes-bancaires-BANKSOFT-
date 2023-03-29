using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bunifuTextBox2.PasswordChar = '*';
            // Attendez 5 minutes avant de fermer la fenêtre

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text=="user" && bunifuTextBox2.Text=="2023")
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid user or password","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            bunifuImageButton2.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.PasswordChar == '\0')
            {
                // If the password character is not set, set it to * to mask the input
                bunifuTextBox2.PasswordChar = '*';
            }
            else
            {
                // If the password character is set, clear it to show the input
                bunifuTextBox2.PasswordChar = '\0';
            }
        }

     
    }
}
