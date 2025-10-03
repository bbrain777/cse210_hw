namespace Mindfulness;

public class PromptDeck
{
    private readonly List<string> _all;
    private readonly Queue<string> _queue = new();

    public PromptDeck(IEnumerable<string> items)
    {
        _all = new List<string>(items);
        Refill();
    }

    private void Refill()
    {
        var shuffled = _all.OrderBy(_ => new Random().Next()).ToList();
        _queue.Clear();
        foreach (var s in shuffled) _queue.Enqueue(s);
    }

    public string Next()
    {
        if (_queue.Count == 0) Refill();
        return _queue.Dequeue();
    }
}
