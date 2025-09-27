namespace W04.YouTube;
public class Video
{
    public string _id = "";
    public string _title = "";
    public string _channel = "";
    public int _durationSeconds = 0;
    public List<string> _tags = new();
    public long _views = 0;

    public string GetDisplayTitle() => $"{_title} — {_channel}";
}
