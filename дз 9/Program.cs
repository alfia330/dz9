using System;

interface ICipher
{
    string Encode(string s);
    string Decode(string s);
}

class ACipher : ICipher
{
    public string Encode(string s)
    {
        char[] c = s.ToCharArray();
        for (int i = 0; i < c.Length; i++)
            c[i] = Shift(c[i], 1);
        return new string(c);
    }

    public string Decode(string s)
    {
        char[] c = s.ToCharArray();
        for (int i = 0; i < c.Length; i++)
            c[i] = Shift(c[i], -1);
        return new string(c);
    }

    private char Shift(char ch, int dir)
    {
        if (ch >= 'а' && ch <= 'я')
            return (char)('а' + (ch - 'а' + dir + 32) % 32);
        if (ch >= 'А' && ch <= 'Я')
            return (char)('А' + (ch - 'А' + dir + 32) % 32);
        if (ch >= 'a' && ch <= 'z')
            return (char)('a' + (ch - 'a' + dir + 26) % 26);
        if (ch >= 'A' && ch <= 'Z')
            return (char)('A' + (ch - 'A' + dir + 26) % 26);
        return ch;
    }
}

class BCipher : ICipher
{
    public string Encode(string s)
    {
        char[] c = s.ToCharArray();
        for (int i = 0; i < c.Length; i++)
            c[i] = Mirror(c[i]);
        return new string(c);
    }

    public string Decode(string s) { return Encode(s); }

    private char Mirror(char ch)
    {
        if (ch >= 'а' && ch <= 'я') return (char)('а' + 'я' - ch);
        if (ch >= 'А' && ch <= 'Я') return (char)('А' + 'Я' - ch);
        if (ch >= 'a' && ch <= 'z') return (char)('a' + 'z' - ch);
        if (ch >= 'A' && ch <= 'Z') return (char)('A' + 'Z' - ch);
        return ch;
    }
}

class Program
{
    static void Main()
    {
        ICipher a = new ACipher();
        ICipher b = new BCipher();
        string text = "Привет";
        string enc = a.Encode(text);
        Console.WriteLine("ACipher: " + enc);
        Console.WriteLine("ACipher decode: " + a.Decode(enc));
        enc = b.Encode(text);
        Console.WriteLine("BCipher: " + enc);
        Console.WriteLine("BCipher decode: " + b.Decode(enc));
    }
}

