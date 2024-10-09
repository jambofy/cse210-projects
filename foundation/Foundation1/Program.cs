using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public string GetCommentDetails()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine(comment.GetCommentDetails());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create Video instances
        Video video1 = new Video("Introduction to C#", "Nyasha Ushewokunze", 300);
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Very informative."));
        
        Video video2 = new Video("Advanced C# Techniques", "Lee Timly", 450);
        video2.AddComment(new Comment("User3", "Learned a lot from this."));
        video2.AddComment(new Comment("User4", "Looking forward to more videos!"));
        
        // List of videos
        List<Video> videos = new List<Video> { video1, video2 };

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine();
        }
    }
}
