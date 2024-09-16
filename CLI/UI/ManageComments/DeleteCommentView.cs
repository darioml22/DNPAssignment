using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class DeleteCommentView
{
    public readonly ICommentRepository commentRepository;
    CliApp cliApp;

    public DeleteCommentView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
        
    }
    
    public void DeleteComment(Comment comment)
    {
        Console.WriteLine("Enter comment id");
        comment.Id = Convert.ToInt32(Console.ReadLine());
        commentRepository.DeleteComment(comment);
        Console.WriteLine("Comment deleted");
    }
}