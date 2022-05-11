using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
namespace Tedris
{
    public partial class Form1 : Form
    {
        Model model = new Model();
        public Form1()
        {
            InitializeComponent();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            datasGridView.CurrentRow.Selected = true;
           
            model.ID=(int)datasGridView.Rows[e.RowIndex].Cells["ID"].Value;
            model.muellim = datasGridView.Rows[e.RowIndex].Cells["muellim"].Value.ToString();
            model.qrup = datasGridView.Rows[e.RowIndex].Cells["qrup"].Value.ToString();
            model.fenn = datasGridView.Rows[e.RowIndex].Cells["fenn"].Value.ToString();
            model.muhazire_payiz_saat = (int)datasGridView.Rows[e.RowIndex].Cells["muhazire_payiz_saat"].Value;
            model.muhazire_yaz_saat = (int)datasGridView.Rows[e.RowIndex].Cells["muhazire_yaz_saat"].Value;
            model.seminar_payiz_saat = (int)datasGridView.Rows[e.RowIndex].Cells["seminar_payiz_saat"].Value;
            model.seminar_yaz_saat = (int)datasGridView.Rows[e.RowIndex].Cells["seminar_yaz_saat"].Value;
            model.laboratoriya_payiz_saat = (int)datasGridView.Rows[e.RowIndex].Cells["laboratoriya_payiz_saat"].Value;
            model.laboratoriya_yaz_saat = (int)datasGridView.Rows[e.RowIndex].Cells["laboratoriya_yaz_saat"].Value;
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            datasGridView.DataSource = GetData();
        }
        public DataTable GetData()
        {
            string connectionstring = @"Data Source=.;Initial Catalog=diplom;Integrated Security=True";

            DataTable dt = new DataTable(); 
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                using(SqlCommand command = new SqlCommand("select * from tedris_yuku",connection))
                {
                    connection.Open();
                    SqlDataReader reader=command.ExecuteReader();  
                    dt.Load(reader);
                }
            }
            return dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Hide();
         
            AddForm addForm =new AddForm(null);
            addForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            AddForm addForm = new AddForm(model);
            addForm.ShowDialog();

            
        }

     

        public void DeleteItem(int id)
        {

            string connectionString = @"Data Source=.;Initial Catalog=diplom;Integrated Security=True";

            string deleteSql = $@" DELETE FROM  tedris_yuku WHERE ID={id}";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteSql, cn))
            {
                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Silmək istədiyinizə əminsinizmi?", "Sil", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                  DeleteItem(model.ID);
                System.Windows.Forms.MessageBox.Show("Melumat silindi!");
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }

            else
            {
                //Code for Cancel action
                System.Windows.Forms.MessageBox.Show("ABORT");
            }
        }
    }
}
