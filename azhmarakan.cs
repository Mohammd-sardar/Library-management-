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
    public partial class azhmarakan : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public azhmarakan()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            getdata();
            
            if(login.plauser == "ڕاگر")
            {
                button1.Visible = true;
                button2.Visible = true;
                button2.Visible = true;
            }

            else
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                comboBox1.Enabled = false;
                
            }
        }

        private void getdata()
        {
            if (login.plauser == "ڕاگر")
            {
                con.Close();
                con.Open();

                if (comboBox1.Text == "گشتی")
                {
                    SqlCommand cmd = new SqlCommand("select * from adminss", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    cmd.ExecuteNonQuery();
                    dataGridView1.DataSource = dt;

                    con.Close();
                }

                else if (comboBox1.Text == "ڕاگره‌كان")
                {
                    SqlCommand cmd = new SqlCommand("select * from adminss where pla = N'" + "ڕاگر" + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    cmd.ExecuteNonQuery();
                    dataGridView1.DataSource = dt;

                    con.Close();
                }

                else if (comboBox1.Text == "كارمه‌نده‌كان")
                {
                    SqlCommand cmd = new SqlCommand("select * from adminss where pla = N'" + "كارمه‌ند" + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    cmd.ExecuteNonQuery();
                    dataGridView1.DataSource = dt;

                    con.Close();
                }

                design();

                con.Close();

            }

            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from adminss where pla = N'" + "كارمه‌ند" + "' and naweazhmar = N'"+login.nameazhmaruser+"'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                design();
                con.Close();
            }
            
        }

        private void design()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.BackColor = Color.Peru;

            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 12, FontStyle.Regular);



            dataGridView1.Columns["id"].HeaderText = "ڕیز";
            dataGridView1.Columns["pla"].HeaderText = "پله‌";
            dataGridView1.Columns["nawesyani"].HeaderText = "ناوی سیانی";
            dataGridView1.Columns["ragaz"].HeaderText = "ڕه‌گه‌ز";
            dataGridView1.Columns["phone"].HeaderText = "ڕه‌قه‌م";
            dataGridView1.Columns["naweazhmar"].HeaderText = "ناوی ئه‌ژمار";
            dataGridView1.Columns["password"].HeaderText = "وشه‌ی نهێنی";



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

        private void azhmarakan_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newazhmar na = new newazhmar();
            na.ShowDialog();
            getdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeazhmar ch = new changeazhmar();
            ch.ShowDialog();
            getdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteazhmar de = new deleteazhmar();
            de.ShowDialog();
            getdata();
        }
    }
}
