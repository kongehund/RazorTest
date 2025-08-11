\#About



This repository is intended as a solution that shows GraphQL example usage.



* The solution setup is ASP.NET + Razor Pages.
* The NuGet package HotChocolate is used to create a custom GraphQL schema and play with it at runtime.
* The NuGet package GraphQL.Client gives us a client we can use to access external GraphQL endpoints (independently of the GraphQL schema we set up)
* An example GraphQL schema is implemented - the example data is about books.



\#Prerequisites



\##.NET

This project uses .NET 9.



\##NuGet

If dependencies are not automatically installed when cloning the repo, ensure the online NuGet library is available in Visual Studio 

* In Visual Studio, it can be added in Tools - Options - NuGet Package Manager -Package Sources - add source https://api.nuget.org/v3/index.json



Install from "Project - Manage NuGet Packages..." :

* HotChocolate.AspNetCore
* HotChocolate.Data
* GraphQL.Client



\#Explanations of code

\##GraphQL folder

Added manually



Contains query operations available 



\##Models folder

Added manually



Contains example data models to be queried.



\##Services folder

In accordance with Dependency Injection principles, this folder contains the relevant services for the program.



E.g. the actual functionality of the queries in /GraphQL/, are defined in BookService.cs 



\#Using the program



* Run the program
* To access the GraphQL playground, append /graphql/ to localhost, i.e.:

&nbsp;	https://localhost:7040/graphql/

&nbsp;	(change port from 7040 to your port)

* In here you can inspect the query schema and create queries.



Examples:

Get all books

query {

&nbsp; books {

&nbsp;   id

&nbsp;   title

&nbsp;   author

&nbsp;   publishedDate

&nbsp; }

}



Get a specific book

query {

&nbsp; book(id: 1) {

&nbsp;   id

&nbsp;   title

&nbsp;   author

&nbsp;   publishedDate

&nbsp; }

}



Get books with filtering

query {

&nbsp; books(where: { author: { eq: "Harper Lee" } }) {

&nbsp;   id

&nbsp;   title

&nbsp;   author

&nbsp; }

}



Delete book

mutation {

&nbsp; deleteBook(id: 2)

}







