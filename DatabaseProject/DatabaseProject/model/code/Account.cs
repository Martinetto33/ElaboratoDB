
namespace DatabaseProject.model.code
{
    public class Account(string username, string email, string id)
    {
        public string Username { get; } = username;
        public string Email { get; } = email;
        public string Id { get; } = id;
        public Village? Village { get; set; } = null;

        public override bool Equals(object? obj)
        {
            return obj is Account account &&
                   Username == account.Username &&
                   Email == account.Email &&
                   Id == account.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Email, Id);
        }
    }
}
