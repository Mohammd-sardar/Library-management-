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
    public partial class tawawbwakan : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public tawawbwakan()
        {
            InitializeComponent();
            getdata();
            
        }

        private void getdata()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from koga where hadad = '" + 0 + "' ", con);
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

            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 14, FontStyle.Regular);



            dataGridView1.Columns["code"].HeaderText = "كۆد";
            dataGridView1.Columns["name"].HeaderText = "ناو‌";
            dataGridView1.Columns["nwsar"].HeaderText = "نووسه‌ر";
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


        private void newkrdn()
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                try
                {
                    if (int.Parse(textBox2.Text) > 0)
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cm = new SqlCommand("select * from koga where hadad = '" + 0 + "' and code = '" + textBox1.Text + "' ", con);
                        SqlDataReader datar = cm.ExecuteReader();

                        if (datar.Read())
                        {
                            con.Close();
                            con.Open();
                            SqlCommand cmd = new SqlCommand("update koga set hadad = '" + textBox2.Text + "' where code = N'" + textBox1.Text + "' and hadad = '" + 0 + "' ", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("دانه‌ی كتێبه‌كه‌ نوێكرایه‌وه‌", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK);
                            con.Close();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox1.Focus();
                        }

                        else
                        {
                            MessageBox.Show("ئه‌و كتێبه‌ له‌ ته‌واوبووه‌كاندا نیه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = "";
                            textBox1.Focus();
                        }







                    }








                    else
                    {
                        MessageBox.Show("پێویسته‌ دانه‌ له‌ 0 زیاتر بێت", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("پێویسته‌ دانه‌ به‌ ژماره‌ بێت", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";

                    textBox2.Focus();
                }
            }

            else
            {
                MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕبكه‌یته‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if(textBox1.Text =="")
                {
                    textBox1.Focus();
                }

                else if(textBox2.Text=="")
                {
                    textBox2.Focus();
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

        private void tawawbwakan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newkrdn();
            getdata();
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                newkrdn();
                getdata();
                textBox1.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                newkrdn();
                getdata();
                textBox1.Focus();
            }
        }
    }
}
