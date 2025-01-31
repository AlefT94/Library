# 📚 Library Project

## 🏗️ Architecture

The project follows a microservices-based architecture using Docker containers. The main application is an API developed in ASP.NET Core, connected to a SQL Server database.

## 🎨 Design Patterns Used

- **Clean Architecture**: Code organization in layers (Domain, Application, Infrastructure, Presentation), ensuring low coupling and high cohesion.
- **CQRS (Command Query Responsibility Segregation)**: Separation between read and write operations to improve scalability and performance.
- **Repository Pattern**: Data access abstraction, allowing greater flexibility and easier maintenance.
- **Dependency Injection**: Dependency management to promote inversion of control and facilitate testing.

## 🔧 Technologies Used

- **ASP.NET Core**: Application backend.
- **SQL Server**: Relational database.
- **Docker and Docker Compose**: Container management and orchestration.
- **Entity Framework Core**: Data access with object-relational mapping (ORM).
- **Hangfire**: Background job management.

## ⚙️ Environment Configuration

### Docker Services:

- **librarydb**: SQL Server container configured to accept connections with the following credentials:

  - **User**: `sa`
  - **Password**: `SwN12345678`
  - Exposed port: `1433`
  - Volume: `sqlserver_library` for data persistence.

- **library.api**: API developed in ASP.NET Core with environment variables set for development.

  - Exposed ports: `8080` (HTTP) and `8081` (HTTPS)
  - Connection to the `librarydb` and `hangfiredb` databases.
  - Dependency configured to start after `librarydb`.

### Build and Debug

- The project uses **Docker Compose** to build and run the services.
- The execution profile `"Docker Compose"` allows the `library.api` to start in debug mode.

## 🚀 How to Run the Project

1. **Build and start the containers:**

   ```bash
   docker-compose up --build
   ```

2. **Access the API:**

   - HTTP: `http://localhost:8080`
   - HTTPS: `https://localhost:8081`

3. **Database:**

   - Connect to SQL Server at `localhost:1433` with user `sa` and password `SwN12345678`.

## 📝 Notes

- Make sure Docker is installed and running.
- Access credentials are set for development and **should not be used in production**.

---
