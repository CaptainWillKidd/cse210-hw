public class Video{
    private string _title;
    private string _author;
    private double _length;
    private List<Comment> _comments;

    public Video(string title, string author, double length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public string DisplayVideoInfo()
    {
        return $"Title: {_title}, Author: {_author}, Length: {_length} minutes";
    }

    public void DisplayComments()
    {
        Console.WriteLine("Comments: ");
        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }
    }

    public int NumberComments()
    {
        return _comments.Count;
    }
}