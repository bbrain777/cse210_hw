namespace W04.YouTube;
public class User
{
    public string _name = "";
    private readonly List<Playlist> _playlists = new();

    public Playlist CreatePlaylist(string name)
    {
        var pl = new Playlist { _name = name };
        _playlists.Add(pl);
        return pl;
    }

    public Playlist? GetPlaylist(string name)
        => _playlists.FirstOrDefault(p => p._name == name);
}
