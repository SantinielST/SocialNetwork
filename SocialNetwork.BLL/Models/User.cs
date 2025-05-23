﻿namespace SocialNetwork.BLL.Models;

/// <summary>
/// Модель для пользователя
/// </summary>
/// <param name="id"></param>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="password"></param>
/// <param name="email"></param>
/// <param name="photo"></param>
/// <param name="favoriteMovie"></param>
/// <param name="favoriteBook"></param>
/// <param name="incomingMessages"></param>
/// <param name="outcomingMessages"></param>
/// <param name="friends"></param>
public class User(int id, string firstName, string lastName, string password, string email,
    string photo, string favoriteMovie, string favoriteBook, IEnumerable<Message> incomingMessages,
    IEnumerable<Message> outcomingMessages, IEnumerable<User> friends)
{
    public int Id { get; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Password { get; set; } = password;
    public string Email { get; set; } = email;
    public string Photo { get; set; } = photo;
    public string FavoriteMovie { get; set; } = favoriteMovie;
    public string FavoriteBook { get; set; } = favoriteBook;

    public IEnumerable<Message> IncomingMessages { get; } = incomingMessages;
    public IEnumerable<Message> OutcomingMessages { get; } = outcomingMessages;
    public IEnumerable<User> Friends { get; } = friends;
}
