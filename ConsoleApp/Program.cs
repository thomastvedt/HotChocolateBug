using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

Console.WriteLine("Hello, World!");
var serviceCollection = new ServiceCollection();
serviceCollection.AddMyClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:4000/graphql"));
var services = serviceCollection.BuildServiceProvider();
var client = services.GetRequiredService<IMyClient>();

var result1 = await client.Ping.ExecuteAsync();
var test1 = result1.Data.Ping == "pong";
Console.WriteLine("Ping: " + result1.Data.Ping);

var result2 = await client.SaveUserEmail.ExecuteAsync("123", "valid@email.com");
var test2 = result2.Data?.SaveUserEmail.Email == "valid@email.com";

var result3 = await client.SaveUserEmail.ExecuteAsync("123", "invalid_email");
var shouldBeError = result3.IsErrorResult();

// This is false, but I think it should be true??:
var shouldBeExpectedErrorCode = result3.Errors.First().Code == "CUSTOM_ERROR_CODE";

var err = result3.Errors.First();
Console.WriteLine("Expected error code CUSTOM:ERROR_CODE..");
Console.WriteLine("Error CODE:" + (err.Code ?? "NULL")); // :-(
Console.WriteLine("Error CODE is hidden inside err.Extensions.:");
Console.WriteLine(err.Extensions["body"]);
