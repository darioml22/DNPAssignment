using RepositoryContracts;
using CLI.UI;
using FileRepositories;


Console.WriteLine("Starting...");
ICommentRepository commentRepository = new CommentFileRepository();
    
CliApp cliApp = new CliApp(commentRepository);
await cliApp.StartAsync();