# BreweryWholesaleSystem

Brewery Wholesale System is a system used to track the sales of beer. We have used the onion architecture using .net 6 and sql server in building this system.

## Features

- List all the beers by brewery.
- Brewer can add new beer
- Delete beer
- Add the sale of an existing beer to an existing wholesaler.
- A wholesaler can update the remaining quantity of a beer in his stock.
- A client can request a quote from a wholesaler.

## Libraries Used

Brewery Wholesale System uses a number of libraries to work properly:

- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Swagger
- MediatR.Extensions.Microsoft.DependencyInjection
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.AspNetCore.Mvc.Versioning

## Architecure

There are multiple ways that we can split the onion, but we are going to choose the following approach where we are going to split the architecture into 4 layers:

- Core - will contain the Domain and Application layer Projects (we have used CQRS that separates the concerns in terms of reading and writing)
- Infrastructure – will include any projects related to the Infrastructure of the ASP.NET 6.0 Web API
- Presentation – The Projects that are linked to the UI or API. In our case, this folder will hold the API Project.

## Installation

It is necessary to run first time the following:

1. Go to package Manager Console and set the default project as Instracture\Persistence
2. Run the following commands to add migrations and to generate/update the database.

```sh
Add-Migration Initial
Update-Database
```
