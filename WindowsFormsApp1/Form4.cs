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
    public partial class Form4 : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-HQ4PJ9I;Initial Catalog=GestionBank;Integrated Security=True");
        DataTable table = new DataTable();
        public Form4()
        {
            InitializeComponent();
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGroupBox1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
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
                string query = "SELECT * FROM Transactions WHERE numC=@numC and dateT between @dateDu AND @dateAU";
                SqlCommand cmd = new SqlCommand(query, cnx);
                DateTime dateDu = Convert.ToDateTime(bunifuDatePicker1.Text);
                DateTime dateAU = Convert.ToDateTime(bunifuDatePicker2.Text);
                cmd.Parameters.AddWithValue("@dateDu", dateDu);
                cmd.Parameters.AddWithValue("@dateAU", dateAU);
                cmd.Parameters.AddWithValue("@numC", numC);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                table.Clear();
                adapter.Fill(table);
                bunifuDataGridView1.DataSource = table;

            }
            cnx.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'gestionBankDataSet.Transactions'. Vous pouvez la déplacer ou la supprimer selon les besoins.

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            CrystalReport1 rp1 = new CrystalReport1();
            rp1.SetDataSource(table);
            form7.crystalReportViewer1.ReportSource = rp1;
            form7.crystalReportViewer1.Refresh();
        }
    }
}
