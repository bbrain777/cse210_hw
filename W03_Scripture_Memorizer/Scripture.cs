using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new();
    private Random _random = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (var token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            _words.Add(new Word(token));
    }

    public string GetDisplayText()
    {
        string body = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}  {body}";
    }

    public void HideRandomWords(int count)
    {
        var visible = _words.Where(w => !w.IsHidden()).ToList();
        if (visible.Count == 0) return;

        int toHide = Math.Min(count, visible.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _random.Next(visible.Count);
            visible[idx].Hide();
            visible.RemoveAt(idx);
            if (visible.Count == 0) break;
        }
    }

    public bool AllWordsHidden() => _words.All(w => w.IsHidden());
}
