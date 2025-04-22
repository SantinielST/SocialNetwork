using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class MessageService
{
    IMessageRepository messageRposirory = new MessageRepository();
    IUserRepository userRepository = new UserRepository();

    public IEnumerable<Message> GetIncomingMessageByUserId(int recipientId)
    {
        var messages = new List<Message>();

        messageRposirory.FindByRecipientId(recipientId).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindById(m.sender_id);
            var recipientUserEntity = userRepository.FindById(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });
        return messages;
    }

    public IEnumerable<Message> GetOutcommingMessageByUserId(int senderId)
    {
        var messages = new List<Message>();

        messageRposirory.FindBySenderId(senderId).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindById(m.sender_id);
            var recipientUserEntity = userRepository.FindById(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });
        return messages;
    }

    public void SendMessage(MessageSendingData messageSendingData)
    {
        if (string.IsNullOrEmpty(messageSendingData.Content))
        {
            throw new ArgumentNullException();
        }

        if (messageSendingData.Content.Length > 5000)
        {
            throw new ArgumentOutOfRangeException();
        }

        var findUserEntity = userRepository.FindByEmail(messageSendingData.RecipientEmail);
        if (findUserEntity is null)
        {
            throw new UserNotFoundException();
        }

        var messageEntity = new MessageEntity()
        {
            content = messageSendingData.Content,
            sender_id = messageSendingData.SenderId,
            recipient_id = findUserEntity.id
        };

        if (messageRposirory.Create(messageEntity) == 0)
        {
            throw new Exception();
        }
    }
}
