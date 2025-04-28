using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Представление для добавление в друзья пользователя
/// </summary>
/// <param name="userService"></param>
internal class FriendAddingDataView(UserService userService)
{
    UserService _userService = userService;

    public void AddFriend(User user)
	{
		try
		{
			var friendAddingData = new FriendAddingData();

			Console.Write("Введите email пользователя, которого хотите добавить в друзья: ");

			friendAddingData.FriendEmail = Console.ReadLine();
			friendAddingData.UserId = user.Id;

			_userService.AddFriend(friendAddingData);

			SuccessMessage.Show($"Вы успешно добавили {friendAddingData.FriendEmail} в друзья!");
		}
		catch (UserNotFoundException)
		{
			AlertMessage.Show("Пользователя с указанным email не существует!");
		}
		catch (Exception)
		{
            AlertMessage.Show("Произоша ошибка при добавлении пользотваеля в друзья!");
        }
	}
}
