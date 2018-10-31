using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ExecuteScalar
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=.;Initial Catalog=adoTest;Integrated Security=True";
            string sql = "select * from Student";

            Object o;
            //链接对象
            using (SqlConnection conn=new SqlConnection(conStr))
            {
                //执行对象
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    //返回第1行的第1列
                    o = cmd.ExecuteScalar();
                    Console.WriteLine(o);
                }
            }

            Console.ReadKey();
        }
    }
}
