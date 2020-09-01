namespace Demo.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }

        public User(int id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        private User() : this(0, string.Empty) { }

        public override string ToString() => this.UserName;
    }
}
