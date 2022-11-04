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
    public partial class updatebook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public updatebook()
        {
            InitializeComponent();
            getnames();
            getjor();
            fill();
            textBox2.Enabled = false;
            comboBox3.SelectedIndex = 0;
        }

        private void updatebook_Load(object sender, EventArgs e)
        {

        }


        private void getnames()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from koga where hadad != '" + 0 + "'", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();

            for(int i=0; i<dt.Rows.Count;i++)
            {
                comboBox3.Items.Add(dt.Rows[i]["name"].ToString());
            }

            con.Close();

        }

        private void getjor()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from jorakan", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);

            cmd.ExecuteNonQuery();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i]["jor"].ToString());
            }
        }

        private void fill()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from koga where name = N'" + comboBox3.Text + "' and hadad != '" + 0 + "' ", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if(datar.Read())
            {
                textBox2.Text = datar["code"].ToString();
                textBox1.Text = datar["name"].ToString();
                textBox3.Text = datar["nwsar"].ToString();
                textBox4.Text = datar["hadad"].ToString();
                textBox5.Text = datar["sal"].ToString();
                textBox6.Text = datar["warger"].ToString();

                comboBox1.Text = datar["lang"].ToString();
                comboBox2.Text = datar["jor"].ToString();

                



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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Peru;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                   textBox5.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
                {
                    if (int.Parse(textBox4.Text) > 0)
                    {

                        con.Close();
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update koga set name = N'" + textBox1.Text + "'  , nwsar = N'" + textBox3.Text + "' , hadad = '" + textBox4.Text + "' , sal = N'" + textBox5.Text + "' , warger = N'" + textBox6.Text + "' , jor = N'" + comboBox2.Text + "' , lang = N'" + comboBox1.Text + "' where name = N'" + comboBox3.Text + "' ", con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("زانیاری كتێبه‌كه‌ گۆڕدرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK);
                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;

                        textBox2.Focus();


                    }

                    else
                    {
                        MessageBox.Show("پێویسته‌ له‌ 0 دانه‌ زیاتربێت", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Text = "";
                        textBox4.Focus();
                    }
                }

                else
                {
                    MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕبكه‌یته‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (textBox2.Text == "")
                        textBox2.Focus();


                    else if (textBox1.Text == "")
                        textBox1.Focus();


                    else if (textBox3.Text == "")
                        textBox3.Focus();


                    else if (textBox5.Text == "")
                        textBox5.Focus();



                    else if (textBox4.Text == "")
                        textBox4.Focus();


                }

            }

            catch(Exception)
            {
                MessageBox.Show("پێویسته‌ دانه‌ به‌ ژماره‌ بێت ", "تكایه‌ تێبینی بكه‌", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Text = "";
                textBox4.Focus();
            }
        
    }
    }
}
