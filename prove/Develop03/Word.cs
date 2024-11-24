using System;
using System.Security.Cryptography.X509Certificates;

public class Word
{
    private string _text;
    private bool _isHiden;

    public Word(string text)
    {
        _text = text;
        _isHiden = false;
    }
    public void Hide()
    {
        _isHiden = true;
    }
    public void Show()
    {   
        _isHiden = false;
    }
    public bool IsHidden()
    {
        return _isHiden;
    }
    public string GetDisplayText()
    {
        if (_isHiden)
        {
            return "____";
        }
            
        else
        {
            return _text;
        }
    }

}