# Quick reproduction HotChocolate StrawberryShake bug

How to reproduce:
- run server (HotChocolate)
- run console app (StrawberryShake)

** Expected result: **  
When running the console app using the generated StrawberryShake client, I expected that
my custom error code was returned. 

``` 
var result3 = await client.SaveUserEmail.ExecuteAsync("123", "invalid_email");
var shouldBeExpectedErrorCode = result3.Errors.First().Code == "CUSTOM_ERROR_CODE";
```

But `shouldBeExpectedErrorCode` = false..