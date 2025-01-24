using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CustomerDAL
    {
        DB db = new DB();
        
        public string Create(Customer c)
        {
            try
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return "ثبت اطلاعات با موفقیت انجام شد!";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
        public bool Read(Customer c)//for create
        {
            var q = db.Customers.Where(i => c.PhoneNumber == i.PhoneNumber);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;
        }
        public DataTable Read()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMFinal;Integrated Security=true");
            string cmd = "SELECT id As [آیدی],Name AS [نام مشتری], PhoneNumber AS [شماره تماس], RegDate AS [تاریخ ثبت] FROM dbo.Customers WHERE(DeleteStatus = 0)";
            var sqladaptor = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladaptor);
            var ds = new DataSet();
            sqladaptor.Fill(ds);
            return ds.Tables[0];
        }
        /* public DataTable Read(string s, int index)
         {
             SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMFinal;Integrated Security=true");
             SqlCommand cmd = new SqlCommand();
             if (index == 0)
             {
                 cmd.CommandText = "dbo.SearchCustomer";
             }
             else if (index == 1)
             {
                 cmd.CommandText = "dbo.SearchCustomerName";
             }
             else if (index == 2)
             {
                 cmd.CommandText = "dbo.SearchCustomerPhone";
             }

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@search", s);
             cmd.Connection = con;

             var sqladaptor = new SqlDataAdapter();
             sqladaptor.SelectCommand = cmd;
             var commandbuilder = new SqlCommandBuilder(sqladaptor);
             var ds = new DataSet();
             sqladaptor.Fill(ds);
             return ds.Tables[0];
         }*/
        public DataTable Read(string s, int index)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMFinal;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();

            switch (index)
            {
                case 0:
                    cmd.CommandText = "SELECT Name AS [نام مشتری], PhoneNumber AS [شماره تماس],FORMAT(RegDate, 'hh:mm tt M/d/yyyy') AS [تاریخ ثبت] FROM Customers WHERE Name LIKE @search";
                    break;
                case 1:
                    cmd.CommandText = "SELECT  Name AS [نام مشتری], PhoneNumber AS [شماره تماس],FORMAT(RegDate, 'hh:mm tt M/d/yyyy') AS [تاریخ ثبت] FROM Customers WHERE Name LIKE @search";
                    break;
                case 2:
                    cmd.CommandText = "SELECT  Name AS [نام مشتری], PhoneNumber AS [شماره تماس],FORMAT(RegDate, 'hh:mm tt M/d/yyyy') AS [تاریخ ثبت] FROM Customers WHERE PhoneNumber LIKE @search";
                    break;
                default:
                    throw new ArgumentException("Invalid index value.");
            }

            cmd.Parameters.AddWithValue("@search", "%" + s + "%");
            cmd.Connection = con;

            var sqladaptor = new SqlDataAdapter();
            sqladaptor.SelectCommand = cmd;
            var ds = new DataSet();
            sqladaptor.Fill(ds);

            return ds.Tables[0];
        }

        public Customer Read(int id)
        {
            return db.Customers.Where(i => i.Id == id).FirstOrDefault();
        }
        public string Update(int id, Customer c)
        {
            var q = db.Customers.Where(i => i.Id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = c.Name;
                    q.PhoneNumber = c.PhoneNumber;
                    db.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد!";
                }
                else
                    return "کاربر یافت نشد!";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Customers.Where(i => i.Id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "حذف اطلاعات با موفقیت انجام شد!";
                }
                else
                    return "کاربر یافت نشد!";
            }
            catch (Exception e)
            {
                return "حذف اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
    }
}
