using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int AccountIDD {  get; set; }
        [ForeignKey("AccountIDD")]
        public decimal Amount { get; set; }
        public string TransactionType {  get; set; }
        public DateTime Transdate {  get; set; }
       
        public Accounts Accounts { get; set; }
    }
}
