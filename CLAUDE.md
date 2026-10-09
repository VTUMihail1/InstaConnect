# CLAUDE.md

Guidance for Claude Code when working in this repository.

## Commands

```bash
dotnet tool restore                                        # local tools: dotnet-retest, reportgenerator
dotnet build InstaConnect.sln
dotnet format InstaConnect.sln --verify-no-changes         # CI fails on formatting drift
dotnet test InstaConnect.sln                               # integration/functional tests need Docker (Testcontainers)
dotnet test tests/Services/Posts/InstaConnect.Posts.Application.Tests.Unit   # run a single test project
docker compose -f docker/docker-compose.yml up --build    # full stack; needs docker/.env (copy docker/.env.example)
```

## Architecture

- Four microservices under `src/Services`: Identity, Posts, Chats, Follows. Shared building blocks are in `src/Common`.
- Each service has `Domain`, `Application`, `Infrastructure`, `Presentation` and `Events` projects. References go Presentation → Infrastructure → Application → Domain → Events, plus the matching `Common` project.
- Services only share `<Service>.Events` projects (e.g. Posts/Chats/Follows reference `Identity.Events`) and communicate through MassTransit + RabbitMQ. Never reference another service's other projects.
- Code is organised by feature: `Features/<Feature>/{Commands,Queries,Controllers,Models,Mappings,Extensions,...}`.
- Application layer uses MediatR requests (`<Action><Entity>CommandRequest` / `...QueryRequest`) with a handler, FluentValidation validator and response type per use case. Mapping uses Mapster.
- Presentation uses versioned controllers (`Controllers/v1`) with route constants in `Utilities/<Entity>Routes.cs`.
- Persistence is MongoDB; Redis is used for caching and SignalR backplane.

## Build Rules

- `TreatWarningsAsErrors`, `AnalysisMode=all`, SonarAnalyzer and `EnforceCodeStyleInBuild` are on (see `Directory.Build.props`). Fix analyzer warnings rather than suppressing them.
- Indent C# with tabs (`.editorconfig`); YAML, JSON and Markdown with 2 spaces.
- Package versions live only in `Directory.Packages.props` (central package management).

## Tests

- xUnit + NSubstitute + FluentAssertions + Bogus, Testcontainers for MongoDB/RabbitMQ/Redis.
- Runnable test projects end in `.Tests.Unit`, `.Tests.Integration` or `.Tests.Functional`. Projects ending in `.Tests` hold shared builders, base classes and assertion extensions; they're not run directly.
- Test classes inherit from a feature base class (e.g. `BasePostCommentLikeApplicationCommandUnitTest`) and use request builders/factories plus helper extensions (`SetupAddAsync`, `ShouldSatisfy`, `ShouldHaveReceivedOneAddAsync`). Follow the existing pattern in the nearest sibling test.
- Test names: `Method_ShouldExpectedBehavior_WhenCondition`, with `// Act` / `// Assert` section comments (arrangement usually lives in the constructor).

## CI

- `.github/workflows/ci.yml` builds and tests only the changed services, split by suite, and retries failed tests up to 3 times with `dotnet retest`.
- Docker images are pushed to GHCR only from `master` after all checks pass. The required status check is **CI Passed**.
