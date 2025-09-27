namespace W04.YouTube;
public class YouTubeService
{
    private readonly List<Video> _catalog = new();

    // Simple in-memory search abstraction
    public List<Video> Search(string query)
        => _catalog.Where(v => (v._title + " " + v._channel).Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

    public Video? GetById(string id) => _catalog.FirstOrDefault(v => v._id == id);

    // helper to seed data for demo
    public void Seed(IEnumerable<Video> videos) => _catalog.AddRange(videos);
}
