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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public login()
        {
            InitializeComponent();
            getpla();
            comboBox1.SelectedIndex = 0;
        }

        public static string nameuser="";
        public static string plauser = "";
        public static string nameazhmaruser = "";


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

        private void logint()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from adminss where naweazhmar = N'" + textBox1.Text + "' and password = N'" + textBox2.Text + "' and pla =  N'" + comboBox1.Text + "' ", con);
                SqlDataReader datar = cmd.ExecuteReader();

                if (datar.Read())
                {
                    nameazhmaruser = datar["naweazhmar"].ToString();
                    nameuser = datar["nawesyani"].ToString();
                    plauser = datar["pla"].ToString();
                    home ho = new home();
                    ho.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("پله‌ یان ناوی ئه‌ژمار یان وشه‌ی نهێنیت هه‌ڵه‌یه‌", "سه‌ركه‌وتوو نه‌بوو" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("تكایه‌ هه‌موو خانه‌كان پڕبكه‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (textBox1.Text == "")
                    textBox1.Focus();

               else if (textBox2.Text == "")
                    textBox2.Focus();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            

            label2.Text = "كۆلێژی " + baxerhatn.nameuni ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox6.BringToFront();
            if(textBox2.PasswordChar == '#')
            {
                textBox2.PasswordChar = '\0';
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox5.BringToFront();
            if (textBox2.PasswordChar == '\0')
            {
                textBox2.PasswordChar = '#';
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            logint();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                logint();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logint();
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            forgetpassword fo = new forgetpassword();
            
            fo.ShowDialog();
            
            
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Peru;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
