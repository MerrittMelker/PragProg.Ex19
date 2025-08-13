# PragProg.Ex19 — Exercise 19 (Juggling the Real World)

A small .NET 8 solution demonstrating a minimal finite-state machine (FSM) used to extract double-quoted string literals from input text, plus tests and a tiny console demo.

## Layout
- src/PragProg.Fsm: Generic FSM runner (mechanism).
- src/PragProg.Strings: StringExtractor built on the FSM (policy).
- src/PragProg.Demo: Console app that prints extracted strings from a sample input.
- tests/PragProg.Tests: NUnit tests for StringExtractor.

## Quick start
Prereqs: .NET SDK 8.0+ installed. PowerShell 5.1 or 7+ works.

1) Run the setup script to create the solution and add projects.
2) Build the solution.
3) Run the unit tests.
4) Optionally run the demo console app to see extracted strings.

## What the StringExtractor does
- Finds sequences inside double quotes: "..."
- Supports C-style escapes by treating a backslash as escaping the next character.
  - Example: "a\\b" becomes "ab" in the extracted result.
  - Escaped quotes are preserved (e.g., \" inside a string yields a literal ").
- Unterminated strings are ignored.

## Notes
- The setup script previously required PowerShell 7 via `#requires -Version 7`. That requirement was removed so it now runs fine on Windows PowerShell 5.1.
- Projects target net8.0 and use latest C# language version.

## Quickstart (Windows PowerShell)
```powershell
# from repo root
./setup.ps1

# run demo
dotnet run --project src/PragProg.Demo

# run tests
dotnet test
```

## Quickstart (bash/zsh)
```bash
# from repo root
pwsh ./setup.ps1    # or run the dotnet commands inside the script manually
dotnet run --project src/PragProg.Demo
dotnet test
```

Open the folder in Rider and it will detect the solution once `setup.ps1` is run.
