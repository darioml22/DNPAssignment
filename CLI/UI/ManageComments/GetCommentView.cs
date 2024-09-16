using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class GetCommentView
{
    public readonly ICommentRepository commentRepository;
    CliApp cliApp;

    public GetCommentView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
        
    }
    
    public void GetComment(Comment comment)
    {
        Console.WriteLine("Enter comment id");
        comment.Id = Convert.ToInt32(Console.ReadLine());
        commentRepository.GetComment(comment.Id);
    }
}