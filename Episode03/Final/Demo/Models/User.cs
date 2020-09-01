namespace Demo.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Key { get; private set; }
        public UserRef Reference => new UserRef(this.Key);

        public User(int id, string userName, UserRef reference)
        {
            this.Id = id;
            this.UserName = userName;
            this.Key = reference.Value;
        }

        private User() : this(0, string.Empty, UserRef.Empty) { }

        public override string ToString() => this.UserName;
    }
}
