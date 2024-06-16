using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UserDAL
    {
        DB db = new DB();
        public string Create(User u)
        {

            try
            {
                db.Users.Add(u);
                db.SaveChanges();
                return "ثبت اطلاعات با موفقیت انجام شد!";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با خطا مواجه شد:\n" + e.Message;
            }
        }
        public bool Read(User U)//for create
        {
            var q = db.Products.Where(i => U.UserName== U.UserName);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
