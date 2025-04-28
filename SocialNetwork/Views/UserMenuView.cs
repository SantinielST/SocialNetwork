using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Представление меню авторизованного пользователя
/// </summary>
/// <param name="userService"></param>
internal class UserMenuView(UserService userService)
{
    UserService _userService = userService;

    public void Show(User user)
    {
        while (true)
        {
            Console.WriteLine($"Входящие сообщения: {user.IncomingMessages.Count()}");
            Console.WriteLine($"Исходящие сообщения: {user.OutcomingMessages.Count()}");

            Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
            Console.WriteLine("Редактировать мой профиль (нажмите 2)");
            Console.WriteLine("Добавить в друзья (нажмите 3)");
            Console.WriteLine("Посмотреть список друзей (нажмите 4)");
            Console.WriteLine("Написать сообщение (нажмите 5)");
            Console.WriteLine("Просмотреть входящие сообщения (нажмите 6)");
            Console.WriteLine("Просмотреть исходящие сообщения (нажмите 7)");
            Console.WriteLine("Выйти из профиля (нажмите 8)");

            string keyValue = Console.ReadLine();

            if (keyValue == "8")
            {
                Console.WriteLine();
                break;
            }

            Console.WriteLine();
            switch (keyValue)
            {
                case "1":
                    Program.userInfoView.Show(user);
                    Console.WriteLine();
                    break;

                case "2":
                    Program.userDataUpdateView.Show(user);
                    user = _userService.FindById(user.Id);
                    Console.WriteLine();
                    break;

                case "3":
                    Program.friendAddingDataView.AddFriend(user);
                    user = _userService.FindById(user.Id);
                    break;

                case "4":
                    Program.userFriendsView.Show(user.Friends);
                    Console.WriteLine();
                    break;

                case "5":
                    Program.messageSendingView.Show(user);
                    user = _userService.FindById(user.Id);
                    Console.WriteLine();
                    break;

                case "6":
                    Program.userIncomingMessageView.Show(user.IncomingMessages);
                    Console.WriteLine();
                    break;

                case "7":
                    Program.userOutcomingMessageView.Show(user.OutcomingMessages);
                    Console.WriteLine();
                    break;
            }
        }
    }
}
