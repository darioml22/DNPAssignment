using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class AddCommentView
{
    public readonly ICommentRepository commentRepository;

    public AddCommentView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
        
    }

    public async Task<Comment> AddComment()
    {
        Comment comment = new Comment();
        Console.WriteLine("Enter post ID");
        comment.PostId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter user ID");
        comment.UserId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter comment content");
        comment.Content = Console.ReadLine();
        return await commentRepository.AddComment(comment);
    }
}