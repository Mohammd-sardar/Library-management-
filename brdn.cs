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
    public partial class brdn : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public brdn()
        {
            InitializeComponent();
            getbash();
        }

        private void getbash()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from department", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();

            for(int i=0; i<dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["dept"]);
            }
        }

        private void update()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update koga set hadad -='" + 1 + "'  where code = '"+textBox4.Text+"' ", con);
            cmd.ExecuteNonQuery();
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

        private void brdn_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text!="" && comboBox2.Text!="" )
            {
                con.Close();
                con.Open();
                SqlCommand re = new SqlCommand("select * from getbook where studentcode = '" + textBox1.Text + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(re);
                sa.Fill(dt);
                re.ExecuteNonQuery();

                bool expire = false;

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    DateTime time = DateTime.Parse(dt.Rows[i]["datehenanawa"].ToString());
                    TimeSpan ts = time - DateTime.Now;

                    if (ts.Days < 0)
                        expire = true;
                }


                if (expire != true)
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into getbook values(N'" + textBox2.Text + "' , N'" + textBox1.Text + "' , N'" + comboBox1.Text + "' , N'" + comboBox2.Text + "'  , N'" + textBox4.Text + "' , N'" + textBox3.Text + "' , N'" + dateTimePicker1.Text + "' , N'" + dateTimePicker2.Text + "' , N'" + login.nameazhmaruser + "') ", con);
                    cmd.ExecuteNonQuery();
                    update();
                    MessageBox.Show("كتێبه‌كه‌ بردرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK);
                    con.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }

                else
                {
                    MessageBox.Show("تۆ كتێبێكت بردووه‌ و به‌سه‌رچووه‌ نه‌تگێڕاوه‌ته‌وه ، پێویسته‌ بیگه‌ڕێنیته‌وه‌ بۆ ئه‌وه‌ی بتوانی كتێبی تر ببه‌ی‌", "‌سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }
            }

            else
            {
                MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕ بكرێته‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (textBox2.Text == "")
                    textBox2.Focus();

                else if (textBox1.Text == "")
                    textBox1.Focus();


                else if (comboBox1.Text == "")
                    comboBox1.DroppedDown = true;



                else if (comboBox2.Text == "")
                    comboBox2.DroppedDown = true;



                else if (textBox4.Text == "")
                    textBox4.Focus();


                else if (textBox3.Text == "")
                    textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from koga where code = '" + textBox4.Text + "' and hadad !='"+0+"' ", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if(datar.Read())
            {
                textBox3.Text = datar["name"].ToString();
            }

            else
            {
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox2.Focus();
        }
    }
}
