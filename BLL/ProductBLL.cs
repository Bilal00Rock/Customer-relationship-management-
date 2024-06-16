using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BLL
{
    public class ProductBLL
    {
        ProductDAL dal = new ProductDAL();
        public string Create(Product c)
        {
            if (dal.Read(c))
            {
                return dal.Create(c);
            }
            else
            {
                return "کاربری با همین شماره تماس در سیستم ثبت شده است!";
            }
        }
        public string Update(int id, Product c)
        {
            return dal.Update(id, c);
        }
        public DataTable Read(string s)
        {
            return dal.Read(s);
        }
        public Product Read(int id)
        {
            return dal.Read(id);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
