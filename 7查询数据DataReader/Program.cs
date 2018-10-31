using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _7查询数据DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.准备sql语句
            string sql = "select * from Stu where Stuid < @Stuiddd";
            //2.连接字符串
          string strCon= ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            //3.参数
            SqlParameter pStuid = new SqlParameter("@Stuiddd", (object)5);

            //4.创建连接对象
            using (SqlConnection conn=new SqlConnection(strCon))
            {
                //5.创建执行对象
                using (SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    //6.添加参数
                    cmd.Parameters.Add(pStuid);

                    //7.打开
                    conn.Open();

                    //8.执行
                    SqlDataReader reader = cmd.ExecuteReader();

                    using(reader)
                    {
                        //.read的意思是指向下一行
                        while(reader.Read())
                        {
                            for(int i=0;i<reader.FieldCount;i++)
                            {
                                string data = reader[i].ToString();
                                Console.Write(data+',');
                            }
                            Console.WriteLine();  //输完了一条数据，换1行
                        }
                    }

                }
            }

            Console.ReadKey();
        }
    }
}
