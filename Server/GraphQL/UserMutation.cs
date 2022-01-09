using HotChocolate.Resolvers;
using Server.Domain;

namespace Server.GraphQL;

public record BoilerplateInput([property: ID(nameof(Domain.TimeZone))] int TimezoneId);

public record BoilerplatePayload(User Entity);

[ExtendObjectType("Mutation")]
public class UserMutation
{
    [UseMutationConvention]
    public async Task<User> UpdateMyTimeZone(
        [ID(nameof(Domain.TimeZone))] int timezoneId,
        [Service] UserService userService,
        IResolverContext context)
    {
        var userId = 1;
        return await userService.SaveUserTimezone(userId, timezoneId);
    }
    
    [UseMutationConvention(Disable = true)]
    public async Task<User> UpdateMyTimeZoneParam(
        [ID(nameof(Domain.TimeZone))] int timezoneId,
        [Service] UserService userService,
        IResolverContext context)
    {
        var userId = 1;
        return await userService.SaveUserTimezone(userId, timezoneId);
    }
    
    [UseMutationConvention(Disable = true)]
    public async Task<BoilerplatePayload> UpdateMyTimeZoneBoilerplate(
        BoilerplateInput input,
        [Service] UserService userService,
        IResolverContext context)
    {
        var userId = 1;
        var result = await userService.SaveUserTimezone(userId, input.TimezoneId);
        return new BoilerplatePayload(result);
    }
}