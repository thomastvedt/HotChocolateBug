# Reproduction possible input mutation bug?

How to reproduce:
- run server (HotChocolate)
- Open Banana Cake Pop

The following mutations work:
```graphql
mutation {
  updateMyTimeZoneParam(
    timezoneId:"VGltZVpvbmUKaTE="
  ) {
  id
  }
}

```

```graphql
mutation {
  updateMyTimeZoneBoilerplate(input: {
    timezoneId:"VGltZVpvbmUKaTE="
  }) {
    entity {
      id
    }
  }
}

```

This one doesn't:

```graphql
mutation {
  updateMyTimeZone(input: {
    timezoneId:"VGltZVpvbmUKaTE="
  }) {
    user {
      id
    }
  }
}

```

Gives the following error message: 

```graphql
{
  "errors": [
    {
      "message": "Unable to convert the value of the argument `timezoneId` to `System.Int32`. Check if the requested type is correct or register a custom type converter.",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "updateMyTimeZone"
      ],
      "extensions": {
        "fieldName": "updateMyTimeZone",
        "argumentName": "timezoneId",
        "requestedType": "System.Int32"
      }
    }
  ]
}
```
