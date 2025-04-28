namespace SocialNetwork.BLL.Models;

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public class UserRegistrationData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
