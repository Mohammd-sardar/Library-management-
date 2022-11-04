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
    public partial class henanawa : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public henanawa()
        {
            InitializeComponent();
            getdata();
        }

        private void getdata()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from getbook where studentcode like N'" + textBox2.Text + "%' and bookcode like N'" + textBox1.Text + "%' ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            cmd.ExecuteNonQuery();
           
            dataGridView1.DataSource = dt;
            design();
        }


        private void rebook()
        {
     
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into returnbook(studentname , studentcode , studentdept , studentstage , bookcode , bookname , datebrdn , datehenanawa) select studentname , studentcode , studentdept , studentstage , bookcode , bookname , datebrdn , datehenanawa from getbook where id = '"+textBox3.Text+"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
            
        }


        private void deletebook()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from getbook where id = '" + textBox3.Text + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        int codebook = 0;
        private void plus()
        {
           
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from getbook where id = '"+textBox3.Text+"'  ", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if(datar.Read())
            {
                codebook = int.Parse(datar["bookcode"].ToString());
            }

            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("update koga set hadad +='" + 1 + "' where code = '"+codebook+"'  ", con);
            cmd1.ExecuteNonQuery();
            con.Close();

           
        }

        private void update()
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from getbook where id = '" + textBox3.Text + "'  ", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if (datar.Read())
            {
                codebook = int.Parse(datar["bookcode"].ToString());
            }


            con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("update returnbook set datehenanawa = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where bookcode = '" + codebook + "' ", con);
            cmd2.ExecuteNonQuery();
            con.Close();

        }








        private void henan()
        {
            if(textBox3.Text!="")
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("select * from getbook where id = '" + textBox3.Text + "' ", con);
                    SqlDataReader datar = cmd.ExecuteReader();

                    if (datar.Read())
                    {
                        rebook();
                        plus();
                        update();
                        deletebook();
                        MessageBox.Show("كتێبه‌كه‌ هێنرایه‌وه‌", "سه‌ركه‌وتوو بوو", MessageBoxButtons.OK);
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ئه‌و كتێبه‌ له‌ كتێبه‌ بردراوه‌كاندا نیه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
               }

                catch(Exception)
                {
                    MessageBox.Show("پێویسته‌ خانه‌ی ڕیزه‌كه‌ به‌ ژماره‌ پڕبكرێته‌وه‌", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Text = "";
                    textBox3.Focus();
                } 
                
            }

            else
            {
                MessageBox.Show("پێویسته‌ ڕیزه‌كه‌ دیاری بكه‌ی", "سه‌ركه‌وتوو نه‌بوو", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
        }

        private void design()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.ForeColor = Color.Peru;
                item.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("64, 64, 64");


            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("K24 Kurdish Bold Bold", 12, FontStyle.Regular);



            dataGridView1.Columns["id"].HeaderText = "ڕیز";
            dataGridView1.Columns["studentname"].HeaderText = "ناوی قوتابی";
            dataGridView1.Columns["studentdept"].HeaderText = "به‌ش";
            dataGridView1.Columns["studentstage"].HeaderText = "قۆناغ";
            dataGridView1.Columns["studentcode"].HeaderText = "كۆدی باج";
            dataGridView1.Columns["bookcode"].HeaderText = "كۆدی كتێب";
            dataGridView1.Columns["bookname"].HeaderText = "ناوی كتێب‌";

            dataGridView1.Columns["datebrdn"].HeaderText = "به‌رواری بردن";
            dataGridView1.Columns["datehenanawa"].HeaderText = "به‌رواری هینانه‌وه‌";
            dataGridView1.Columns["userr"].HeaderText = "به‌كارهێنه‌ر‌";




            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void henanawa_Load(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            henan();
            getdata();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                henan();
                getdata();
            }
        }
    }
}
