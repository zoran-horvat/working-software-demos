using System;

namespace Demo.Models
{
    public class UserRef
    {
        public string Key { get; }

        public UserRef(string key)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public static UserRef Empty => new UserRef(string.Empty);

        public static implicit operator UserRef(string key) => new UserRef(key);
        public static implicit operator string(UserRef reference) => reference.Key;
    }
}