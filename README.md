# Cinema Application

## Overview

This project, developed as part of the Web Development course, is a "Cinema" application built in the .NET environment. It is designed to manage cinema listings, including films and directors, allowing users to interact with the system through CRUD screens.

## Architecture

The project is divided into three main components:
- **Server**: ASP.NET Core Web API
- **Client**: Blazor WebAssembly
- **Class Library**: Used to store model classes that are utilized by both the client and the server.

## Features

- **CRUD Screens**: Separate CRUD screens for films and directors, facilitated by a sidebar for user navigation.
- **Security**: Implemented secure login and access control using Blazor Authentication & Authorization and Identity systems within the .NET environment.
- **Custom Presentation**: The catalog page showcasing films uses custom CSS styles. Film posters are displayed as cards that flip on hover, revealing film titles and directors.

## Requirements

- .NET 6.0 SDK
- An IDE that supports .NET development (e.g., Visual Studio)

## Setup and Installation

1. Clone the repository from [GitHub](https://github.com/FetterDavid/CinemaApplication).
2. Open the solution in your IDE and restore the required packages.
3. Ensure the database is set up as per the project's configuration.
4. Start the server component to run the backend services.
5. Launch the client application to view the UI.

## Contributing

Contributions are welcome. Please adhere to this project's code style and commit guidelines. Ensure that your changes do not break the application before submitting a pull request.

## Future Enhancements

- Expand the database schema to include more detailed information about films and directors.
- Implement unit testing for both server-side and client-side logic.
