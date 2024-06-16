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

    public class CustomerBLL
    {
        CustomerDAL dal = new CustomerDAL();

        public string Create(Customer c)
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
        public string Update(int id, Customer c)
        {
            return dal.Update(id, c);
        }
        public DataTable Read(string s , int index)
        {
           return dal.Read(s, index);
        }
        public Customer Read(int id)
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
