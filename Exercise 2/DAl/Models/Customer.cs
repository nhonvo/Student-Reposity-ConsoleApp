namespace Exercise_2.DAl.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? Wallet { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
