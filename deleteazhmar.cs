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
    public partial class deleteazhmar : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=libraryproject;Integrated Security=True");
        public deleteazhmar()
        {
            InitializeComponent();
            getdata();
            comboBox3.Text = login.nameazhmaruser;
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

        private void rashkrdn()
        {
           
                DialogResult di = MessageBox.Show("دڵنیای له‌ ڕه‌شكردنه‌وه‌ی ئه‌م ئه‌ژماره‌", "تكایه‌ وه‌ڵام بده‌وه‌", MessageBoxButtons.YesNo);

                if (di == DialogResult.Yes)
                {
                    con.Close();
                    con.Open();
                 
                    SqlCommand cmd = new SqlCommand("delete from adminss where naweazhmar = '" + comboBox3.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                   
    
                    MessageBox.Show("ئه‌ژماره‌كه‌ ڕه‌شكرایه‌وه‌", "سه‌ركه‌وتووبوو", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    this.Close();

                }

            
        }

        private void rashkrdnmain()
        {
            int a = 0;
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from adminss where naweazhmar = N'" + comboBox3.Text + "' ", con);
            SqlDataReader datar = cmd.ExecuteReader();

            if(datar.Read())
            {
                a = (int)datar["id"];
            }


            con.Close();
            con.Open();

            SqlCommand cmd1 = new SqlCommand("delete from mainq where admin_id = '" + a + "' " ,  con);
            cmd1.ExecuteNonQuery();

            con.Close();

        }
        private void deleteazhmar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rashkrdnmain();
            rashkrdn();
        }
    }
}
