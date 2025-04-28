using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

/// <summary>
/// Интерфейс репозитория друга
/// </summary>
public interface IFriendRepository
{
    int Create(FriendEntity friendEntity);
    IEnumerable<FriendEntity> FindAllByUserId(int userId);
    int Delete(int id);
}
