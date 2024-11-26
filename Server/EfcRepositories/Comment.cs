namespace EfcRepositories;

public class Comment
{
    private Comment(){}
    public int Id { get; set; } 
    public string Content { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}