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
    public partial class addbook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public addbook()
        {
            InitializeComponent();
            getdata();
            dateTimePicker1.Value = DateTime.Now;

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

            for(int i=0;i<dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i]["jor"].ToString());
            }

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

        private void addbook_Load(object sender, EventArgs e)
        {
            
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
                        try
                        {


                            con.Close();
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into koga values(N'" + textBox2.Text + "' , N'" + textBox1.Text + "' , N'" + textBox3.Text + "' , N'" + textBox6.Text + "' , N'" + comboBox2.Text + "' , N'" + textBox5.Text + "' ,N'" + comboBox1.Text + "' ,N'" + textBox4.Text + "' , N'" + login.nameazhmaruser + "' , N'" + dateTimePicker1.Text + "' )", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("كتێبه‌كه‌ زیادكرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK);
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
                        catch (Exception)
                        {
                            MessageBox.Show("ئه‌م كتێبه‌ تۆماركرایه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


                    else if (comboBox1.Text == "")
                        comboBox1.DroppedDown = true;

                    else if (comboBox2.Text == "")
                        comboBox2.DroppedDown = true;
                }
            }

            catch(Exception)
            {
                MessageBox.Show("پێویسته‌ دانه‌ به‌ ژماره‌ بێت ", "تكایه‌ تێبینی بكه‌", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Text = "";
                textBox4.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}
