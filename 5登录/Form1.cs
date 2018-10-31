using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _5登录
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
            string pwd = textBox2.Text.Trim();
           
            //验证登录名 密码
            if(string.IsNullOrEmpty(uid)||string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入完成信息");
                return;
            }


            string conStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            string sql = "select count(*) from Student where uid='"+uid+"' and pwd='"+pwd+"' ;";
            int count;
            using (SqlConnection conn=new SqlConnection(conStr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    conn.Open();
                    count=(int)cmd.ExecuteScalar();  //返回受影响行数，如果大于0.说明登录成功

                    string result = count > 0 ? "登录成功" : "登录失败";
                    MessageBox.Show(result);
                }
            }
        }
    }
}
