# Eternal Quest (W06) — Polymorphism Design & Implementation

This solution follows the tutor's *Guidance from a Mentor* and the class diagram. It demonstrates polymorphism with a `Goal` base class and three derived types.

## Build & Run
```bash
dotnet build
dotnet run
```

## Files
- `Program.cs` — entry point calling `GoalManager.Start()`
- `Goal.cs` — abstract base with shared fields and virtual/abstract methods
- `SimpleGoal.cs`, `EternalGoal.cs`, `ChecklistGoal.cs` — concrete goal behaviors
- `GoalManager.cs` — menu, score tracking, create/record/save/load
- `docs/` — collaboration notes and class diagram
- `ARTICULATE.md` — write-up for the polymorphism articulate assignment

## Save Format
First line: score.
Then one goal per line:
- `SimpleGoal|name|desc|points|isComplete`
- `EternalGoal|name|desc|points`
- `ChecklistGoal|name|desc|points|amountCompleted|target|bonus`

## Exceeds Core Requirements
- Robust loader with line-by-line recovery
- Clear separation of concerns (UI vs. domain)
- Type-safe factory `Goal.FromString(...)`
- UTF-8 console, input validation

