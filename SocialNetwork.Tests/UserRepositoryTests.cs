using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests;

/// <summary>
/// Тесты на проверку CRUD комманд для репозитория пользователя
/// </summary>
public class UserRepositoryTests
{
    IUserRepository _userRepository = new UserRepository();
    UserEntity _user = new UserEntity 
    { 
        firstname = "testFirstName",
        lastname = "testLastName",
        email = "test@test.email",
        password = "testtest",
    };

    [Fact]
    public void CreateNewAndFindByEmailMustCorrect()
    {
        _userRepository.Create(_user);

        Assert.True(_user.email == _userRepository.FindByEmail(_user.email).email);
    }

    [Fact]
    public void UpdateNewAndFindByIdMustCorrect()
    {
        _user.id = _userRepository.FindByEmail(_user.email).id;
        _user.photo = "url";
        _user.favorite_book = "Book";
        _user.favorite_movie = "Movie";
            
        _userRepository.Update(_user);

        Assert.True(_user.photo == _userRepository.FindByEmail(_user.email).photo);
        Assert.True(_user.favorite_book == _userRepository.FindByEmail(_user.email).favorite_book);
        Assert.True(_user.favorite_movie == _userRepository.FindByEmail(_user.email).favorite_movie);
    }

    [Fact]
    public void DeleteByIdMustCorrect()
    {
        _user.id = _userRepository.FindByEmail(_user.email).id;
        var result = _userRepository.DeleteById(_user.id);

        Assert.True(result == 1);
    }
}
