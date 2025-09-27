using System.Linq;
namespace W04.YouTube;
public class Playlist
{
    private readonly List<Video> _videos = new();
    public string _name = "";

    public void Add(Video v) => _videos.Add(v);
    public bool Remove(string id) => _videos.RemoveAll(v => v._id == id) > 0;
    public int GetTotalDuration() => _videos.Sum(v => v._durationSeconds);
    public IEnumerable<Video> ListVideos() => _videos.AsReadOnly();
}
