namespace Server.GraphQL;

public class TimeZoneType : ObjectType<Domain.TimeZone>
{
    protected override void Configure(IObjectTypeDescriptor<Domain.TimeZone> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(c => c.Id)
            .ResolveNode(((context, id) => context.DataLoader<TimeZoneByIdDataloader>().LoadAsync(id, context.RequestAborted)));

        descriptor.Field("timezoneId").Resolve(c => c.Parent<Domain.TimeZone>().Id);
    }
}