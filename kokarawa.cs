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
    public partial class kokarawa : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public kokarawa()
        {
            InitializeComponent();
        }

        private void getdatabook()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from koga where hadad !='"+0+"' ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sa.Fill(dt);

            int sum = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
                sum += int.Parse(dt.Rows[i]["hadad"].ToString());

            label1.Text = sum.ToString();

            con.Close();
        }

        private void getdatadept()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from department ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sa.Fill(dt);

            label2.Text = dt.Rows.Count.ToString();

            con.Close();
        }

        private void getdatajor()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from jorakan ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sa.Fill(dt);

            label3.Text = dt.Rows.Count.ToString();

            con.Close();
        }

        private void getdatauser()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from adminss ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sa.Fill(dt);

            label4.Text = dt.Rows.Count.ToString();

            con.Close();
        }

        private void getdatabookbraw()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from getbook ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sa.Fill(dt);

            label11.Text = dt.Rows.Count.ToString();

            con.Close();
        }

        private void getdatatawawbw()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from koga where hadad ='" + 0 + "' ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sa.Fill(dt);

            label13.Text = dt.Rows.Count.ToString();

            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Peru;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Peru;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void kokarawa_Load(object sender, EventArgs e)
        {
            getdatabook();
            getdatadept();
            getdatajor();
            getdatauser();
            getdatabookbraw();
            getdatatawawbw();
        }
    }
}
