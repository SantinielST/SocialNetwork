using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

internal class UserFriendsView
{
    public void Show(IEnumerable<User> friends)
    {
        Console.WriteLine("Мои друзья");

        if (friends.Count() == 0)
        {
            Console.WriteLine("У вас нет друзей");
            return;
        }

        friends.ToList().ForEach(friend =>
        {
            Console.WriteLine($"Email друга: {friend.Email}. Имя друга: {friend.FirstName}. Фамилия друга: {friend.LastName}");
        });
    }
}
