namespace SocialNetwork.BLL.Models;

/// <summary>
/// Модель сообщения
/// </summary>
/// <param name="id"></param>
/// <param name="content"></param>
/// <param name="senderEmail"></param>
/// <param name="recipientEmail"></param>
public class Message(int id, string content, string senderEmail, string recipientEmail)
{
    public int Id { get; } = id;
    public string Content { get; } = content;
    public string SenderEmail { get; } = senderEmail;
    public string RecipientEmail { get; } = recipientEmail;
}
