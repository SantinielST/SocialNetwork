using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services;

/// <summary>
/// Класс-сервис для работы с пользователями
/// </summary>
public class UserService
{
    MessageService messageService = new MessageService();
    IUserRepository userRepository = new UserRepository();
    IFriendRepository friendRepository = new FriendRepository();
    
    // Регистрация нового пользователя
    public void Register(UserRegistrationData userRegistrationData)
    {
        if (string.IsNullOrEmpty(userRegistrationData.FirstName))
        {
            throw new ArgumentNullException();
        }

        if (string.IsNullOrEmpty(userRegistrationData.LastName))
        {
            throw new ArgumentNullException();
        }

        if (string.IsNullOrEmpty(userRegistrationData.Password))
        {
            throw new ArgumentNullException();
        }

        if (string.IsNullOrEmpty(userRegistrationData.Email))
        {
            throw new ArgumentNullException();
        }

        if (userRegistrationData.Password.Length < 8)
        {
            throw new ArgumentNullException();
        }

        if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
        {
            throw new ArgumentNullException();
        }

        if (userRepository.FindByEmail(userRegistrationData.Email) != null)
        {
            throw new ArgumentNullException();
        }

        var userEntity = new UserEntity()
        {
            firstname = userRegistrationData.FirstName,
            lastname = userRegistrationData.LastName,
            password = userRegistrationData.Password,
            email = userRegistrationData.Email,
        };

        if (userRepository.Create(userEntity) == 0)
        {
            throw new Exception();
        }
    }

    // Аунтефикация пользователя
    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);

        if (findUserEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    // Поиск пользователя по Email
    public User FindByEmail(string email)
    {
        var findUserEntity = userRepository.FindByEmail(email);
        if (findUserEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    // Поиск пользователя по Id
    public User FindById(int id)
    {
        var findUserEntity = userRepository.FindById(id);
        if (findUserEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    // Поиск друзей пользователя по Id
    public IEnumerable<User> GetFriendsByUserId(int userId)
    {
        return friendRepository.FindAllByUserId(userId)
                .Select(friendsEntity => FindById(friendsEntity.friend_id));
    }

    // Добавление другого пользоввателя в друзья
    public void AddFriend(FriendAddingData friendAddingData)
    {
        var findUserEntity = userRepository.FindByEmail(friendAddingData.FriendEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var friendEntity = new FriendEntity()
        {
            user_id = friendAddingData.UserId,
            friend_id = findUserEntity.id
        };

        if (friendRepository.Create(friendEntity) == 0)
            throw new Exception();
    }

    // Обновление информации пользователя
    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favorite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };

        if (userRepository.Update(updatableUserEntity) == 0) throw new Exception();
    }

    // Построение модели пользователя из сущности пользователя
    private User ConstructUserModel(UserEntity userEntity)
    {
        var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
        var outcomingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);
        var friends = GetFriendsByUserId(userEntity.id);

        return new User(userEntity.id,
                      userEntity.firstname,
                      userEntity.lastname,
                      userEntity.password,
                      userEntity.email,
                      userEntity.photo,
                      userEntity.favorite_movie,
                      userEntity.favorite_book,
                      incomingMessages,
                      outcomingMessages,
                      friends);
    }
}
