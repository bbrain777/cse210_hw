namespace W04.YouTube;
public class Player
{
    private Video? _current;
    private Queue<Video> _queue = new();

    public void Load(IEnumerable<Video> items)
    {
        _queue = new Queue<Video>(items);
        _current = _queue.Count > 0 ? _queue.Peek() : null;
    }

    public void Play()
    {
        if (_current is null && _queue.Count > 0) _current = _queue.Dequeue();
        // Pretend to play video here (abstraction hides details)
    }

    public void Pause() { /* hidden playback details */ }

    public void Next()
    {
        if (_queue.Count > 0) _current = _queue.Dequeue();
        else _current = null;
    }

    public bool IsPlaying() => _current is not null;
}
