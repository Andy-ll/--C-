using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace station
{
    public partial class Form1 : Form
    {
        //public static string srt_login;
        public static int int_g;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoginName.Text.Trim()) || string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                MessageBox.Show("请输入用户名或密码.");
                return;
            }
            if (txtLoginName.Text.Trim() == "andy_le" && txtPassword.Text.Trim() == "1234")
            {
                //this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态

                int_g = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败");
                this.Close();    //关闭登录窗口
            }
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
