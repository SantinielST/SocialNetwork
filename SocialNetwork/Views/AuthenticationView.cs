﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Представление для аунтентификации пользователя
/// </summary>
/// <param name="userService"></param>
internal class AuthenticationView(UserService userService)
{
    UserService _userService = userService;

    public void Show()
    {
        var authenticationData = new UserAuthenticationData();

        Console.WriteLine("Введите почтовый адрес:");
        authenticationData.Email = Console.ReadLine();

        Console.WriteLine("Введите пароль:");
        authenticationData.Password = Console.ReadLine();

        try
        {
            var user = _userService.Authenticate(authenticationData);
            SuccessMessage.Show($"Вы успешно вошли в социальную сеть!\nДобро пожаловать {user.FirstName}!");

            Program.userMenuView.Show(user);
        }
        catch (WrongPasswordException)
        {
            AlertMessage.Show("Пароль не корректный!");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }
    }
}
