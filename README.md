# ArtistPlatform

Backend API for a music community platform.

## Features

- JWT authentication
- Artist profiles
- Albums and tracks
- Posts and social interactions
- Role-based authorization
- PostgreSQL persistence
- Pagination and filtering
- Validation
- Global exception handling
- OpenAPI documentation

## Architecture

Clean Architecture

API
 ↓
Application
 ↓
Domain

Infrastructure → PostgreSQL

## Tech Stack

.NET 8
ASP.NET Core Web API
Entity Framework Core
PostgreSQL
JWT
FluentValidation
Swagger / OpenAPI
Docker
xUnit
Moq

## Running locally

                    ┌────────────────────┐
                    │      Client        │
                    └─────────┬──────────┘
                              │
                              ▼
                    ┌────────────────────┐
                    │   ASP.NET Core API │
                    │                    │
                    │ Controllers        │
                    │ Auth/JWT           │
                    │ Middleware         │
                    │ Swagger            │
                    └─────────┬──────────┘
                              │
                              ▼
                    ┌────────────────────┐
                    │    Application     │
                    │                    │
                    │ Services           │
                    │ DTOs               │
                    │ Validators         │
                    │ Interfaces         │
                    └─────────┬──────────┘
                              │
                              ▼
                    ┌────────────────────┐
                    │       Domain       │
                    │                    │
                    │ Entities           │
                    │ Value Objects      │
                    │ Business Rules     │
                    └────────────────────┘
                              ▲
                              │
                    ┌─────────┴──────────┐
                    │   Infrastructure  │
                    │                    │
                    │ EF Core            │
                    │ PostgreSQL         │
                    │ Repositories       │
                    │ Migrations         │
                    └────────────────────┘
