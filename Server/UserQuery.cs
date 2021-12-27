using HotChocolate.AspNetCore.Authorization;
using Server.Domain;

namespace Server;

[ExtendObjectType("Query")]
[Authorize]
public class UserQuery
{
    public Task<string> Ping(string message)
    {
        return Task.FromResult(message);
    }

    public async Task<User> GetUser(string userId, [Service] UserService userService)
    {
        return await userService.GetUser(userId);
    }
}