public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide() => _hidden = true;
    public bool IsHidden() => _hidden;

    public string GetDisplayText()
    {
        if (!_hidden) return _text;
        if (string.IsNullOrEmpty(_text)) return "";

        bool allPunct = true;
        foreach (char c in _text)
            if (!char.IsPunctuation(c)) { allPunct = false; break; }
        if (allPunct) return _text;

        string core = _text.TrimEnd('.', ',', ';', ':', '!', '?');
        string trail = _text.Substring(core.Length);
        return new string('_', System.Math.Max(1, core.Length)) + trail;
    }
}
