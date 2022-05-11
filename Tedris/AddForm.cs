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


namespace Tedris
{
    public partial class AddForm : Form
    {
        Model _model;
        public AddForm(Model model)
        {
            InitializeComponent();
            _model = model;
        }

        private void label8_Click(object sender, EventArgs e)
        {




        }
        public void InsertData(Model model)
        {
            string connectionString = @"Data Source=.;Initial Catalog=diplom;Integrated Security=True";
            string insertSql = @"INSERT INTO tedris_yuku (muellim, qrup, fenn, muhazire_payiz_saat,                                     muhazire_yaz_saat,seminar_payiz_saat,  seminar_yaz_saat, laboratoriya_payiz_saat,                      laboratoriya_yaz_saat)VALUES( @muellim , @qrup , @fenn , @muhazire_payiz_saat ,                        @muhazire_yaz_saat ,@seminar_payiz_saat , @seminar_yaz_saat ,                                          @laboratoriya_payiz_saat ,@laboratoriya_yaz_saat)";

            string updateSql = $@" UPDATE tedris_yuku  SET muellim=@muellim,  qrup=@qrup, fenn=@fenn, 
                                  muhazire_payiz_saat=@muhazire_payiz_saat, muhazire_yaz_saat=@muhazire_yaz_saat,        seminar_payiz_saat=@seminar_payiz_saat,                                                seminar_yaz_saat=@seminar_yaz_saat,                             laboratoriya_payiz_saat=@laboratoriya_payiz_saat,         laboratoriya_yaz_saat=@laboratoriya_yaz_saat WHERE ID={model.ID}";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(_model != null ? updateSql : insertSql, cn))
            {
                cmd.Parameters.Add("@muellim", SqlDbType.VarChar, 100).Value = model.muellim;
                cmd.Parameters.Add("@qrup", SqlDbType.VarChar, 10).Value = model.qrup;
                cmd.Parameters.Add("@fenn", SqlDbType.VarChar, 100).Value = model.fenn;
                cmd.Parameters.Add("@muhazire_payiz_saat", SqlDbType.Int).Value = model.muhazire_payiz_saat;
                cmd.Parameters.Add("@muhazire_yaz_saat", SqlDbType.Int).Value = model.muhazire_yaz_saat;
                cmd.Parameters.Add("@seminar_payiz_saat", SqlDbType.Int).Value = model.seminar_payiz_saat;
                cmd.Parameters.Add("@seminar_yaz_saat", SqlDbType.Int).Value = model.seminar_yaz_saat;
                cmd.Parameters.Add("@laboratoriya_payiz_saat", SqlDbType.Int).Value = model.laboratoriya_payiz_saat;
                cmd.Parameters.Add("@laboratoriya_yaz_saat", SqlDbType.Int).Value = model.laboratoriya_yaz_saat;

                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            Model insertModel = new Model();
            insertModel.ID =_model!=null? _model.ID:0;
            insertModel.muellim = txtTeacher.Text;
            insertModel.fenn = txtlesson.Text;
            insertModel.qrup = txtGroup.Text;
            insertModel.laboratoriya_yaz_saat = (int)nmrcSprLabHours.Value;
            insertModel.laboratoriya_payiz_saat = (int)nmrcAutumnLabHours.Value;
            insertModel.seminar_payiz_saat = (int)nmrcAutumnLessonHours.Value;
            insertModel.seminar_yaz_saat = (int)nmrcSprLessonHours.Value;
            insertModel.muhazire_yaz_saat = (int)nmrcSprLectureHours.Value;
            insertModel.muhazire_payiz_saat = (int)nmrcAutumnLectureHours.Value;

            InsertData(insertModel);
            MessageBox.Show("Məlumat yadda saxlanıldı!");
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();

        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (this._model != null)
            {
                txtTeacher.Text = _model.muellim;
                txtGroup.Text = _model.qrup;
                txtlesson.Text = _model.fenn;
                nmrcAutumnLabHours.Value = _model.laboratoriya_payiz_saat;
                nmrcSprLabHours.Value = _model.laboratoriya_yaz_saat;
                nmrcAutumnLectureHours.Value = _model.muhazire_payiz_saat;
                nmrcSprLectureHours.Value = _model.muhazire_yaz_saat;
                nmrcAutumnLessonHours.Value = _model.seminar_payiz_saat;
                nmrcSprLessonHours.Value = _model.seminar_yaz_saat;
            }
        }
    }
}
