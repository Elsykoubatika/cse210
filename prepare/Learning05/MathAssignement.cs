using System;

public class MathAssignement : Assignement
{
    private string _textBookSection;
    private string _Problems;

    public MathAssignement(string problems, string textBook) : base("Roberto Rodriguez", "Fractions")
    {
        _Problems = problems;
        _textBookSection = textBook;
    }

    public string GetProblems()
    {
        return _Problems;
    }

    public string GettextBookSection()
    {
        return _textBookSection;
    }

    public string GetHomeWorkList()
    {
        return $"{_textBookSection} {_Problems}\n";
    }
}