﻿namespace EfcRepositories;

public class Post
{
    private Post(){}
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
}