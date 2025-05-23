﻿namespace SocialNetwork.DAL.Entities;

/// <summary>
/// Сущность сообщения
/// </summary>
public class MessageEntity
{
    public int id { get; set; }
    public string content { get; set; }
    public int sender_id { get; set; }
    public int recipient_id { get; set; }
}
