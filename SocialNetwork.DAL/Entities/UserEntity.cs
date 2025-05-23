﻿namespace SocialNetwork.DAL.Entities;

/// <summary>
/// Сущность пользователя
/// </summary>
public class UserEntity
{
    public int id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string photo { get; set; }
    public string favorite_movie { get; set; }
    public string favorite_book { get; set; }
}
