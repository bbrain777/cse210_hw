namespace W04.YouTube;

public class Video
{
    public string _title = "";
    public string _author = "";
    public int _lengthSeconds;

    private readonly List<Comment> _comments = new();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment c) => _comments.Add(c);
    public int GetCommentCount() => _comments.Count;
    public IEnumerable<Comment> GetComments() => _comments.AsReadOnly();
}
