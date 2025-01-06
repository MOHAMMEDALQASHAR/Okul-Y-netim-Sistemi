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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolManagement
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void Subject_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into subtab values (@subjectid,@subjectname)", con);
            cnn.Parameters.AddWithValue("@SubjectId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt başarıyla kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("update subtab set subjectname=@subjectname where  subjectname where subjectid=@subjectid", con);
            cnn.Parameters.AddWithValue("@SubjectId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record saved Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete subtab where subjectid=@subjectid", con);
            cnn.Parameters.AddWithValue("@SubjectId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record  Deleted Succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
