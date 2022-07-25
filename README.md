# Start
1. open TaxService/Services/TaxService.cs 
1. endit line 16 and put in your API Key

Run
```
dotnet run --project TaxService/tax-api.csproj
```

Swagger page
```
https://localhost:7070/swagger/index.html
```
- currently there is no cert so you will get a warning you can ignore the warning
- use Order id = 1, 2, or 3 on the `Tax/order/{orderId}`
- use any Zip code you like on the `/Tax/location/{zipcode}`

Test
```
dotnet test
```

## TODO
1. create a real repository from a database or some such
1. create tests for the real repository
1. expand upon apis to allow for lists of orders and or zipcodes
1. change from object to concrete result objects based on the generic API design
1. add security around the REST APIs 
    - JWT, OAuth, etc...

## class structure
- Repositories
    - OrderRepository - contains the definition for a simple repo to retrieve order details
- Entities
    - OrderEntity - order entity returned from the OrderRepository
    - ItemEntity - line item for an order
- Services
    - TaxService - main service that utilizes the repo to fetch an order to call the TaxJar API
- Controllers
    - TaxController - REST API implementation