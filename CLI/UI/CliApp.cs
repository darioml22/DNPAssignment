using CLI.UI.ManageComments;
using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using Entities;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp()
{
    /*private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;
    private readonly IPostRepository postRepository;
    private readonly AddCommentView addCommentView;
    private readonly AddPostView addPostView;
    private readonly AddUserView addUserView;

    public CliApp(ICommentRepository commentRepository) : this()
    {
        this.commentRepository = commentRepository;
        addCommentView = new AddCommentView(commentRepository);
        addPostView = new AddPostView(postRepository);
        addUserView = new AddUserView(userRepository);
        
    }

    public async Task StartAsync()
    {
       Console.WriteLine("Welcome to my forum app, what do you want to do? \n Type 1 for manage posts \n Type 2 for manage users \n Type 3 for manage comments");
       string answer = Console.ReadLine();
       switch (answer)
       {
           case "1":
               await ManagePosts();
               break;
           case "2":
               await ManageUsers();
               break;
           case "3":
               await ManageComments();
               break;
       }
    }

    public async Task ManagePosts()
    {
        Console.WriteLine(
            "Managing posts \n Write 1 to write a post \n Write 2 to delete a post \n Write 3 to see a post \n Write 4 to see all posts" );
        string answer = Console.ReadLine();
        switch (answer)
        {
            case "1":
                Post post = await addPostView.AddPost();
                Console.WriteLine("Post created");
                break;
            case "2":
                DeletePostView deletePostView = new DeletePostView(postRepository);
                Post postToDelete = new Post();
                deletePostView.DeletePost(postToDelete);
                break;
            case "3":
                GetPostView getPostView = new GetPostView(postRepository);
                var selectedPost = new Post();
                getPostView.GetPost(selectedPost);
                break;
            case "4":
                postRepository.GetPosts();
                break;
        }
    }

    public async Task ManageUsers()
    {
        Console.WriteLine("Managing users \n Write 1 to create a user \n Write 2 to delete a user \n Write 3 to see a user \n Write 4 to update an user");
        string answer = Console.ReadLine();
        switch (answer)
        {
            case "1":
                User user = await addUserView.AddUser();
                Console.WriteLine("User created");
                break;
            case "2":
                DeleteUserView deleteUserView = new DeleteUserView(userRepository);
                var selectedUserId = new User();
                deleteUserView.DeleteUser(selectedUserId);
                break;
            case "3":
                GetUserView getUserView = new GetUserView(userRepository);
                var selectedUser = new User();
                getUserView.GetUser(selectedUser);
                break;
            case "4":
                UpdateUserView updateUserView = new UpdateUserView(userRepository);
                var userToUpdate = new User();
                updateUserView.UpdateUser(userToUpdate);
                break;
        }
    }

    public async Task ManageComments()
    {
        Console.WriteLine("Managing comments \n Write 1 to create a comment \n Write 2 to delete a comment \n Write 3 to see a comment \n Write 4 to update a comment");
        string answer = Console.ReadLine();
        switch (answer)
        {
            case "1":
               Comment comment = await addCommentView.AddComment();
               Console.WriteLine("Comment created");
               break;
            case "2":
                DeleteCommentView deleteCommentView = new DeleteCommentView(commentRepository);
                Comment selectedCommentId = new Comment();
                deleteCommentView.DeleteComment(selectedCommentId);
                break;
            case "3":
                GetCommentView getCommentView = new GetCommentView(commentRepository);
                Comment selectedComment = new Comment();
                getCommentView.GetComment(selectedComment);
                break;
            case "4":
                UpdateCommentView updateCommentView = new UpdateCommentView(commentRepository);
                Comment commentToUpdate = new Comment();
                updateCommentView.UpdateComment(commentToUpdate);
                break;
        }
    }*/
}