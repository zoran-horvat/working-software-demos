﻿namespace Demo.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string OwnerKey { get; private set; }
        public UserRef OwnerRef => this.OwnerKey;

        public Product(int id, string name, UserRef owner)
        {
            this.Id = id;
            this.Name = name;
            this.OwnerKey = owner;
        }

        private Product() : this(0, string.Empty, UserRef.Empty) { }

        public override string ToString() => this.Name;
    }
}
