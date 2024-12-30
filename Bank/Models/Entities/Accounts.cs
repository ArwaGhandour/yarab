using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models.Entities
{
    public class Accounts
    {
        public int AccountsID { get; set; }
        public int CustomerIDD { get; set; }
        [ForeignKey("CustomerIDD")]
        public Customer customer {  get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance {  get; set; }
        public string AccountType { get; set; }
        public IEnumerable<Transaction> transactions {  get; set; }
    }
}
