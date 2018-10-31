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
namespace _8DataAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //读取·数据 

            string strCon = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            string sql = "select * from Stu";

            DataSet ds = new DataSet();
            using (SqlDataAdapter sda=new SqlDataAdapter(sql,strCon))
            {
                sda.Fill(ds);
            }

            dataGridView1.DataSource = ds.Tables[0];
            
        }
    }
}
