﻿using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

/// <summary>
/// Репозиторий пользователя
/// </summary>
public class UserRepository : BaseRepository, IUserRepository
{
    public int Create(UserEntity userEntity)
    {
        return Execute(@"insert into users (firstname,lastname,password,email) 
                             values (:firstname,:lastname,:password,:email)", userEntity);
    }

    public IEnumerable<UserEntity> FindAll()
    {
        return Query<UserEntity>("select * from users");
    }

    public UserEntity FindByEmail(string email) 
    {
        return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
    }


    public UserEntity FindById(int id)
    {
        return QueryFirstOrDefault<UserEntity>("select * from users where Id = :id_p", new { id_p = id });
    }

    public int Update(UserEntity userEntity)
    {
        return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password,
                         email = :email, photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
    }

    public int DeleteById(int id)
    {
        return Execute("delete from users where id = :id_p", new { id_p = id });
    }
}
