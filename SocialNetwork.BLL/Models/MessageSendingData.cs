namespace SocialNetwork.BLL.Models;

/// <summary>
/// Модель для отправки сообщений
/// </summary>
public class MessageSendingData
{
    public int SenderId { get; set; }
    public string Content { get; set; }
    public string RecipientEmail { get; set; }
}
