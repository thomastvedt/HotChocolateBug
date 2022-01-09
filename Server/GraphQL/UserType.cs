using Server.Domain;

namespace Server.GraphQL;

public class UserResolvers
{
    public Domain.TimeZone GetUserTimezone([Parent] User user)
    {
        return new Domain.TimeZone()
        {
            Id = user.TimeZoneId,
            Name = "Number " + user.TimeZoneId
        };
    }
}

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(f => f.Id).ID(nameof(User));
        descriptor.Field(f => f.TimeZoneId).ID(nameof(Domain.TimeZone));
        descriptor.Field<UserResolvers>(x => x.GetUserTimezone(default!)).Name("timezone");
    }
}