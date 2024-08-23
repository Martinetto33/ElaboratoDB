namespace DatabaseProject.model.code
{
    public class Account(string username, string email, string id)
    {
        public string Username { get; } = username;
        public string Email { get; } = email;
        public string Id { get; } = id;
        public Village? Village { get; set; } = null;
    }
}
