using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (var e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var e in _entries)
                {
                    writer.WriteLine(e.ToFileLine());
                }
            }
            Console.WriteLine($"Journal saved to '{fileName}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found.\n");
                return;
            }

            _entries.Clear();

            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    _entries.Add(Entry.FromFileLine(line));
                }
            }

            Console.WriteLine($"Journal loaded from '{fileName}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}\n");
        }
    }

    public void Search(string term)
    {
        var lowered = (term ?? "").ToLowerInvariant();
        int matches = 0;

        foreach (var e in _entries)
        {
            if ((e._date ?? "").ToLowerInvariant().Contains(lowered) ||
                (e._prompt ?? "").ToLowerInvariant().Contains(lowered) ||
                (e._response ?? "").ToLowerInvariant().Contains(lowered) ||
                (e._mood ?? "").ToLowerInvariant().Contains(lowered))
            {
                e.Display();
                matches++;
            }
        }

        if (matches == 0)
        {
            Console.WriteLine("No matching entries found.\n");
        }
    }
}
