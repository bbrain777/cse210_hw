using W04.YouTube;

static void PrintVideo(Video v)
{
    Console.WriteLine($"Title: {v._title}");
    Console.WriteLine($"Author: {v._author}");
    Console.WriteLine($"Length: {v._lengthSeconds} seconds");
    Console.WriteLine($"Comments: {v.GetCommentCount()}");

    foreach (var c in v.GetComments())
    {
        Console.WriteLine($" - {c._name}: {c._text}");
    }
    Console.WriteLine();
}

var videos = new List<Video>();

var v1 = new Video("Intro to OOP", "CS101", 420);
v1.AddComment(new Comment("Allison", "Very clear explanation!"));
v1.AddComment(new Comment("Ben", "Helped me a lot."));
v1.AddComment(new Comment("Chika", "Please do inheritance next."));
videos.Add(v1);

var v2 = new Video("Abstraction vs Encapsulation", "DevTalks", 605);
v2.AddComment(new Comment("Dara", "Great real-world examples."));
v2.AddComment(new Comment("Ethan", "Short and sweet."));
v2.AddComment(new Comment("Fiona", "Now I finally get it!"));
videos.Add(v2);

var v3 = new Video("C# Classes & Objects", "CodeLab", 515);
v3.AddComment(new Comment("Grace", "Code samples were perfect."));
v3.AddComment(new Comment("Hassan", "Please share the repo link."));
v3.AddComment(new Comment("Ivy", "Clear naming conventions."));
videos.Add(v3);

foreach (var v in videos)
{
    PrintVideo(v);
}

// Convenience: save output to a file for screenshot
var sb = new System.Text.StringBuilder();
foreach (var v in videos)
{
    sb.AppendLine($"Title: {v._title}");
    sb.AppendLine($"Author: {v._author}");
    sb.AppendLine($"Length: {v._lengthSeconds} seconds");
    sb.AppendLine($"Comments: {v.GetCommentCount()}");
    foreach (var c in v.GetComments())
    {
        sb.AppendLine($" - {c._name}: {c._text}");
    }
    sb.AppendLine();
}
File.WriteAllText("execution_output.txt", sb.ToString());
Console.WriteLine("execution_output.txt created. Take your screenshot now.");
