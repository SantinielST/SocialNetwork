namespace SocialNetwork.PLL.Helpers;

/// <summary>
/// Класс для обработки позитивных сообщений в консоли
/// </summary>
public class SuccessMessage
{
    public static void Show(string message)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}
