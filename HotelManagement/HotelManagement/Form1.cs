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
namespace HotelManagement
{
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Hoteldb.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Form1 f = new Form1();
            //f.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from Staff_tbl where Staffname='"+username.Text+"' and Staffpassword='"+password.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Main m = new Main();
                m.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
            Con.Close();
        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {
            password.isPassword = true;
        }
    }
}
