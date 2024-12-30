using Bank.Models.Entities;

namespace Bank.Models.ViewModel
{
    public class Accountviewmodel
    {
        public int AccId { get; set; }
        public int CustomerIDDD {  get; set; }
        public IEnumerable<Customer> customers {  get; set; }
        public decimal AccBalance {  get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }

    }
}
