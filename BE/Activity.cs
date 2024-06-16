using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info  { get; set; }
        public DateTime Regdate { get; set; }
        public Customer Customer { get; set; }
        public ActivityCategory Category { get; set; }
        public User User { get; set; }
    }
}
