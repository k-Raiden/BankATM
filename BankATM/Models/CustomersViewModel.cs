using BankATM.DataAccess.EF.Models;

namespace BankATM.Models
{
    public class CustomersViewModel
    {
        public int CustomerId { get; set; }
        public DateTime Transactiondate { get; set; }

        public CustomersInfo ?CurrentCustomer { get; set; } 

        public List<CustomersInfo> CustomersList { get; set;}
    }
}
