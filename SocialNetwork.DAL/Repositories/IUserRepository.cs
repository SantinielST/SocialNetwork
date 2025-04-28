using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

/// <summary>
/// Интерфейс репозитория пользователя
/// </summary>
public interface IUserRepository
{
    int Create(UserEntity userEntity);
    UserEntity FindByEmail(string email);
    IEnumerable<UserEntity> FindAll();
    UserEntity FindById(int id);
    int Update(UserEntity userEntity);
    int DeleteById(int id);
}