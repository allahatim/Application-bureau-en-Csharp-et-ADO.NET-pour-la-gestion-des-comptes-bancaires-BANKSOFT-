using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
     
    public partial class Form3 : Form
    {
        
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-HQ4PJ9I;Initial Catalog=GestionBank;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form3()
        {
            InitializeComponent();
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
        // Function to generate a random 12-digit number
        private string GenerateRandomNumber()
        {
            Random random = new Random();
            long number = (long)(random.NextDouble() * (999999999999 - 100000000000 + 1) + 100000000000);
            return number.ToString();
        }

        // Function to check if a number already exists in the database
        private bool CheckIfNumberExists(string numC)
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM client WHERE numC = @numC", cnx);
            cmd.Parameters.AddWithValue("@numC", numC);
            int count = (int)cmd.ExecuteScalar();
            cnx.Close();
            return count > 0;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //// Generate a new random number
            string numC = GenerateRandomNumber();

            // Check if the random number already exists in the database
            while (CheckIfNumberExists(numC))
            {
                // If the number exists, generate a new one
                numC = GenerateRandomNumber();
            }

            // Insert the new client into the database
            cnx.Open();
            cmd = new SqlCommand("insert into client values('" + bunifuTextBox3.Text + "','" + Convert.ToInt64(numC) + "','" + bunifuTextBox2.Text + "','" + bunifuTextBox4.Text + "','" + bunifuDropdown1.Text + "','" + decimal.Parse(bunifuTextBox5.Text) + "')", cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();

            // Display a success message and clear the input fields
            MessageBox.Show("Client ajouté avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox5.Text = "";
            bunifuTextBox1.Focus();


        }
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                cnx.Open();

                cmd = new SqlCommand("select * from client where numC =@NUM", cnx);
                cmd.Parameters.AddWithValue("@NUM", Convert.ToInt64(bunifuTextBox1.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // load the data into the textboxes
                    bunifuTextBox2.Text = reader.GetValue(2).ToString();
                    bunifuTextBox3.Text = reader.GetValue(0).ToString();
                    bunifuTextBox4.Text = reader.GetValue(3).ToString();
                    bunifuTextBox5.Text = reader.GetValue(5).ToString();
                    bunifuDropdown1.Text = reader.GetValue(4).ToString();
                    reader.Close();
                }
                
                 else
                {
                    bunifuTextBox2.Text = "";
                    bunifuTextBox3.Text = "";
                    bunifuTextBox4.Text = "";
                    bunifuTextBox5.Text = "";
                    bunifuDropdown1.Text = "";
                 
                }

            }
            catch { }
            cnx.Close();
        }
      

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                decimal numC = Convert.ToDecimal(bunifuTextBox1.Text);
                string countQuery = "SELECT COUNT(*) FROM Transactions WHERE numC=@numC";
                SqlCommand countCmd = new SqlCommand(countQuery, cnx);
                countCmd.Parameters.AddWithValue("@numC", numC);
                int count = Convert.ToInt32(countCmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("The specified numC does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("delete from client where numC='" + bunifuTextBox1.Text + "'", cnx);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    MessageBox.Show("Client Supprimé avec succés", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuTextBox1.Text = "";
                    bunifuTextBox2.Text = "";
                    bunifuTextBox3.Text = "";
                    bunifuTextBox4.Text = "";
                    bunifuTextBox5.Text = "";
                    bunifuTextBox1.Focus();
                }
            }
            catch { }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("update client set titulaireC=@titulaire, cin=@cin, tel=@tel, solde=@solde, sexe=@sexe where numC=@NUM", cnx);
            cmd.Parameters.AddWithValue("@NUM", Convert.ToInt64(bunifuTextBox1.Text));
            cmd.Parameters.AddWithValue("@titulaire", bunifuTextBox2.Text);
            cmd.Parameters.AddWithValue("@cin", bunifuTextBox3.Text);
            cmd.Parameters.AddWithValue("@tel", bunifuTextBox4.Text);
            cmd.Parameters.AddWithValue("@solde", decimal.Parse(bunifuTextBox5.Text));
            cmd.Parameters.AddWithValue("@sexe", bunifuDropdown1.Text);
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Client Modifié avec succés", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox5.Text = "";
            bunifuTextBox1.Focus();
        }
    }
}
