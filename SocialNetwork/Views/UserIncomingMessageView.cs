using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Представление для просмотра входящих сообщений
/// </summary>
internal class UserIncomingMessageView
{
    public void Show(IEnumerable<Message> incomingMessages)
    {
        Console.WriteLine("Входящие сообщения:");

        if (incomingMessages.Count() == 0)
        {
            Console.WriteLine("Входящих сообщение нет!");
            return;
        }

        incomingMessages.ToList().ForEach(incomingMessage =>
        {
            Console.WriteLine($"От кого: {incomingMessage.SenderEmail}. Текст сообщения: {incomingMessage.Content}");
        });
    }
}
