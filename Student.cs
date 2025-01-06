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

namespace SchoolManagement
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("insert into studentab values (@studentid,@studentname,@dob,@gender,@phone,@email)", con);
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@Email", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt başarıyla kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("update studentab set studentname=@studentname,dob=@dob,gender=@gender,phone=@phone,email=@email where studentid=@studentid", con);
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@Email", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("delete studentab where studentid=@studentid", con);
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
         
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Student_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KAJESDR;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
