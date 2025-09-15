using System;

public class Fraction
{
    // Encapsulated state
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
        NormalizeAndReduce();
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
        NormalizeAndReduce();
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom == 0 ? 1 : bottom; // guard: avoid divide-by-zero
        NormalizeAndReduce();
    }

    // Getters and Setters (encapsulated access)
    public int GetTop() => _top;
    public void SetTop(int top)
    {
        _top = top;
        NormalizeAndReduce();
    }

    public int GetBottom() => _bottom;
    public void SetBottom(int bottom)
    {
        _bottom = bottom == 0 ? 1 : bottom; // guard: avoid divide-by-zero
        NormalizeAndReduce();
    }

    // Public behaviors
    public string GetFractionString() => $"{_top}/{_bottom}";
    public double GetDecimalValue() => (double)_top / (double)_bottom;

    // EXCEEDS REQUIREMENTS -------------------------------

    // Returns a mixed-number string like "-2 1/3" when top >= bottom (in magnitude)
    public string GetMixedNumberString()
    {
        int whole = _top / _bottom; // integer division rounds toward zero
        int remainder = Math.Abs(_top % _bottom);
        if (remainder == 0) return $"{whole}"; // exact whole number
        if (whole == 0)
        {
            return $"{(IsNegative() ? "-" : "")}{remainder}/{_bottom}";
        }
        return $"{whole} {remainder}/{_bottom}";
    }

    // Add two fractions and return a new reduced result
    public Fraction Add(Fraction other)
    {
        int newTop = _top * other._bottom + other._top * _bottom;
        int newBottom = _bottom * other._bottom;
        return new Fraction(newTop, newBottom);
    }

    // Multiply two fractions and return a new reduced result
    public Fraction Multiply(Fraction other)
    {
        return new Fraction(_top * other._top, _bottom * other._bottom);
    }

    // ----------------------------------------------------

    // Helpers (private): normalization & reduction
    private void NormalizeAndReduce()
    {
        // Move sign to numerator; denominator should be positive
        if (_bottom < 0)
        {
            _bottom = -_bottom;
            _top = -_top;
        }

        int g = Gcd(Math.Abs(_top), Math.Abs(_bottom));
        if (g > 0)
        {
            _top /= g;
            _bottom /= g;
        }
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private bool IsNegative() => _top < 0;
}
