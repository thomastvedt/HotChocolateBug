namespace Server.Domain;

public class UserService
{
    public Task<User> GetUser(string id)
    {
        return Task.FromResult(new User(id, "Thomas", 39, "thomas@mail.com"));
    }

    public Task<User> SaveUserEmail(string id, string email)
    {
        if (!email.Contains("@"))
            throw new CustomDomainException("Invalid email");

        return Task.FromResult(new User(id, "Thomas", 39, email));
    }
}