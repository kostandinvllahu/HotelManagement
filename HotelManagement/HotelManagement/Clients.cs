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
    public partial class Clients : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Hoteldb.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Client_tbl";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            Client.DataSource = ds.Tables[0];
            Con.Close();
        }
        public Clients()
        {
            InitializeComponent();
        }

        //Return Button
        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        public void clean()
        {
            txtID.Text = "";
            txtClient.Text = "";
            txtPhone.Text = "";
            Country.Text = "";
            search.Text = "";
        }

        //Add button
        private void button5_Click(object sender, EventArgs e)
        {
            if (ID.Text == "")
            {
                MessageBox.Show("Please Insert ID!");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into Client_tbl values(" + ID.Text + ",'" + ClientName.Text + "','" + PhoneNumber.Text + "','" + Country.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client Successfully Added!");
                Con.Close();
                populate();
                clean();
            }
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            ID.Text = txtID.Text;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            ClientName.Text = txtClient.Text;
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            PhoneNumber.Text = txtPhone.Text;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Country.Text = guna2ComboBox1.SelectedItem.ToString();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            populate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
        }

        //Delete Button
        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query ="delete from Client_tbl where Clientid=" + txtID.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Client Successfully Deleted!");
            Con.Close();
            populate();
            clean();
        }

        //Data grid view
        private void Client_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = Client.SelectedRows[0].Cells[0].Value.ToString();
            txtClient.Text = Client.SelectedRows[0].Cells[1].Value.ToString();
            txtPhone.Text = Client.SelectedRows[0].Cells[2].Value.ToString();
            Country.Text = Client.SelectedRows[0].Cells[3].Value.ToString();
        }

        //Edit button
        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string myquery = "UPDATE Client_tbl set ClientName='" + ClientName.Text + "',ClientPhone='" + PhoneNumber.Text + "',ClientCountry='" + Country.Text + "'where Clientid=" + txtID.Text + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Client Successfully Edited!");
            Con.Close();
            populate();
            clean();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();
        }

        //Clean table button
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            populate();
            search.Text = "";
        }


        //Search Button
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string Myquery = "select * from Client_tbl where ClientName = '"+search.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            Client.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void Country_TextChanged(object sender, EventArgs e)
        {

        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void search_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
