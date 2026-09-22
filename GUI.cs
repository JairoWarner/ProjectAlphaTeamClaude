public static class GUI
{
    public static void CWLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void PressEnter()
    {
        Console.Write("\nPress \u001b[32mENTER\u001b[0m to continue");
        Console.ReadLine();
    }
}
