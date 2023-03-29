using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-HQ4PJ9I;Initial Catalog=GestionBank;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form5()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label6.Visible = true;
                    bunifuTextBox2.Visible = true;
                    bunifuTextBox3.Visible = true;
                    bunifuTextBox4.Visible = true;
                    bunifuTextBox5.Visible = true;
                    bunifuDropdown1.Visible = true;
                    // load the data into the textboxes
                    bunifuTextBox2.Text = reader.GetValue(2).ToString();
                    bunifuTextBox3.Text = reader.GetValue(0).ToString();
                    bunifuTextBox4.Text = reader.GetValue(3).ToString();
                    bunifuDropdown1.Text = reader.GetValue(4).ToString();
                    bunifuTextBox5.Focus();
                }
                else
                {
                    bunifuTextBox2.Text = "";
                    bunifuTextBox3.Text = "";
                    bunifuTextBox4.Text = "";
                    bunifuTextBox5.Text = "";
                    bunifuDropdown1.Text = "";
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label6.Visible = false;
                    bunifuTextBox2.Visible = false;
                    bunifuTextBox3.Visible = false;
                    bunifuTextBox4.Visible = false;
                    bunifuTextBox5.Visible = false;
                    bunifuDropdown1.Visible = false;
                }
                reader.Close();

            }
            catch {
                
            }
            cnx.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(bunifuTextBox5.Text) > 100)
                {
                    cnx.Open();
                    cmd = new SqlCommand("update client set solde=solde+@solde where numC=@NUM", cnx);
                    cmd.Parameters.AddWithValue("@NUM", Convert.ToInt64(bunifuTextBox1.Text));
                    cmd.Parameters.AddWithValue("@solde", decimal.Parse(bunifuTextBox5.Text));
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("INSERT INTO transactions (numC, montant, type, dateT) VALUES (@numC, @montant, @type, @dateT)", cnx);
                    cmd.Parameters.AddWithValue("@numC", Convert.ToInt64(bunifuTextBox1.Text));
                    cmd.Parameters.AddWithValue("@montant", decimal.Parse(bunifuTextBox5.Text));
                    cmd.Parameters.AddWithValue("@type", "Dépôt");
                    cmd.Parameters.AddWithValue("@dateT", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    MessageBox.Show("Dépot fait avec succés", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuTextBox1.Text = "";
                    bunifuTextBox2.Text = "";
                    bunifuTextBox3.Text = "";
                    bunifuTextBox4.Text = "";
                    bunifuTextBox5.Text = "";
                    bunifuDropdown1.Text = "";
                    bunifuTextBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Merci de déposer 100DH au minimum", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd = new SqlCommand("select solde from client where numC = @NUM", cnx);
                cmd.Parameters.AddWithValue("@NUM", Convert.ToInt64(bunifuTextBox1.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    decimal solde = Convert.ToDecimal(reader.GetValue(0).ToString());
                    if (solde < Convert.ToDecimal(bunifuTextBox5.Text))
                    {
                        MessageBox.Show("votre solde est insuffisant.\n le solde est: " + solde, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        reader.Close();
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2 = new SqlCommand("update client set solde=solde-@solde where numC=@NUM", cnx);
                        cmd2.Parameters.AddWithValue("@NUM", Convert.ToInt64(bunifuTextBox1.Text));
                        cmd2.Parameters.AddWithValue("@solde", decimal.Parse(bunifuTextBox5.Text));
                        cmd2.ExecuteNonQuery();
                        cmd = new SqlCommand("INSERT INTO transactions (numC, montant, type, dateT) VALUES (@numC, @montant, @type, @dateT)", cnx);
                        cmd.Parameters.AddWithValue("@numC", Convert.ToInt64(bunifuTextBox1.Text));
                        cmd.Parameters.AddWithValue("@montant", decimal.Parse(bunifuTextBox5.Text));
                        cmd.Parameters.AddWithValue("@type", "Retrait");
                        cmd.Parameters.AddWithValue("@dateT", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Retrait fait avec succès", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bunifuTextBox1.Text = "";
                        bunifuTextBox2.Text = "";
                        bunifuTextBox3.Text = "";
                        bunifuTextBox4.Text = "";
                        bunifuTextBox5.Text = "";
                        bunifuDropdown1.Text = "";
                        bunifuTextBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                cnx.Close();
            }
        }

    
    }
    }

