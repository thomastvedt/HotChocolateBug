using Server.Domain;

namespace Server;

[ExtendObjectType("Mutation")]
public class UserMutation
{
    public async Task<User> SaveUserEmail(string userId, string email, [Service] UserService userService)
    {
        return await userService.SaveUserEmail(userId, email);
    }
}