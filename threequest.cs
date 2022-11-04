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
    public partial class threequest : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public threequest()
        {
            InitializeComponent();
            getquestions();
            label11.Text = newazhmar.nameuser;
        }


        private void getquestions()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from questions", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["prsyar"]);
                comboBox2.Items.Add(dt.Rows[i]["prsyar"]);
                comboBox3.Items.Add(dt.Rows[i]["prsyar"]);

            }
        }
        private void threequest_Load(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Peru;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""  &&
                comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if (comboBox1.Text != comboBox2.Text && comboBox1.Text != comboBox3.Text &&
                     comboBox2.Text != comboBox3.Text)
                {
                   
                    con.Close();
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("insert into mainq values(N'" + newazhmar.index + "' , N'" + comboBox1.Text + "' , N'" + textBox2.Text + "')", con);
                    cmd2.ExecuteNonQuery();

                    con.Close();
                    con.Open();

                    SqlCommand cmd3 = new SqlCommand("insert into mainq values(N'" + newazhmar.index + "' , N'" + comboBox2.Text + "' , N'" + textBox3.Text + "')", con);
                    cmd3.ExecuteNonQuery();

                    con.Close();
                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("insert into mainq values(N'" + newazhmar.index + "' , N'" + comboBox3.Text + "' , N'" + textBox4.Text + "')", con);
                    cmd4.ExecuteNonQuery();




                    MessageBox.Show("ئه‌ژماره‌كه‌ دروستكرا" , "سه‌ركه‌وتوو بوو" , MessageBoxButtons.OK , MessageBoxIcon.Information);

                    con.Close();

                    this.Close();

                    
                    


                }

                else
                {
                    MessageBox.Show("پێویسته‌ پرسیاری جیاواز هه‌ڵبژێری" , "سه‌ركه‌وتوو نه‌بوو" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕبكه‌یته‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (comboBox1.Text == "")
                    comboBox1.DroppedDown = true;

                else if (textBox2.Text == "")
                    textBox2.Focus();

               else if (comboBox2.Text == "")
                    comboBox2.DroppedDown = true;

                else if (textBox3.Text == "")
                    textBox3.Focus();

                else if (comboBox3.Text == "")
                    comboBox3.DroppedDown = true;

                else if (textBox4.Text == "")
                    textBox4.Focus();








            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
    }
}
