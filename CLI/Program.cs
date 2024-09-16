// See https://aka.ms/new-console-template for more information

using InMemoryRepositories;
using RepositoryContracts;
using CLI.UI;

Console.WriteLine("Starting...");
IUserRepository userRepository = new UserInMemoryRepository();
ICommentRepository commentRepository = new CommentInMemoryRepository();
IPostRepository postRepository = new PostInMemoryRepository();

CliApp cliApp = new CliApp(userRepository, commentRepository, postRepository);
 await cliApp.StartAsync();