namespace Exercise_2.DAl.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}