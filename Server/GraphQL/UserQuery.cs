using Server.Domain;

namespace Server.GraphQL;

[ExtendObjectType("Query")]
public class UserQuery
{
    public Task<string> Ping(string message)
    {
        return Task.FromResult(message);
    }

    public async Task<User> GetUser(int userId, [Service] UserService userService)
    {
        return await userService.GetUser(userId);
    }
}