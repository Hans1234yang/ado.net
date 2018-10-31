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

namespace _6参数化登录
{

    //参数化登录

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

            //验证
            if(string.IsNullOrEmpty(uid)||string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入完整信息");
                return;
            }

            string conStr= ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            //1.修改sql语句
            string sql = "select count(*) from Student where uid=@uiddd and pwd=@pwddd";

            //2.参数赋值
            SqlParameter pUid = new SqlParameter("@uiddd",uid);
            SqlParameter uPwd = new SqlParameter("@pwddd",pwd);

            int count;
            using (SqlConnection conn=new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //把参数交给cmd
                    cmd.Parameters.Add(pUid);
                    cmd.Parameters.Add(uPwd);


                    conn.Open();
                    count = (int)cmd.ExecuteScalar();

                    string result = count > 0 ? "登录成功" : "登录失败";
                    MessageBox.Show(result);
                }

            }
        }
    }
}
