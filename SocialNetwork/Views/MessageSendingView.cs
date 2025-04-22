using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

internal class MessageSendingView(MessageService messageService, UserService userService)
{
    MessgeService _messgeService;
    UserService _userService;

    public void Show(User user)
    {
        var messageSendingData = new MessageSendingData();

        Console.Write("Введите почтовый адрес получателя: ");
        messageSendingData.RecipientEmail = Console.ReadLine();

        Console.WriteLine("Введите сообщение (не более 5000 символов):");
        messageSendingData.Content = Console.ReadLine();

        messageSendingData.SenderId = user.Id;

        try
        {
            _messgeService.SendMessage(messageSendingData);

            SuccessMessage.Show("Сообщение было успешно отправлено!");

            user = _userService.FindById(user.Id);
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }
        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при отправке сообщения!");
        }
    }
}
