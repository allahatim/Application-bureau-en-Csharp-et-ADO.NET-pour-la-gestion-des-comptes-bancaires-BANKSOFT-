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
    public partial class Form6 : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-HQ4PJ9I;Initial Catalog=GestionBank;Integrated Security=True");
        DataTable table = new DataTable();
        public Form6()
        {
            InitializeComponent();
            bunifuDropdown1.SelectedIndex = 0;
            cnx.Open();
            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            string query = "SELECT * FROM Transactions WHERE dateT >= @start AND dateT < @end";
            SqlCommand cmd = new SqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@start", today);
            cmd.Parameters.AddWithValue("@end", now);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            table.Clear();
            adapter.Fill(table);
            bunifuDataGridView1.DataSource = table;
            cnx.Close();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            cnx.Open();
            if (bunifuDropdown1.Text== "Toutes")
            {
                string query = "SELECT * FROM Transactions WHERE dateT between @dateDu AND @dateAU";
                SqlCommand cmd = new SqlCommand(query, cnx);
                DateTime dateDu = Convert.ToDateTime(bunifuDatePicker1.Text);
                DateTime dateAU = Convert.ToDateTime(bunifuDatePicker2.Text);
                cmd.Parameters.AddWithValue("@dateDu", dateDu);
                cmd.Parameters.AddWithValue("@dateAU", dateAU);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                table.Clear();
                adapter.Fill(table);
                bunifuDataGridView1.DataSource = table;
                cnx.Close();
            }
            else if (bunifuDropdown1.Text == "Retraits")
            {
                string query = "SELECT * FROM Transactions WHERE type='Retrait' and dateT between @dateDu AND @dateAU";
                SqlCommand cmd = new SqlCommand(query, cnx);
                DateTime dateDu = Convert.ToDateTime(bunifuDatePicker1.Text);
                DateTime dateAU = Convert.ToDateTime(bunifuDatePicker2.Text);
                cmd.Parameters.AddWithValue("@dateDu", dateDu);
                cmd.Parameters.AddWithValue("@dateAU", dateAU);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                table.Clear();
                adapter.Fill(table);
                bunifuDataGridView1.DataSource = table;
                cnx.Close();
            }
            else if (bunifuDropdown1.Text == "Dépôts")
            {
                string query = "SELECT * FROM Transactions WHERE type='Dépôt' and dateT between @dateDu AND @dateAU";
                SqlCommand cmd = new SqlCommand(query, cnx);
                DateTime dateDu = Convert.ToDateTime(bunifuDatePicker1.Text);
                DateTime dateAU = Convert.ToDateTime(bunifuDatePicker2.Text);
                cmd.Parameters.AddWithValue("@dateDu", dateDu);
                cmd.Parameters.AddWithValue("@dateAU", dateAU);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                table.Clear();
                adapter.Fill(table);
                bunifuDataGridView1.DataSource = table;
                cnx.Close();
            }
            cnx.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            CrystalReport2 rp2 = new CrystalReport2();
            rp2.SetDataSource(table);
            form8.crystalReportViewer1.ReportSource = rp2;
            form8.crystalReportViewer1.Refresh();


        }
    }
}
