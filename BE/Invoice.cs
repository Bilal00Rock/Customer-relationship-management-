using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumer { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime CheckoutDate { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public User User { get; set; }

    }
}
