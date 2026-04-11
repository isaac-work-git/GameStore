# Julio Casal Course (.NET 10)
## API
- API stands for Application Programing Interface.
- How a service defines the functions it provides to clients.
- For example using Spotify:
    * Client send the function call 'GetRecentSongs("Julio")'
    * Server returns a recent list of songs for Julio
## REST
- Stands for REpresentational State Transfer
- A set of guiding principles that impose conditions on how an API should work.
- Examples:
    * Stateless, Client-Server, Uniform interface, Layered system, Cacheable, Code on demand
## REST API
- A REST or RESTFUL API is one that conforms to the REST architectural style
### How to identify resources in a REST API?
- A resource is any object, document or thing that the API can receive from or send to clients.
    * Example: Resource will be games in our Game Store
    * Example: Resource would be songs in the Spotify example
- Resources are accessed through Protocal/Domain/Resource
    * Example: https or http://example.com/games (or songs, users, or posts)
        * That is also an example of a URI, or Uniform Resource Identifier - like a URL
### HTTP Methods  
| Method | Purpose |
| ------ | ------- |
| POST   | Creates a new resource |
| GET    | Retrieves the resource representation/state |
| PUT    | Updates an existing resource |
| DELETE | Deletes a resource |
- These are the CRUD operations (Create, Read, Update, Delete) that get referenced frequently
- Example: GET /games
    * This will return a JSON object with the status (200 OK) and the Body ("id": 1, "name": "Street Fighter 2")
## Object Relational Mapping (O/RM)
- A technique for converting data between a relational database and an object-oriented program.
### Entity Framework Core
- A lightweight, extensible, open source and cross-platform object-relational mapper for .NET.
- Sits between API and Database
- Tranlates C# code into SQL statements
- Benefits:
    * No need to learn SQL
    * Minimal data-access code (LINQ)
    * Tooling to keep C# models in sync with DB tables
    * Change tracking
    * Multiple database providers
