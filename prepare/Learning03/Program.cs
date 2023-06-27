public class Fraction
{
    private int top;    
    private int bottom; 

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int numerator)
    {
        top = numerator;
        bottom = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        top = numerator;
        bottom = denominator;
    }

    public int Top
    {
        get { return top; }
        set { top = value; }
    }

    public int Bottom
    {
        get { return bottom; }
        set { bottom = value; }
    }

    public string GetFractionString()
    {
        return top + "/" + bottom;
    }

    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
}