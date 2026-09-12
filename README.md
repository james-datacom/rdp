# RDP — React Dotnet Playground

A full-stack playground combining a React + Vite frontend with a .NET 10 Web API backend using Clean Architecture, CQRS, and MediatR.

## Architecture

```
frontend/          React + Vite + TypeScript
backend/
  src/
    RDP.Domain/           Entities and repository contracts
    RDP.Application/      CQRS commands/queries, MediatR handlers
    RDP.Infrastructure/   In-memory repository implementation
    RDP.WebApi/             HTTP API, Swagger, DI composition
```

**Request flow:** React UI → Web API controller → MediatR → handler → repository

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Node.js 20+

## Getting Started

### Backend

```bash
dotnet run --project backend/src/RDP.WebApi
```

- Swagger UI: [https://localhost:7279/swagger](https://localhost:7279/swagger)
- HTTP API: [http://localhost:5087](http://localhost:5087)

### Frontend

In a second terminal:

```bash
cd frontend
npm install
npm run dev
```

- App: [http://localhost:5173](http://localhost:5173)

The Vite dev server proxies `/api` requests to `http://localhost:5087`.

## API Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/todos` | List all todos |
| GET | `/api/todos/{id}` | Get todo by id |
| POST | `/api/todos` | Create todo |
| PUT | `/api/todos/{id}` | Update todo |
| DELETE | `/api/todos/{id}` | Delete todo |

## Tech Stack

- **Frontend:** React 19, Vite, TypeScript
- **Backend:** .NET 10, ASP.NET Core Web API, Swagger
- **Patterns:** Clean Architecture, CQRS
- **Libraries:** MediatR 12.5.0, FluentValidation
