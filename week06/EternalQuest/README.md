# Eternal Quest (W06) — Polymorphism Design & Implementation

This solution follows the tutor's Guidance from a Mentor and includes an extra Summary Report feature.

## Build & Run
```bash
dotnet build
dotnet run
```

## New Feature (Exceeds Core)
- **Summary Report (Menu 6):** Shows completion percentage for all completable goals (Simple & Checklist). Eternal goals are excluded because they never complete. A summary is also printed after each recorded event.

## Files
- `Program.cs` — entry point calling `GoalManager.Start()`
- `Goal.cs` — abstract base with shared fields and virtual/abstract methods
- `SimpleGoal.cs`, `EternalGoal.cs`, `ChecklistGoal.cs` — concrete goal behaviors
- `GoalManager.cs` — menu, score tracking, create/record/save/load, **summary report**
- `docs/` — collaboration notes, class diagram, changelog
- `ARTICULATE.md` — write-up for the polymorphism articulate assignment
