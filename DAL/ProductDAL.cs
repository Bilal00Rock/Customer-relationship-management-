using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public class ProductDAL
    {
        DB db = new DB();

        public string Create(Product p)
        {

            try
            {
                db.Products.Add(p);
                db.SaveChanges();
                return "ثبت اطلاعات با موفقیت انجام شد!";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
        public bool Read(Product p)//for create
        {
            var q = db.Products.Where(i => p.Name == i.Name);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;
        }
        public DataTable Read()//for formload
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMFinal;Integrated Security=true");
            string cmd = "SELECT Id As [آیدی], Name AS [نام محصول], Price AS [قیمت محصول], Stock AS موجودی FROM dbo.Products";
            var sqladaptor = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladaptor);
            var ds = new DataSet();
            sqladaptor.Fill(ds);
            return ds.Tables[0];
        }
        /*  public DataTable Read(string s)//for search
          {
              SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMFinal;Integrated Security=true");
              SqlCommand cmd = new SqlCommand();
              cmd.CommandText = "dbo.SearchProduct";
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
        public DataTable Read(string s)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMFinal;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT   Name AS [نام محصول], Price AS [قیمت محصول],  Stock AS [موجودی] FROM Products WHERE Nmae LIKE @search OR id LIKE @search";
            cmd.Parameters.AddWithValue("@search", "%" + s + "%");
            cmd.Connection = con;

            var sqladaptor = new SqlDataAdapter();
            sqladaptor.SelectCommand = cmd;
            var ds = new DataSet();
            sqladaptor.Fill(ds);

            return ds.Tables[0];
        }

        public Product Read(int id)//for update and delete
        {
            return db.Products.Where(i => i.Id == id).FirstOrDefault();
        }

        public string Update(int id, Product p)
        {
            var q = db.Products.Where(i => i.Id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = p.Name;
                    q.Stock = p.Stock;
                    q.Price = p.Price;
                    db.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد!";
                }
                else
                    return "محصول یافت نشد!";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Products.Where(i => i.Id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    db.Products.Remove(q);
                    db.SaveChanges();
                    return "حذف اطلاعات با موفقیت انجام شد!";
                }
                else
                    return "محصول یافت نشد!";
            }
            catch (Exception e)
            {
                return "حذف اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
    }
}
