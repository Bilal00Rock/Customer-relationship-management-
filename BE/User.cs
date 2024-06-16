using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Pic { get; set; }
        public bool Status { get; set; }
        public DateTime RegDate { get; set; }
        public List<Activity> Activity { get; set; } = new List<Activity>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Reminder> Reminders { get; set; } = new List<Reminder>();
    }
}
