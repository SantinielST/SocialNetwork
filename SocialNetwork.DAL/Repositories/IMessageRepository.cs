using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

/// <summary>
/// Интерфейс репозитория сообщения
/// </summary>
public interface IMessageRepository
{
    int Create(MessageEntity messageEntity);
    IEnumerable<MessageEntity> FindBySenderId(int senderId);
    IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
    int DeleteById(int messageId);
}
