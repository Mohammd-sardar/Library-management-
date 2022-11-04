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
    public partial class henanwbrdn : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public henanwbrdn()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        

        }

        private void getdata()
        {
            if(radioButton1.Checked)
            {
                if(comboBox1.Text == "ناوی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from getbook where studentname like N'" + textBox1.Text + "%' and datebrdn between '"+dateTimePicker1.Text+ "' and '" + dateTimePicker2.Text + "'   ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else if(comboBox1.Text == "كۆدی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from getbook where studentcode like N'" + textBox1.Text + "%' and datebrdn between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }


                else if (comboBox1.Text == "به‌شی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from getbook where studentdept like N'" + textBox1.Text + "%' and datebrdn between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }


                else if (comboBox1.Text == "قۆناغی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from getbook where studentstage like N'" + textBox1.Text + "%' and datebrdn between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else if (comboBox1.Text == "ناوی كتێب")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from getbook where bookname like N'" + textBox1.Text + "%' and datebrdn between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else if (comboBox1.Text == "كۆدی كتێب")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from getbook where bookcode like N'" + textBox1.Text + "%' and datebrdn between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }




            }

            else
            {
                if (comboBox1.Text == "ناوی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from returnbook where studentname like N'" + textBox1.Text + "%' and datehenanawa between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'   ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else if (comboBox1.Text == "كۆدی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from returnbook where studentcode like N'" + textBox1.Text + "%' and datehenanawa between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }


                else if (comboBox1.Text == "به‌شی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from returnbook where studentdept like N'" + textBox1.Text + "%' and datehenanawa between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }


                else if (comboBox1.Text == "قۆناغی قوتابی")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from returnbook where studentstage like N'" + textBox1.Text + "%' and datehenanawa between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else if (comboBox1.Text == "ناوی كتێب")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from returnbook where bookname like N'" + textBox1.Text + "%' and datehenanawa between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else if (comboBox1.Text == "كۆدی كتێب")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from returnbook where bookcode like N'" + textBox1.Text + "%' and datehenanawa between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            
        }

        private void design()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.ForeColor = Color.Peru;
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

        private void henanwbrdn_Load(object sender, EventArgs e)
        {
            getdata();
            design();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getdata();
            textBox1.Focus();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            getdata();
            textBox1.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            getdata();
            textBox1.Focus();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            getdata();
            textBox1.Focus();
        }
    }
}
