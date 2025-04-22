using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    internal class Program
    {
        static UserService userService;
        static MessageService messageService;
        public static MainView mainView;
        public static RegiststrationView registstrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static IncomingMessageView userIncomingMessageView;
        public static OutcomingMessageView userOutcomingMessageView;


        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registstrationView = new RegiststrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService ,userService);
            userIncomingMessageView = new IncomingMessageView();
            userOutcomingMessageView = new OutcomingMessageView();

            while (true)
            {
                mainView.Show();
            }
        }
    }
}
