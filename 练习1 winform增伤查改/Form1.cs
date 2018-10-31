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
using System.Diagnostics;
using System.IO;

namespace 练习1_winform增伤查改
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //连接字符串
            string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            //sql语句
            string sql = "select * from StuTest";

            //数据集
            DataSet ds = new DataSet();

            //准备适配器
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, connStr))
            {
                sda.Fill(ds);
            }
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///导出的两个方法

            #region 
            ///使用StreamWriter 导出 到txt文件   方法一：

            //写入到文本文件
            //Stopwatch sp = new Stopwatch();
            //sp.Start();
            //string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            //string sql = "select * from StuTest";
            //StreamWriter writer = new StreamWriter("student.txt", true, Encoding.Default);

            //string conStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            //using (SqlConnection conn = new SqlConnection(conStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        conn.Open();
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                //获得数据，写入文件
            //                List<string> list1 = new List<string>();

            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    list1.Add(reader[i].ToString());
            //                }
            //                writer.WriteLine(string.Join(",", list1));
            //            }
            //        }
            //        writer.Dispose();
            //        sp.Stop();
            //        MessageBox.Show("导出完成");
            //    }

            //}
            #endregion

            #region 
            ///方法二： 通过 File 导出数据
            Stopwatch sp = new Stopwatch();
            sp.Start();

            string sql="select * from StuTest";
            string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    conn.Open();
                    using (SqlDataReader reader=cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            List<string> list1 = new List<string>();
                            for(int i=0;i<reader.FieldCount;i++)
                            {
                                list1.Add(reader[i].ToString());
                            }
                            File.AppendAllText("tttttext.txt",string.Join(",",list1)+ "\n"+Encoding.Default);
                        }
                    }


                }

            }

                sp.Stop();
            MessageBox.Show("导出完成");
           
            #endregion
        }
    }
}
