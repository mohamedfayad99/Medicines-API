# Medicines API
## This project is a web application built with .NET 7.0, designed with modern development principles such as separation of concerns, dependency injection, and clean architecture patterns. The core functionalities revolve around secure data handling, efficient object mapping, and an extensible service configuration.
## Key Features
### 1. Mapping with AutoMapper
The application uses AutoMapper to facilitate seamless mapping between domain models and DTOs (Data Transfer Objects). This reduces boilerplate code and improves maintainability when transferring data between different layers of the application.

### 2. Logging
A comprehensive logging system is integrated into the application, enabling the monitoring of errors, performance metrics, and application behavior. This is critical for identifying issues during development and in production environments.

### 3. Services and Dependency Injection
The service layer pattern is followed, where the repositories handle data access and business logic is encapsulated within dedicated services. Dependency Injection (DI) is used extensively, promoting loose coupling and enhancing testability of individual components. Services like repositories and token generation are injected via DI, ensuring modularity
### 4. Extension Methods
Extension methods are utilized to enhance the modularity and maintainability of the application. Key methods include AddApplicationServices for setting up services like the database context, repositories, and AutoMapper, and Extension Method AddAuthentication for configuring JWT authentication.

## Test
dotnet restore
dotnet run
Navigate to https://localhost:7109
![one](https://github.com/user-attachments/assets/2f7c19ad-1f6d-46cf-a506-aeda469437f4)
![two](https://github.com/user-attachments/assets/b8baecba-b81e-4a81-8174-b5d813375ac6)
To test all endpoints, you'll need to use a software such as Postman.
