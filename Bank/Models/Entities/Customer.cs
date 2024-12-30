namespace Bank.Models.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name {  get; set; }
        public string Email {  get; set; }
        public int phonenumber {  get; set; }
        public string Address {  get; set; }
        public IEnumerable<Accounts> Accountss { get; set; }

    }
}
