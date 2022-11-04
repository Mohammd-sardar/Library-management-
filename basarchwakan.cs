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
    public partial class basarchwakan : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public basarchwakan()
        {

            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            getdata();
        }

        private void getdata()
        {
            if(comboBox1.Text == "گشتی")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getbook", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();

                dataGridView1.DataSource = dt;
            }

            else if(comboBox1.Text == "به‌سه‌رنه‌چووه‌كان")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getbook  where datehenanawa > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();

                dataGridView1.DataSource = dt;
            }

            else if(comboBox1.Text == "ئه‌وڕۆ به‌سه‌رده‌چێت")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getbook  where datehenanawa = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();

                dataGridView1.DataSource = dt;
            }

            else if(comboBox1.Text == "به‌سه‌رچووه‌كان")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getbook  where datehenanawa < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();

                dataGridView1.DataSource = dt;
            }
          

            design();

        }

        private void design()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.ForeColor = Color.Black;
                item.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("64, 64, 64");


            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 12, FontStyle.Regular);



            dataGridView1.Columns["id"].HeaderText = "ڕیز";
            dataGridView1.Columns["studentname"].HeaderText = "ناوی قوتابی";
            dataGridView1.Columns["studentdept"].HeaderText = "به‌ش";
            dataGridView1.Columns["studentstage"].HeaderText = "قۆناغ";
            dataGridView1.Columns["studentcode"].HeaderText = "كۆدی باج";
            dataGridView1.Columns["bookcode"].HeaderText = "كۆدی كتێب";
            dataGridView1.Columns["bookname"].HeaderText = "ناوی كتێب‌";

            dataGridView1.Columns["datebrdn"].HeaderText = "به‌رواری بردن";
            dataGridView1.Columns["datehenanawa"].HeaderText = "به‌رواری هینانه‌وه‌";
            dataGridView1.Columns["userr"].HeaderText = "به‌كارهێنه‌ر‌";




            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void expire()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DateTime time = DateTime.Parse(dr.Cells["datehenanawa"].Value.ToString());
                TimeSpan ts =time - DateTime.Now;

                if (ts.Days < 0)
                {
                    dr.DefaultCellStyle.BackColor = Color.Red;
                }

                else if (ts.Days == 0)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }

                else
                {
                    dr.DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
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
            pictureBox2.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Peru;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Peru;
        }

        private void basarchwakan_Load(object sender, EventArgs e)
        {
            expire();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
            expire();
        }
    }
}
