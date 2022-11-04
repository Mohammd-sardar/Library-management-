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
    public partial class jorakan : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public jorakan()
        {
            InitializeComponent();
            getdata();
            textBox1.Focus();
            button1.Enabled = false;
        }

        private void getdata()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from jorakan", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = dt;
            design();
            con.Close();
        }

        private void design()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.BackColor = Color.Peru;
                item.DefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 14);

            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 18, FontStyle.Regular);



            dataGridView1.Columns["jor"].HeaderText = "جۆره‌كان";




            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void push()
        {
            if (textBox1.Text != "")
            {
                try
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into jorakan values(N'" + textBox1.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("زیادكرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    con.Close();
                    getdata();
                }

                catch (Exception e)
                {
                    MessageBox.Show("ئه‌و جۆره‌‌ تۆماركراوه‌", "تكایه‌ تێبینی بكه‌", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }

            else
            {
                MessageBox.Show("پێویسته‌ جۆره‌كه دیاری بكه‌یت‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

        }

        private void jorakan_Load(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text !="")
            {
                button1.Enabled = true;
            }

            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            push();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                push();
                getdata();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult di = MessageBox.Show("دڵنیای له‌ ڕه‌شكردنه‌وه‌ی ئه‌و جۆره‌؟‌", "تكایه‌ وه‌ڵام بده‌وه‌", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (di == DialogResult.Yes)
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from jorakan where jor = N'" + dataGridView1.CurrentRow.Cells["jor"].Value.ToString() + "' ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("جۆره‌كه‌ ڕه‌شكرایه‌وه‌", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                getdata();
                
            }

            textBox1.Focus();
        }
    }
}
