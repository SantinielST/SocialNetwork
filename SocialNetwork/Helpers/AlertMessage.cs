namespace SocialNetwork.PLL.Helpers;

/// <summary>
/// Класс для обработки предупреждающих об ошибке сообщений в консоли
/// </summary>
public class AlertMessage
{
    public static void Show(string message)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}
