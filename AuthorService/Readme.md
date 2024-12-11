# ASP.NET Core, LINQ, EF Core, and Dependency Injection





# Watch for changes and rebuild/run automatically
dotnet watch run

This project demonstrates the usage of **ASP.NET Core**, **LINQ**, **Entity Framework Core (EF Core)**, and **Dependency Injection (DI)** to implement a basic CRUD application. The goal of the project is to showcase how to work with databases using **PostgreSQL** through EF Core and manage the application flow using **Dependency Injection** for better modularity and maintainability.

## Table of Contents
- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Setting Up the Project](#setting-up-the-project)
- [Usage](#usage)
  - [DbContext and Dependency Injection](#dbcontext-and-dependency-injection)
  - [Performing CRUD Operations](#performing-crud-operations)
- [Conclusion](#conclusion)

## Overview

This project is built using **ASP.NET Core** with **LINQ** and **Entity Framework Core** for interacting with a PostgreSQL database. The key aspects of this implementation are:

1. **DbContext**: A class that represents a session with the database, used to query and save data.
2. **LINQ**: Language Integrated Query, used to interact with collections in a type-safe manner.
3. **Entity Framework Core (EF Core)**: An ORM (Object Relational Mapper) that helps us work with databases using objects.
4. **Dependency Injection (DI)**: A design pattern that allows for more maintainable code by injecting dependencies at runtime.

## Technologies Used

- **ASP.NET Core**: A framework for building web applications and APIs.
- **Entity Framework Core (EF Core)**: ORM for interacting with the PostgreSQL database.
- **LINQ**: For querying data in a more readable and type-safe way.
- **PostgreSQL**: The relational database used for this project.
- **Dependency Injection (DI)**: For managing dependencies within the application.

## Setting Up the Project

1. **Clone the Repository**:
   Clone this repository to your local machine.

   ```bash
   git clone https://github.com/yourusername/aspnet-core-linq-efcore-di.git
   cd aspnet-core-linq-efcore-di
