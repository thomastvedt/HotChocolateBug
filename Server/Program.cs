using HotChocolate.AspNetCore;
using Server;
using Server.Domain;
using Server.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<UserQuery>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<UserMutation>()
    .AddType<UserType>()
    .AddType<TimeZoneType>()
    .AddGlobalObjectIdentification()
    .AddMutationConventions(new MutationConventionOptions()
    {
        ApplyToAllMutations = false
    })
    ;

builder.Services.AddTransient<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseRouting();
app.UseEndpoints(ep =>
{
    ep.MapGraphQL()
        .WithOptions(new GraphQLServerOptions
        {
            Tool =
            {
                Enable = true
            },
            AllowedGetOperations = AllowedGetOperations.QueryAndMutation,
            EnableSchemaRequests = true
        });
    ep.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello world");
    });
});

app.Run();