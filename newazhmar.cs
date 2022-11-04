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
    public partial class newazhmar : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public newazhmar()
        {
            InitializeComponent();
            getpla();
        }

        private void getpla()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from plakan", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dt.Rows.Count; i++)
                comboBox1.Items.Add(dt.Rows[i]["pla"]);


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

        private void azhmarakan_Load(object sender, EventArgs e)
        {

        }

        public static string nameuser = "";
        public static int index = 0;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text!="" && comboBox2.Text!="")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into adminss values(N'"+textBox2.Text+"' , N'"+comboBox2.Text+ "' , N'" + textBox3.Text + "'  , N'" + textBox1.Text + "' , N'" + textBox4.Text + "' , N'" + comboBox1.Text + "'  ) " , con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from adminss where naweazhmar = N'" + textBox1.Text + "' and password = N'" + textBox4.Text + "' ", con);
                SqlDataReader datar = cmd1.ExecuteReader();

                if(datar.Read())
                {
                    nameuser = datar["naweazhmar"].ToString();
                    index = (int)datar["id"];
                }

                threequest th = new threequest();
                this.Hide();
                th.ShowDialog();
            }

            else
            {
                MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕبكه‌یته‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (textBox2.Text == "")
                    textBox2.Focus();

                else if (textBox1.Text == "")
                    textBox1.Focus();

                else if (comboBox1.Text == "")
                    comboBox1.DroppedDown = true;


                else if (comboBox2.Text == "")
                    comboBox2.DroppedDown = true;

                else if (textBox3.Text == "")
                    textBox3.Focus();

                else if (textBox4.Text == "")
                    textBox4.Focus();


            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Peru;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = ColorTranslator.FromHtml("64,64,64");
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox4.PasswordChar = '\0';
                textBox4.Focus();
            }

            else
            {
                textBox4.PasswordChar = '#';
                textBox4.Focus();
            }
        }
    }
}
