namespace ApiContracts;

public class UpdateUserDto
{
    public int UserId { get; set; }
    public string NewUserName { get; set; }
    public string NewPassword { get; set; }
}