using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    internal class Program
    {
        /// <summary>
        /// Подключаем сервисы и представдения
        /// </summary>
        static UserService userService;
        static MessageService messageService;
        public static MainView mainView;
        public static RegiststrationView registstrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static FriendAddingDataView friendAddingDataView;
        public static UserFriendsView userFriendsView;

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            // Создание объектов
            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registstrationView = new RegiststrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService ,userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            friendAddingDataView = new FriendAddingDataView(userService);
            userFriendsView = new UserFriendsView();

            // Запуск основного окна
            while (true)
            {
                mainView.Show();
            }
        }
    }
}
