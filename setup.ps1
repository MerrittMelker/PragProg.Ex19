# Initializes the solution and adds existing projects.
dotnet --info | Out-Null

$ErrorActionPreference = "Stop"

# Create solution
if (!(Test-Path .\PragProg.Ex19.sln)) {
  dotnet new sln -n PragProg.Ex19
}

# Add projects if not already present
$projects = @(
  "src/PragProg.Fsm/PragProg.Fsm.csproj",
  "src/PragProg.Strings/PragProg.Strings.csproj",
  "src/PragProg.Demo/PragProg.Demo.csproj",
  "tests/PragProg.Tests/PragProg.Tests.csproj"
)

foreach ($p in $projects) {
  if (Test-Path $p) {
    # Try add; ignore if already added
    try { dotnet sln add $p } catch {}
  }
}

# Restore
dotnet restore
