# mathtone-magic

Mathtone Magic is a collection of reusable .NET SDK libraries and test utilities.
The libraries cover common helpers, data access, graphs, logging, neural networks,
reactive values, random-number generation, services, telemetry, time, and testing.

## Repository layout

- `src/sdk/` contains the library projects.
- `src/tests/` contains their xUnit test projects.
- `src/mathtone-magic.sln` is the main solution.
- `.circleci/config.yml` defines CI, release packaging, and NuGet publishing.

The SDK projects target .NET 8 and .NET 10 by default. Build and test the solution
with `dotnet test src/mathtone-magic.sln`.