﻿using Dapper;
using System.Data;
using System.Data.SQLite;

namespace SocialNetwork.DAL.Repositories;

/// <summary>
/// Базовый репозиторий для работы с БД
/// </summary>
public class BaseRepository
{
    protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            return connection.QueryFirstOrDefault<T>(sql, parameters);
        }
    }

    protected List<T> Query<T>(string sql, object parameters = null)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            return connection.Query<T>(sql, parameters).ToList();
        }
    }

    protected int Execute(string sql, object parameters = null)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            return connection.Execute(sql, parameters);
        }
    }

    private IDbConnection CreateConnection()
    {
        return new SQLiteConnection("Data Source=D:/Repos/SocialNetwork/SocialNetwork.DAL/DB/social_network.db");
    }
}
