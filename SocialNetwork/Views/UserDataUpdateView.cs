using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Представление для обновления информации о пользователе
/// </summary>
/// <param name="userService"></param>
internal class UserDataUpdateView(UserService userService)
{
    UserService _userService = userService;

    public void Show(User user)
    {
        Console.Write("Меня зовут: ");
        user.FirstName = Console.ReadLine();

        Console.Write("Моя фамилия: ");
        user.LastName = Console.ReadLine();

        Console.Write("Ссылка на моё фото: ");
        user.Photo = Console.ReadLine();

        Console.Write("Мой любимый фильм: ");
        user.FavoriteMovie = Console.ReadLine();

        Console.Write("Моя любимая книга: ");
        user.FavoriteBook = Console.ReadLine();

        _userService.Update(user);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ваш профиль успешно обновлён!");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
