namespace Entities;

public class Comment
{
    public Comment(string Content, int UserId, int PostId)
    {
        this.Content = Content;
        this.UserId = UserId;
        this.PostId = PostId;
    }
    public int Id { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    
}