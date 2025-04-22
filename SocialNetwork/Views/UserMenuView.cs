using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

internal class UserMenuView(UserService userService)
{
    UserService _userService;

    public void Show(User user)
    {
        while (true)
        {
            Console.WriteLine($"Входящие сообщения: {user.IncomingMessages.Count()}");
            Console.WriteLine($"Исходящие сообщения: {user.OutcomingMessages.Count()}");

            Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
            Console.WriteLine("Редактировать мой профиль (нажмите 2)");
            Console.WriteLine("Добавить в друзья (нажмите 3)");
            Console.WriteLine("Написать сообщение (нажмите 4)");
            Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
            Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
            Console.WriteLine("Выйти из профиля (нажмите 7)");

            string keyValue = Console.ReadLine();

            if (keyValue == "7") break;

            switch (keyValue)
            {
                case "1":
                    Program.userInfoView.Show(user);
                    break;

                case "2":
                    Program.userDataUpdateView.Show(user);
                    break;

                case "3":
                    break;

                case "4":
                    Program.messageSendingView.Show(user);
                    break;

                case "5":
                    Program.incomingMessageView.Show(user.IncomingMessages);
                    break;

                case "6":
                    Program.outcomingMessageView.Show(user.OutcomingMessages);


            }
        }
    }
}
