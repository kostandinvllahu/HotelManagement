using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
           
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Clients c = new Clients();
            c.Show();
            this.Close();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            Staffinfo sf = new Staffinfo();
            sf.Show();
            this.Close();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            RoomInfo r = new RoomInfo();
            r.Show();
            this.Close();
            
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            ReservationInfo reserv = new ReservationInfo();
            reserv.Show();
            this.Close();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Show();
            this.Close();
        }
    }
}
