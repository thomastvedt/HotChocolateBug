namespace Server.Domain;

public class UserService
{
    public Task<User> GetUser(int userId)
    {
        return Task.FromResult(new User(userId, "Thomas", 39, "thomas@gulost.net", 1));
    }

    public Task<User> SaveUserTimezone(int userId, int timezoneId)
    {
        return Task.FromResult(new User(userId, "Thomas", 39, "thomas@gulost.net", timezoneId));
    }
}