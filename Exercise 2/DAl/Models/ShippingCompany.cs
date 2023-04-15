namespace Exercise_2.DAl.Models
{
    public class ShippingCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
