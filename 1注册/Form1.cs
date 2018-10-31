using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1注册
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid = textBox1.Text.Trim();
            string pwd1 = textBox2.Text.Trim();
            string pwd2 = textBox3.Text.Trim();

            //验证用户输入
            if(string.IsNullOrEmpty(uid)||string.IsNullOrEmpty(pwd1)||string.IsNullOrEmpty(pwd2))
            {
                MessageBox.Show("请填写完整的信息");
                return;
            }
            if(pwd1!=pwd2)
            {
                MessageBox.Show("两次密码输入不正确");
            }

            //进入ado.net 部分
            string conStr = "Data Source=.;Initial Catalog=adoTest;Integrated Security=True";
            string sql1 = "insert into Student values('"+uid+"','"+pwd1+"');";

            try
            {
                using (SqlConnection conn=new SqlConnection(conStr))
                {
                    using (SqlCommand cmd=new SqlCommand(sql1,conn))
                    {
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();
                        MessageBox.Show(count>0?"注册成功":"注册失败");

                    }

                }
                
            }
            catch(Exception ex)
            {
                string message = ex.ToString();
                MessageBox.Show(message);
            }

          
        }
    }
}
