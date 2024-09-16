using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class UpdateCommentView
{
    public readonly ICommentRepository commentRepository;
    CliApp cliApp;

    public UpdateCommentView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
        
    }
    
    public void UpdateComment(Comment comment)
    {
        Console.WriteLine("Enter comment id");
        comment.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter a new comment");
        comment.Content = Console.ReadLine();
        commentRepository.UpdateComment(comment);
    }
}