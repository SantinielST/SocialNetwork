using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Представление отправленных сообщений.
/// </summary>
internal class UserOutcomingMessageView
{
    public void Show(IEnumerable<Message> outcomingMessages)
    {
        Console.WriteLine("Исходящие сообщения");

        if (outcomingMessages.Count() == 0)
        {
            Console.WriteLine("Исходящих сообщений нет!");
            return;
        }

        outcomingMessages.ToList().ForEach(outcomingMessage =>
        {
            Console.WriteLine($"Кому: {outcomingMessage.RecipientEmail}. Текст сообщения: {outcomingMessage.Content}");
        });
    }
}
