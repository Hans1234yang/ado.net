using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace 练习2_sqlhelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.插入数据

            //（1)无参数 插入数据
            //string sql = "insert into StuTest(stuid,stuname,pwd)values(1,'hans','aaa')";

            //int result = SQLHelper.ExecuteNonQuery(sql);
            //Console.WriteLine(result);


            //(2)参数化  添加
            //string sql = "insert into StuTest (stuid,stuname,pwd)values(@iddd,@nameee,@pwddd);";

            //SqlParameter[] ps = {
            //     new SqlParameter("@iddd",(object)2),
            //     new SqlParameter("@nameee","Tom"),
            //     new SqlParameter("@pwddd","ddd")

            //};
            //int result = SQLHelper.ExecuteNonQuery(sql,ps);
            //Console.WriteLine(result);

            ////2.修改数据 ,(参数化修改)
            //string sql = "update StuTest set stuname=@nameee where stuid=@iddd";

            //SqlParameter[] ps = {
            //    new SqlParameter("@nameee","比尔盖茨"),
            //    new SqlParameter("@iddd",(object)2)
            //};

            //int res = SQLHelper.ExecuteNonQuery(sql,ps);
            //Console.WriteLine(res);



            //3. 删除数据 
            //string sql = "delete from StuTest where stuid=@iddd";
            //SqlParameter pID = new SqlParameter("@iddd",(object)5);
            //int count = SQLHelper.ExecuteNonQuery(sql,pID);
            //Console.WriteLine(count);


            //4.模糊查询，姓杨的多少人
            //string sql = "select count(*) from StuTest where stuname  like @nameee";

            //SqlParameter pName = new SqlParameter("@nameee","杨%");

            //int count = (int)SQLHelper.ExecuteScalar(sql,pName);
            //Console.WriteLine(count);


            //5. 读取数据 datareader 方法
            //using (SqlDataReader reader=SQLHelper.ExecuteReader("select * from Stutest"))
            //{
            //    List<string> list1 = new List<string>();
            //    while (reader.Read())
            //    {

            //        for(int i=0;i<reader.FieldCount;i++)
            //        {
            //            list1.Add(reader[i].ToString());
            //        }                                                     
            //    }
            //    foreach(var item in list1)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}                   
            //Console.ReadKey();

            //读取数据 方法2 通过streamwriter 写进txt文件 
            string sql = "select * from StuTest";
            using (StreamWriter writer=new StreamWriter("test.txt",true,Encoding.Default))
            {
                using (SqlDataReader reader=SQLHelper.ExecuteReader(sql))
                {
                    List<string> list1 = new List<string>();
                    while(reader.Read())
                    {
                        list1.Clear();
                        for(int i=0;i<reader.FieldCount;i++)
                        {
                            list1.Add(reader[i].ToString());
                        }
                        writer.WriteLine(string.Join(",",list1));
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
