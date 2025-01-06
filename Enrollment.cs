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
using System.Data.SqlClient;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolManagement
{
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("insert into entab values (@eid,@studentname,@section,@enrolldate)", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate",dateTimePicker2.Value);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt başarıyla kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("select * from entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("update entab set studentname=@studentname,section=@section,enerolldate=@enrolldate where eid=@eid", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("delete entab where eid=@eid", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("select * from entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("select * from entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
