using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();
        public string Create(User u)
        {
            if (dal.Read(u))
            {
                return dal.Create(u);
            }
            else
            {
                return "نام کاربری وارد شده تکراری میباشد!";
            }
        }
    }
}
