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

namespace libraryproject
{
    public partial class baxerhatn : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");

        public baxerhatn()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
         public static String nameuni = "";
        private void Form1_Load(object sender, EventArgs e)
        {

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;


           
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from uniname", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if (datar.Read())
            {
                nameuni = datar["name"].ToString();
            }

            label1.Text = "به‌خێربێی بۆ كتێبخانه‌ی كۆلێژی " + nameuni;

            timer1.Start();
        }

        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            startpoint += 1;
            label2.Text = startpoint.ToString() + "%";

            if (startpoint == 100)
            {
                timer1.Stop();
                login lo = new login();
                lo.Show();
                this.Hide();
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {
                
        }
    }
}
