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
    public partial class changeazhmar : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public changeazhmar()
        {
            InitializeComponent();
            getdata();
            getpla();
            comboBox3.Text = login.nameazhmaruser;
            
            if(login.plauser != "ڕاگر")
            {
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void getdata()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from adminss", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox3.Items.Add(dt.Rows[i]["naweazhmar"]);
            }

            con.Close();
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

        private void changeazhmar_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from adminss where naweazhmar = N'" + comboBox3.Text + "' ", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if(datar.Read())
            {
                textBox2.Text = datar["nawesyani"].ToString();
                textBox1.Text = datar["naweazhmar"].ToString();
                comboBox1.Text = datar["pla"].ToString();
                comboBox2.Text = datar["ragaz"].ToString();
                textBox3.Text = datar["phone"].ToString();
                textBox4.Text = datar["password"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text!="")
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("update  adminss set nawesyani = N'" + textBox2.Text + "' , naweazhmar = N'" + textBox1.Text + "' , ragaz = N'" + comboBox2.Text + "' ,   password = N'" + textBox4.Text + "' , phone = '" + textBox3.Text + "' , pla = N'"+comboBox1.Text+"'  where naweazhmar = N'" + comboBox3.Text + "'  ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("گۆڕدرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                textBox2.Text = "";
                textBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox3.SelectedIndex = -1;

                con.Close();
            }

            else
            {
                MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕبكه‌یه‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
