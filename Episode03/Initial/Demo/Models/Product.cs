namespace Demo.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Product(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        private Product() : this(0, string.Empty) { }

        public override string ToString() => this.Name;
    }
}
