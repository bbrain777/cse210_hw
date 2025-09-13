using System;

public class Entry
{
    public string _date = "";      
    public string _prompt = "";    
    public string _response = "";  
    public string _mood = "";      

    public void Display()
    {
        Console.WriteLine($"[{_date}] Mood: {_mood}");
        Console.WriteLine($"Prompt:   {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileLine()
    {
        return $"{_date}~|~{_prompt}~|~{_response}~|~{_mood}";
    }

    public static Entry FromFileLine(string line)
    {
        var parts = line.Split(new[] { "~|~" }, StringSplitOptions.None);
        if (parts.Length < 3)
        {
            return new Entry { _prompt = "Malformed entry", _response = line };
        }
        return new Entry
        {
            _date = parts[0],
            _prompt = parts[1],
            _response = parts[2],
            _mood = parts.Length >= 4 ? parts[3] : ""
        };
    }
}
