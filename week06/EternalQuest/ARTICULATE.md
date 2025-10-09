# Polymorphism in Eternal Quest (approx. 150 words)

Polymorphism lets one message (method name) trigger different behavior depending on an object’s runtime type. In Eternal Quest, the base class `Goal` declares the abstract method `RecordEvent()` and the query `IsComplete()`. Each derived class overrides these with type‑specific logic.

**Benefit.** The menu code only needs to know it has a `Goal`. It calls `goal.RecordEvent()` and adds the returned points. We can add new goal types later without changing menu code—open/closed principle.

**Application (code used in this project):**

```csharp
// In GoalManager.RecordEvent()
var goal = _goals[idx - 1];
int awarded = goal.RecordEvent(); // dynamic dispatch
_score += awarded;
```

- `SimpleGoal.RecordEvent()` marks complete once and awards `_points` a single time.
- `EternalGoal.RecordEvent()` never completes and always awards `_points`.
- `ChecklistGoal.RecordEvent()` increments a counter, awards `_points` each time, and when reaching the target, adds a `_bonus` once.

This shared interface with distinct behaviors is the essence of polymorphism, simplifying the manager and making the design extensible.
