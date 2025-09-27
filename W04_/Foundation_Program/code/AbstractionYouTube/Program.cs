using W04.YouTube;
var svc = new YouTubeService();
svc.Seed(new[]
{
    new Video{ _id="1", _title="Intro to OOP", _channel="CS101", _durationSeconds=300 },
    new Video{ _id="2", _title="Abstraction vs Encapsulation", _channel="CS101", _durationSeconds=420 }
});

var results = svc.Search("OOP");
var user = new User { _name = "Allison" };
var pl = user.CreatePlaylist("Week04 Study");
foreach (var v in results) pl.Add(v);

var player = new Player();
player.Load(pl.ListVideos());
player.Play();
// Console output intentionally omitted; this is a design skeleton.
