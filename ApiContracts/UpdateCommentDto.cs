namespace ApiContracts;

public class UpdateCommentDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
}