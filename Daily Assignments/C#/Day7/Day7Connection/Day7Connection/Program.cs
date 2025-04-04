using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace Day7Connection
{
    internal class Program
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //InsertData();
            //DeleteData();
            //SelectData();
            //SelectionWithCondition();
            //Empcount();
            UpdateData();

            Console.ReadLine();
        }

        public static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = DESKTOP-AUT68C9\\SQLEXPRESS;initial catalog = ITfirmDB;integrated security = true;");
            con.Open();
            return con;
        }

        public static void SelectData()
        {
            con = getConnection();
            cmd = new SqlCommand("select * from emp", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1]);
                Console.WriteLine("Employee Number = " + dr["empno"]);
                Console.WriteLine("Employee Name = " + dr["ename"]);
                Console.WriteLine("Employee Job = " + dr[2]);
                Console.WriteLine("Manager ID = " + dr["mgr_id"]);
                Console.WriteLine("Employee Salary = " + dr[5]);
            }

            con.Close();
        }

        public static void SelectionWithCondition()
        {
            con = getConnection();
            StringBuilder sbq = new StringBuilder();
            sbq.Append("select * from emp where sal > 2000");

            cmd = new SqlCommand(sbq.ToString(), con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["Empno"]}, {dr["Ename"]}, {dr["sal"]}");
            }

            con.Close();
        }

        public static void InsertData()
        {
            con = getConnection();
            int eid, deptid;
            string ename, job;
            decimal sal;
            DateTime hd;

            Console.WriteLine("Enter Eid :");
            eid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name :");
            ename = Console.ReadLine();
            Console.WriteLine("Enter Job :");
            job = Console.ReadLine();
            Console.WriteLine("Enter Hire Date (yyyy-mm-dd):");
            hd = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Salary :");
            sal = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter dept :");
            deptid = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("insert into emp(empno,ename,job,hire_date,sal,deptno) values(@ecode,@name,@job,@hd,@salary,@did)", con);

            cmd.Parameters.AddWithValue("ecode", eid);
            cmd.Parameters.AddWithValue("name", ename);
            cmd.Parameters.AddWithValue("job", job);
            cmd.Parameters.AddWithValue("hd", hd);
            cmd.Parameters.AddWithValue("salary", sal);
            cmd.Parameters.AddWithValue("did", deptid);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Record added successfully.." : "Unable to add a record ..");

            con.Close();
        }

        static void DeleteData()
        {
            con = getConnection();
            Console.WriteLine("Enter the empno to delete :");
            int empno = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd1 = new SqlCommand("select * from emp where empno = @eno", con);
            cmd1.Parameters.AddWithValue("@eno", empno);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            Console.WriteLine("--------------------------");
            while (dr1.Read())
            {
                for (int i = 0; i < dr1.FieldCount; i++)
                {
                    Console.WriteLine(dr1[i]);
                }
            }

            dr1.Close(); 

            Console.WriteLine("Are you sure to delete this record ? (Y/N) ");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                cmd = new SqlCommand("delete from emp where empno = @eno", con);
                cmd.Parameters.AddWithValue("@eno", empno);
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result > 0 ? "Record deleted successfully..." : "Deletion failed.");
            }
            else
                Console.WriteLine("Not received proper choice");

            con.Close();
        }

        static void Empcount()
        {
            con = getConnection();
            cmd = new SqlCommand("select count(empno) from emp", con);

            int empcount = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine("The Total number of Employees are {0}", empcount);

            con.Close();
        }
        //Update
        static void UpdateData()
        {
            con = getConnection();

            Console.WriteLine("Enter Employee Number to update:");
            int empno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new job title:");
            string job = Console.ReadLine();

            Console.WriteLine("Enter new salary:");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            cmd = new SqlCommand("update emp set job = @job, sal = @sal where empno = @eno", con);
            cmd.Parameters.AddWithValue("@job", job);
            cmd.Parameters.AddWithValue("@sal", salary);
            cmd.Parameters.AddWithValue("@eno", empno);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Record updated successfully..." : "Update failed.");

            con.Close();
        }
    }
}



