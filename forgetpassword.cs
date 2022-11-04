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
    public partial class forgetpassword : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public forgetpassword()
        {
            InitializeComponent();
            getquestions();
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
        private void forgetpassword_Load(object sender, EventArgs e)
        {

        }

        int index = 0;
        public static string name = "";
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
               comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if (comboBox1.Text != comboBox2.Text && comboBox1.Text != comboBox3.Text &&
                     comboBox2.Text != comboBox3.Text)
                {

                    con.Close();
                    con.Open();

                    SqlCommand cmd = new SqlCommand("select * from adminss where naweazhmar = N'" + textBox1.Text + "'", con);
                    SqlDataReader datar = cmd.ExecuteReader();

                    if (datar.Read())
                    {
                        index = (int)datar["id"];
                    }

                    if (index != 0)
                    {
                        

                        con.Close();
                        con.Open();

                        bool q1 = false, q2 = false, q3 = false;

                        SqlCommand cmd1 = new SqlCommand("select * from mainq where admin_id = '" + index + "'", con);
                        DataTable dt = new DataTable();
                        SqlDataAdapter sa = new SqlDataAdapter(cmd1);

                        cmd1.ExecuteNonQuery();
                        sa.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (comboBox1.Text == dt.Rows[i]["prsyar"].ToString() && textBox2.Text == dt.Rows[i]["walam"].ToString())
                            {
                                q1 = true;
                            }
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (comboBox2.Text == dt.Rows[i]["prsyar"].ToString() && textBox3.Text == dt.Rows[i]["walam"].ToString())
                            {
                                q2 = true;
                            }
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (comboBox3.Text == dt.Rows[i]["prsyar"].ToString() && textBox4.Text == dt.Rows[i]["walam"].ToString())
                            {
                                q3 = true;
                            }

                        }

                        if (q1 && q2 && q3)
                        {
                            name = textBox1.Text;
                            changepassword ch = new changepassword();
                            ch.ShowDialog();
                            
                            
                            this.Close();
                           
                        }

                        else
                        {
                            MessageBox.Show("هه‌ڵه‌ له‌ پڕكردنه‌وه‌ی زانیاریه‌كان هه‌یه‌", "تكایه‌ تێبینی بكه‌", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }



                        con.Close();

                    }

                    else
                    {
                        MessageBox.Show("ناوی ئه‌ژماره‌كه‌ هه‌ڵه‌یه‌" , "تكایه‌ تێبینی بكه‌" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    }


                }

                else
                {
                    MessageBox.Show("پێویسته‌ پرسیاری جیاواز هه‌ڵبژێری" , "تكایه‌ تێبینی بكه‌" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("پێویسته‌ هه‌موو خانه‌كان پڕبكه‌یته‌وه‌" , "تكایه‌ تێبینی بكه‌" , MessageBoxButtons.OK , MessageBoxIcon.Information);

                if (textBox1.Text == "")
                    textBox1.Focus();

                else if (comboBox1.Text == "")
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

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = ColorTranslator.FromHtml("64,64,64");
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Peru;
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
