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
    
    public void DeleteComment(int id)
    {
        Console.WriteLine("Enter comment id");
        id = Convert.ToInt32(Console.ReadLine());
        commentRepository.DeleteComment(id);
        Console.WriteLine("Comment deleted");
    }
}