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
    public partial class koga : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public koga()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            getdata();
        }

        private void getdata()
        {
            if (comboBox1.Text == "كۆدی كتێب")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where code like N'" + textBox1.Text + "%' and hadad != '"+0+"' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if(comboBox1.Text == "ناوی كتێب")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where name like N'" + textBox1.Text + "%' and hadad != '" + 0 + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if (comboBox1.Text == "نووسه‌ر")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where nwsar like N'" + textBox1.Text + "%' and hadad != '" + 0 + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if (comboBox1.Text == "جۆری كتێب")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where jor like N'" + textBox1.Text + "%' and hadad != '" + 0 + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if (comboBox1.Text =="ساڵی چاپكردن")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where sal like N'" + textBox1.Text + "%' and hadad != '" + 0 + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if (comboBox1.Text == "زمانی كتێب")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where lang like N'" + textBox1.Text + "%' and hadad != '" + 0 + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if (comboBox1.Text == "به‌كارهێنه‌ر")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from koga where userr like N'" + textBox1.Text + "%' and hadad != '" + 0 + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                sa.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                con.Close();
            }


            design();




        }

        private void design()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.BackColor = Color.Peru;

            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 14, FontStyle.Regular);



            dataGridView1.Columns["code"].HeaderText = "كۆد";
            dataGridView1.Columns["name"].HeaderText = "ناو‌";
            dataGridView1.Columns["nwsar"].HeaderText =  "نووسه‌ر";
            dataGridView1.Columns["warger"].HeaderText = "وه‌رگێڕ";
            
            dataGridView1.Columns["jor"].HeaderText = "جۆر";
            
            dataGridView1.Columns["hadad"].HeaderText = "دانه‌";
            dataGridView1.Columns["userr"].HeaderText = "به‌كارهێنه‌ر";
            dataGridView1.Columns["date"].HeaderText = "به‌روار";

            dataGridView1.Columns["sal"].HeaderText = "ساڵ";
            dataGridView1.Columns["lang"].HeaderText = "زمان";



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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void koga_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult di = MessageBox.Show("دڵنیای له‌ سڕینه‌وه‌ی ئه‌و كتێبه‌؟", "تكایه‌ وه‌ڵام بده‌وه‌", MessageBoxButtons.YesNo);
            if(di == DialogResult.Yes)
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from koga where code = N'" + dataGridView1.CurrentRow.Cells["code"].Value.ToString() + "' ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("كتێبه‌كه‌ ڕه‌شكرایه‌وه‌", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                getdata();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addbook ad = new addbook();
            ad.ShowDialog();
            getdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatebook uu = new updatebook();
            uu.ShowDialog();
            getdata();
        }
    }
}
