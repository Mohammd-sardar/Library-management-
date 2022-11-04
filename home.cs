using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryproject
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
            label3.Text = login.nameuser;
            label5.Text = login.plauser;
           

            
        }

        private void home_Load(object sender, EventArgs e)
        {
            label1.Text = "كتێبخانه‌ی كۆلێژی " + baxerhatn.nameuni;
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            basarchwakan ba = new basarchwakan();
            ba.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            jorakan jo = new jorakan();
            jo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            koga kg = new koga();
            kg.ShowDialog();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Peru;
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.Peru;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Peru;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.Peru;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Peru;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Peru;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

            button4.BackColor = Color.Black;
            button4.ForeColor = Color.Peru;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Peru;
            button4.ForeColor = Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {

            button5.BackColor = Color.Peru;
            button5.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.Peru;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.Peru;
            button6.ForeColor = Color.Black;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Black;
            button6.ForeColor = Color.Peru;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.Peru;
            button7.ForeColor = Color.Black;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Black;
            button7.ForeColor = Color.Peru;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.Peru;
            button8.ForeColor = Color.Black;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Black;
            button8.ForeColor = Color.Peru;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.Peru;
            button9.ForeColor = Color.Black;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Black;
            button9.ForeColor = Color.Peru;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            login lo = new login();
            lo.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label4.Text = DateTime.Now.ToString("hh:mm:ss");
            label6.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            azhmarakan aa = new azhmarakan();
            aa.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bashakan ba = new bashakan();
            ba.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tawawbwakan tw = new tawawbwakan();
            tw.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            brdn br = new brdn();
            br.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            henanawa he = new henanawa();
            he.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            henanwbrdn hb = new henanwbrdn();
            hb.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            kokarawa ko = new kokarawa();
            ko.ShowDialog();
        }
    }
}
