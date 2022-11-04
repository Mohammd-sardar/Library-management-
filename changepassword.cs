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
    public partial class changepassword : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public changepassword()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void changepassword_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button1.Enabled = true;

            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("update adminss set password= N'"+textBox1.Text+"' where naweazhmar = '"+forgetpassword.name+"' " , con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("وشه‌ی نهێنی گۆڕدرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

            
            this.Close();
            
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update adminss set password= N'" + textBox1.Text + "' where naweazhmar = N'" + forgetpassword.name + "' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("وشه‌ی نهێنی گۆڕدرا", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("پێویسته‌ وشه‌ی نهێنی دابنێیت", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }


            }
        }
    }
}
