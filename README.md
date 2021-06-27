# .Net 5.0 API Showcase
This repository contains a demo project built in C# and .Net 5.0. This project is intended to be used as demo for API projects in to explain some concepts related with C#/.Net and APIs.

## TOC
  * [Licence](#licence)
  * [Architecture](#architecture)
  * [Data Architecture](#data-architecture)
    + [Conversion between DTOs and Models](#conversion-between-dtos-and-models)
    + [Class types](#class-types)
  * [Dependency Injection](#dependency-injection)
  * [How to run the API](#how-to-run-the-api)
    + [Docker](#docker)
    + [.Net CLI](#net-cli)
    + [Use the API](#use-the-api)
  * [How to run test](#how-to-run-test)
  * [Logs](#logs)
  * [RoadMap](#roadmap)

## Licence
For licence details, please look at `LICENCE` file in this repository.

## Architecture
The API is segregated into layers, each one with a specific responsibility.
* Controller: Is responsible to interact with the outside world receiving requests and sending back responses for those requests. It's a controller responsibility to translate the interface data format (DTOs) into business data format (Models) and vice-versa.  
    *Used Data Models:* DTOs and Models

* Service: It's responsible to apply the business logic and it's completely abstracted from any sort of interface implementations.  
    *Used Data Models:* Models

* Repository: Responsible for the data persistence. It knows nothing about the process. It just ensures the data is persisted/retrieved when needed.  
    *Used Data Models:* Models

## Data Architecture
There is two major types of Data Objects:
* DTOs: aka Data Transfer Objects, are the objects used during the communication between the API and the client. This kind of object defines one of the pieces of the API contract and for this reason they should not vary too much so the consumers will always be able to use the API.
* Models: Models are the internal data format of the API. They do not define any sort of API contract and are much more suitable for changes.

### Conversion between DTOs and Models
There is many ways to perform this conversion. In some projects the team implements "Mappers" to map from one format to other. Other project have specific methods on the DTO and Model classes to make this conversions. In this project was decided to use `Extension` methods `AsDto` and `AsModel`

Below is the implementation of the method `AsDto` for User Model
```C#
public static UserResponse AsDto(this User user)
{
    return new UserResponse
    {
        userId = user.userId,
        name = user.name,
        birthDate = user.birthDate.ToString("yyyy-MM-dd"),
        email = user.email
    };
}
```

Below is the implementation of the method `AsModel` for User Request DTO
```C#
public static User AsModel(this UserRequestCreateUpdate user, Guid userId)
{
    return new User
    {
        userId = userId,
        name = user.name,
        birthDate = new DateTime(user.birthDate.year, user.birthDate.month, user.birthDate.day),
        email = user.email
    };
}
```

On the controller, to run those methods is just needed to call it in the context of the object.
Below is an example of a conversion from Model to DTO
```C#
return Ok(returnUser.AsDto());
```

### Class types
Both DTOs and Models use `record type` classes due it's particularities for data objects.

## Dependency Injection
To handle dependency injection was used the principle of Dependency Inversion. Using .Net's `ConfigureServices` method creating a binding with an interface and one class instance that implements the interface. Then on the constructors when a class depends on other class, this dependency is defined based on the interface and .Net will automatically inject the class instance.
<p align="center">
  <img alt="Dependency Injection" src="./img/Dependency Injection.png">
</p>

This approach also makes really easy to change specific parts of the system, e.g. if you want to implement another repository, you just need to implement it based on the already exiting interface and then update the `Startup.cs` file with your new repository.

## How to run the API

### Docker
To run the API is suggested to use docker. To do this you need docker installed on you computer.
Run this commands on the solution root folder (is the folder you see right after cloning the project)

```sh
#Build the Docker Container
docker build -t dotnet5_api_showcase .

#Run the container
docker run --rm -p 8080:80 dotnet5_api_showcase
```

### .Net CLI
If you need to run the API natively on your machine, enter the folder `DotNet5_API_Showcase/DotNet5_API_Showcase`. You will see a file named `DotNet5_API_Showcase.csproj`. Then open a console and run the following commands.

```sh
dotnet restore "DotNet5_API_Showcase.csproj"
dotnet run
```

### Use the API
On the folder `postman` is a collection to test the API after launching. Import the collection and the environment files. If you ran the API using docker, choose the environment `.Net 5.0 API Showcase Docker`. If you used the `dotnet cli` use the environment `.Net 5.0 API Showcase Local`.

For more details on the rest interface, after running the application access  
`docker` https://localhost:8080/swagger/index.html  
`local ` https://localhost:5001/swagger/index.html

## How to run test
Tests were not implemented yet.

## Logs
Logs were not implemented yet.

## RoadMap
✔ In Memory Database  
✔ DTOs separated from models  
✔ Dependency Injection with .Net built-in features  
✔ DTOs separated from models  
⏳ Unit and Integration tests  
⏳ Logs 