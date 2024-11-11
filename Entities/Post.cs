namespace Entities;

public class Post
{
    public Post(string Title, string Content, int UserId)
    {
        this.Title = Title;
        this.Content = Content;
        this.UserId = UserId;
    }

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int UserId { get; set; }
}