namespace Entities;

public class User
{
    public User(int Id, string Username, string Password)
    {
        this.Id = Id;
        this.Username = Username;
        this.Password = Password;
    }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}